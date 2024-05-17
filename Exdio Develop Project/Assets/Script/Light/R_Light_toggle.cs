using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Light_toggle : MonoBehaviour
{
    GameObject Light;
    float WaitTime = 8f;
    float CurrTime;
    float EnterTime;
    float OffTime = 1f;
    bool Enter;
    public static bool R_turnoff = false;

    void Start()
    {
        Light = GameObject.FindGameObjectWithTag("R_Light");
    }

    void Update()
    {
        if (Enter)
        {
            EnterTime += Time.deltaTime;
            if (EnterTime >= OffTime)
            {
                Light.SetActive(false);
                R_turnoff = true;
            }
        }
        if (R_turnoff)
        {
            CurrTime += Time.deltaTime;
            if (CurrTime >= WaitTime)
            {
                Light.SetActive(true);
                R_turnoff = false;
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
