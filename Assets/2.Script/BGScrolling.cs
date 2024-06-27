using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    public float speed;             // 배경 스크롤 속도
    public Transform[] backgrounds; // 배경 스프라이트들의 배열

    float leftPosY = 0f;            // 왼쪽 경계 y 위치
    float rightPosY = 0f;           // 오른쪽 경계 y 위치
    public float xScreenHalfSize;          // 화면의 가로 반 사이즈
    float yScreenHalfSize;          // 화면의 세로 반 사이즈

    void Start()
    {
        // 카메라의 세로 반 사이즈 계산
        yScreenHalfSize = Camera.main.orthographicSize;
        // 카메라의 가로 반 사이즈 계산
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        // 배경의 왼쪽 경계 y 위치 설정
        leftPosY = -(yScreenHalfSize * 2);
        // 배경의 오른쪽 경계 y 위치 설정
        rightPosY = yScreenHalfSize * 2 * backgrounds.Length;
    }

    void Update()
    {
        // 모든 배경에 대해 반복
        for(int i = 0; i < backgrounds.Length; i++)
        {
            // 배경을 아래 방향으로 스크롤
            backgrounds[i].position += new Vector3(0, -speed, 0) * Time.deltaTime;

            // 배경이 왼쪽 경계를 벗어났을 경우
            if(backgrounds[i].position.y < leftPosY)
            {
                // 다음 위치로 배경 이동
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x, nextPos.y + rightPosY, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }
}