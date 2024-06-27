using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerSpawn : MonoBehaviour
{
    public static PlayerSpawn instance;
    public Transform PlayerSpawnPoint;
    public Transform Player;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerStart();
    }
    void Update()
    {

    }
    public void PlayerStart()
    {
        var PlayertGo = ObjectPoolManager.instance.GetGo("Player");
        PlayertGo.transform.position = this.PlayerSpawnPoint.position;
        PlayerMove.instance.Spawn = true;
    }
}
