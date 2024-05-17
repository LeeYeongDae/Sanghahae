using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Light_toggle : MonoBehaviour
{
    GameObject Light;
    float WaitTime = 8f;
    float CurrTime;
    float EnterTime;
    float OffTime = 1f;
    bool Enter;
    public static bool P_turnoff = false;

    void Start()
    {
        Light = GameObject.FindGameObjectWithTag("P_Light");
    }

    void Update()
    {
        if (Enter)
        {
            EnterTime += Time.deltaTime;
            if (EnterTime >= OffTime)
            {
                Light.SetActive(false);
                P_turnoff = true;
            }
        }
            if (P_turnoff)
        {
            CurrTime += Time.deltaTime;
            if (CurrTime >= WaitTime)
            {
                Light.SetActive(true);
                P_turnoff = false;
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
