using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Action : MonoBehaviour
{
    public void Starting()
    {
        Pins.ActionPin();
        StartCoroutine(StartAction());
    }

    IEnumerator StartAction()
    {
        yield return new WaitForSeconds(1 / 10);        //로딩 시간
        SceneManager.LoadScene("Action");               //실행 씬으로 이동
        gameObject.GetComponent<Pins>().enabled = false;    //실행 씬에서 핀 설치 불가능
    }
}
