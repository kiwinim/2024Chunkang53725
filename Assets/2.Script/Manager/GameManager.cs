using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Slider HPbar;
    public bool Startmove = true;
    public bool pattern1 = false;
    public int Player;
    void Awake()
    {
        instance = this;
        Player = 3;
    }
    void Update()
    {
        HPbar.value = PlayerHP.instance.CurrHp/PlayerHP.instance.MaxHp;
    }
    public void Death()
    {
        if(Player != -1)
        {
            Player -= 1;
            PlayerSpawn.instance.PlayerStart();
        }
        else if(Player == -1)
            GameOver();
    }
    public void Phase1()
    {
        Startmove = false;
        pattern1 = true; 
    }
    public void GameOver()
    {

    }
}
