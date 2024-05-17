using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remain_Pins : MonoBehaviour
{
    private static Remain_Pins s_Instance = null;
    void Awake()
    {
        if (s_Instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        s_Instance = this;
        DontDestroyOnLoad(this.gameObject); //씬 이동 시에도 제거 안함
    }
}
