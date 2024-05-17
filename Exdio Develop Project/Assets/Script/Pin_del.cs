using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin_del : MonoBehaviour
{
    Vector2 Pin;
    Vector2 player;

    float WaitTime = 0.5f;
    float CurrTime;
    // Start is called before the first frame update
    void Start()
    {
        Pin = this.transform.position;      //핀 위치
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;     //플레이어 찾기
        float distance = (Pin - player).sqrMagnitude;       //핀과 플레이어의 거리

        if (distance == 0)      //핀에 도달한 경우
        {
            CurrTime += Time.deltaTime;
            if (CurrTime >= WaitTime)
                this.gameObject.SetActive(false);       //해당 핀 비활성화
        }
    }
}
