using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class BossMove : PoolAble
{
    
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    float yScreenHalfSize;
    public float xScreenHalfSize;          // 화면의 가로 반 사이즈

    public float Speed = 5f;

    public int num;
    public int h = 1;
    public int nextmove;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 2);
    }
    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;
    }

    void Update()
    {
        if(GameManager.instance.Startmove == true)
        {
            StartMove();
        }
        if(GameManager.instance.pattern1 == true)
        {
            Pattern1();
        }

        if (this.gameObject == null)
        {
            // 오브젝트 풀에 반환
            ReleaseObject();
        }
    }
    void StartMove()
    {
        var dir = new Vector3(0, -1, 0);
        Vector2 Screenposition= new Vector2 (0f, yScreenHalfSize);
        if(this.transform.position.y > Screenposition.y * 0.8f)
        {
            this.transform.Translate(-dir * this.Speed * Time.deltaTime);
        }
        else if(this.transform.position.y >= Screenposition.y*0.6f)
        {
            this.transform.Translate(-dir * this.Speed * 0.2f * Time.deltaTime);
        }
        else
        {
            GameManager.instance.Phase1();
        }
    }
    void Pattern1()
    {
        rigid.velocity = new Vector2(nextmove * Speed, rigid.velocity.y);//왼쪽으로 가니까 -1, y축은 0을 넣으면 큰일남!
            //플랫폼 체크 
            //몬스터는 앞을 체크해야 
        Vector2 frontVec = new Vector2(rigid.position.x + nextmove,rigid.position.y+1f);
        UnityEngine.Debug.DrawRay(frontVec, Vector3.left, new Color(0, 1, 0)); 
        // 시작,방향 색깔
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.left, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            Turn();
        }
    }
    void Think()
    {
        UnityEngine.Debug.Log("dfsf");
        //set next active
        nextmove = Random.Range(-1, 2); //-1이면 왼쪽, 0이면 멈추기,1이면 오른쪽으로이동
        //방향 바꾸기 (0일 때는 굳이 바꿀 필요없기에 조건문 사용해준거)
        if (nextmove!= 0)
        {
            spriteRenderer.flipX = (nextmove == 1); //nextMove가 1이면 방향바꾸기
        }
        //재귀 
        float nextThinkTime = Random.Range(0.5f, 2f);//생각하는 시간도 랜덤으로 

        Invoke("Think", nextThinkTime);//재귀
    }
    void Turn()
    {
        UnityEngine.Debug.Log("Turn");

        nextmove=nextmove* (-1);
        spriteRenderer.flipX = (nextmove== 1); //nextMove가 1이면 방향바꾸기
 
        CancelInvoke();
        Invoke("Think", 2);
    }
}
