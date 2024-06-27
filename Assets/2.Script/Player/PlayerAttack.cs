using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject flash;
    public Transform bulletSpawnPoint;

    bool cooltime = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if(cooltime == false)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                // 오브젝트풀 에서 빌려오기
                var bulletGo = ObjectPoolManager.instance.GetGo("CommonBullet");
                bulletGo.transform.position = this.bulletSpawnPoint.position;
                cooltime = true;
                StartCoroutine(flashTime());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // 오브젝트풀 에서 빌려오기
                var bulletGo = ObjectPoolManager.instance.GetGo("BulletGreen");

                bulletGo.transform.position = this.bulletSpawnPoint.position;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // 오브젝트풀 에서 빌려오기
                var bulletGo = ObjectPoolManager.instance.GetGo("BulletBlue");

                bulletGo.transform.position = this.bulletSpawnPoint.position;
            }            
        }

    }
    IEnumerator flashTime()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
        cooltime = false;
    }
}
