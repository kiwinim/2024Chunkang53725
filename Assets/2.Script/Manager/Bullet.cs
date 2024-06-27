using Unity.VisualScripting.FullSerializer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolAble
{
    public float Speed = 5f;

    void Update()
    {
        // 총알이 많이 날라가면 삭제 해주기
        if (this.transform.position.y > 10)
        {
            // 오브젝트 풀에 반환
            ReleaseObject();
        }

        this.transform.Translate(Vector3.right * this.Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ReleaseObject();
    }
}
