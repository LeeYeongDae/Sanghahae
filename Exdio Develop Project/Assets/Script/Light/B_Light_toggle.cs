using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Light_toggle : MonoBehaviour
{
    GameObject Light;
    float WaitTime = 8f;
    float CurrTime;
    float EnterTime;
    float OffTime = 1f;
    bool Enter;
    public static bool B_turnoff = false;

    void Start()
    {
        Light = GameObject.FindGameObjectWithTag("B_Light");
    }
    void Update()
    {
        //print("Enter" + EnterTime);
        //print("Off" + OffTime);
        if (Enter)
        {
            EnterTime += Time.deltaTime;
            if (EnterTime >= OffTime)
            {
                Light.SetActive(false);
                B_turnoff = true;
            }
        }
            if (B_turnoff)
            {
                CurrTime += Time.deltaTime;
                if (CurrTime >= WaitTime)
            {
                Light.SetActive(true);
                B_turnoff = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnterTime = 0f;
            Enter = false;
        }
    }
}
