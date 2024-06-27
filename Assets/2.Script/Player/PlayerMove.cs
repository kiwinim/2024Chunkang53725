using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PoolAble
{
    public static PlayerMove instance;
    public float speed = 1f;
    public bool Spawn = false;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(Spawn == true)
            StartMove();
        else if(Spawn == false)
        {
            // 가로 이동 반환값 : LeftArrow = -1 RightArrow = 1
            var h = Input.GetAxisRaw("Horizontal");
            // 세로 이동 반환값 : DownArrow = -1 UpArrow = 1        
            var v = Input.GetAxisRaw("Vertical");

            //단위 벡터 (크기가 1인 벡터)
            var dir = new Vector3(h, v, 0).normalized;

            this.transform.Translate(dir * this.speed * Time.deltaTime);            
        }
    }
    public void PlayerReturn()
    {
        ReleaseObject();
    }
    void StartMove()
    {
        var dir = new Vector3(0, 1, 0);
        if(this.transform.position.y <= -3.5f)
        {
            this.transform.Translate(dir * speed* 0.2f * Time.deltaTime);
        }
        else
            Spawn = false;
    }
}
