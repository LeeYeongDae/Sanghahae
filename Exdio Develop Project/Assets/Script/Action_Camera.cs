using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Camera : MonoBehaviour
{
    public GameObject Player;
    Transform moving;

    private void Awake()
    {
        Player = GameObject.Find("Player");     //플레이어 찾기
    }

    // Use this for initialization
    void Start()
    {
        moving = Player.transform;      //플레이어 이동 확인
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart.m_game == true)
            transform.position = GameStart.campos;
        else
        {
            transform.position = Vector3.Lerp(transform.position, moving.position, 2f * Time.deltaTime);        //카메라 이동
            transform.Translate(0, 0, -10);      //z축 거리 조정
            Vector3 CameraPosition = transform.position;        //플레이어 따라가기
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.2f, 4f), -10);        //카메라 범위 제한
    }
}
