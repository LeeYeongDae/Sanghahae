using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
   public void Ret()
    {
        StartCoroutine(RetryStage());
    }

    IEnumerator RetryStage()
    {
        yield return new WaitForSeconds(1 / 10);
        SceneManager.LoadScene("Pretest");
        gameObject.GetComponent<Pins>().enabled = true;
    }    
}
