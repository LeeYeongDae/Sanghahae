using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Switch : MonoBehaviour
{
    GameObject Switch1;
    GameObject Switch2;
    GameObject Switch3;
    GameObject Door;

    float OpenTime;
    float OnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
       GameObject Switch1 = transform.Find("Door_Switch 2-1").gameObject;
       GameObject Switch2 = transform.Find("Door_Switch 4-1").gameObject;
       GameObject Switch3 = transform.Find("Door_Switch 4-2").gameObject;
       Door = transform.Find("door3-1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Move.OnSwitch == 3)
        {
            OpenTime += Time.deltaTime;
            if (OpenTime >= OnTime)
                    Door.SetActive(false);
        }
    }


}
