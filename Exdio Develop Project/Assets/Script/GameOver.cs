using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    float detectTime = 1f;
    float WarnTime;
    bool Warn;
    public static bool isOver;
    public GameObject MiniGame;
    public GameObject Line;

    void Start()
    {
        
    }

    void Update()
    {
        MiniGame = GameObject.FindGameObjectWithTag("MiniGame");
        if (Warn)
        {
            WarnTime += Time.deltaTime;
            if (WarnTime >= detectTime)
            {
                isOver = true;
                Destroy(MiniGame, 0.2f);
                for(int i = 0; i < 4; i++)
                {
                    Line = GameObject.Find("Line" + i);
                    Destroy(Line);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Warn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            WarnTime = 0f;
            Warn = false;
        }
    }
}
