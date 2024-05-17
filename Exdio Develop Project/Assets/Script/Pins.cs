using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    public static int waypointIndex = 0;
    public GameObject pin;
    Vector2 Pin;
    Camera Camera;
    Transform parent_pin;
    GameObject[] Ladder;

    void Start()
    {
        Screen.SetResolution(1621, 768, false);
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        parent_pin = GameObject.Find("Pins").GetComponent<Transform>();
        Ladder = GameObject.FindGameObjectsWithTag("Ladder");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Pin = Input.mousePosition;      //마우스 위치에 핀 찍기
            Pin = Camera.ScreenToWorldPoint(Pin);
            if (Pin.y >= -4.2f && Pin.y <= -2.3f)     //1층 한정
                Pin.y = -3.5f;
            if (Pin.y > -2.3f && Pin.y <= -0.1f)        //2층 한정
                Pin.y = -1.37f;
            if (Pin.y > -0.1f && Pin.y <= 2f)         //3층 한정
                Pin.y = 0.71f;
            if (Pin.y > 2f && Pin.y <= 4.2f)         //4층 한정
                Pin.y = 2.84f;
            waypointIndex++;                            //핀 갯수 증가
            createPin("" + waypointIndex + "");         //핀 생성


            //설치 제한

            GameObject StartPin = GameObject.Find("Start");     //시작 핀 찾기
            GameObject CurrentPin = GameObject.Find("" + waypointIndex + "");   //현재 핀 찾기
            GameObject PreviousPin = GameObject.Find("" + (waypointIndex - 1) + "");    //이전 핀 찾기
            if (waypointIndex <= 1)     //첫번째 핀의 경우 이전 핀은 시작 핀
                PreviousPin = StartPin;

            float PinDistance = (CurrentPin.transform.position.x - PreviousPin.transform.position.x);       //현재 핀과 이전 핀 사이의 거리


            //이전 핀과의 높이가 다르면 설치 안됨

            if (Pin.y != PreviousPin.transform.position.y)
            {
                Destroy(CurrentPin);
                waypointIndex--;
            }


            //사다리 상호작용

            for (int i = 0; i < Ladder.Length; i++)
            {
                if (Pin.x >= (Ladder[i].transform.position.x - 0.25f) && Pin.x <= (Ladder[i].transform.position.x + 0.25f))
                {
                    if (Ladder[i].transform.position.y == -2.95f)
                    {
                        if (Pin.y == -3.5f)
                        {
                            if (PreviousPin.transform.position.y == -3.5f)
                            {
                                Pin.y = -1.37f;
                                waypointIndex++;
                                createPin("" + waypointIndex + "");
                            }
                        }
                        else if (Pin.y == -1.37f)
                        {
                            if (PreviousPin.transform.position.y == -1.37f)
                            {
                                Pin.y = -3.5f;
                                waypointIndex++;
                                createPin("" + waypointIndex + "");
                            }
                        }
                    }
                    else if (Ladder[i].transform.position.y == -0.82f)
                    {
                        if (Pin.y == -1.37f)
                        {
                            if (PreviousPin.transform.position.y == -1.37f)
                            {
                                Pin.y = 0.71f;
                                waypointIndex++;
                                createPin("" + waypointIndex + "");
                            }
                        }
                        else if (Pin.y == 0.71f)
                        {
                            if (PreviousPin.transform.position.y == 0.71f)
                            {
                                Pin.y = -1.37f;
                                waypointIndex++;
                                createPin("" + waypointIndex + "");
                            }
                        }
                    }
                    else if (Ladder[i].transform.position.y == 1.3f)
                    {
                        if (Pin.y == 0.71f)
                        {
                            if (PreviousPin.transform.position.y == 0.71f)
                            {
                                Pin.y = 2.84f;
                                waypointIndex++;
                                createPin("" + waypointIndex + "");
                            }
                        }
                        else if (Pin.y == 2.84f)
                        {
                            if (PreviousPin.transform.position.y == 2.84f)
                            {
                                Pin.y = 0.71f;
                                waypointIndex++;
                                createPin("" + waypointIndex + "");
                            }
                        }
                    }
                }
            }
          
            if (waypointIndex < 0)      //핀의 수가 0 아래로 못 내려가게 하기
                waypointIndex = 0;
        }
    }
    public void createPin(string pinname)       //핀 제작
    {
        GameObject newpin = Instantiate(pin, Pin, Quaternion.identity) as GameObject;       //핀 생성
        newpin.name = pinname;      //핀 이름
        newpin.transform.parent = parent_pin;       //핀을 parent_pin의 자식 오브젝트로 설정
    }

    public static void DeletePin()      //핀 제거
    {
        GameObject CurrentPin = GameObject.Find("" + waypointIndex + "");
        if (CurrentPin.transform.position.y == 2.84f)        //4층의 경우 2번 지우기
        {
            Destroy(CurrentPin);
            waypointIndex--;
            CurrentPin = GameObject.Find("" + waypointIndex + "");
        }
        Destroy(CurrentPin);
        waypointIndex--;
    }
    public static void ActionPin()
    {
        GameObject CurrentPin = GameObject.Find("" + waypointIndex + "");
        if (CurrentPin.transform.position.y == -3.5f)        //1층의 경우 지우기
        {
            Destroy(CurrentPin);
            waypointIndex--;
            CurrentPin = GameObject.Find("" + waypointIndex + "");
        }
    }
}
