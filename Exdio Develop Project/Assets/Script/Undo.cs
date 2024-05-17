using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undo : MonoBehaviour
{
    public void DeleteLatestPin()
    {
        Pins.DeletePin();       //핀 지우기
    }
}
