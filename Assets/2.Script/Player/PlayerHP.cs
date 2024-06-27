using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public static PlayerHP instance;
    public Animator animator;
    public float MaxHp;
    public float CurrHp;

    private void Awake()
    {
        MaxHp = 100f;
        CurrHp = 100f;

        animator = GetComponent<Animator>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            CurrHp -= 1;
        }
        if(CurrHp <= 0f)
        {
            animator.SetTrigger("Death");
            GameManager.instance.Death();
            StartCoroutine("DeathSecond");
        }
    }
    IEnumerator DeathSecond()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerMove.instance.PlayerReturn();
    }
}
