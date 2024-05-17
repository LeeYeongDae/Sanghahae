using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public void goSeletStage()
    {
        
    }
    IEnumerator GoStage()
    {
        yield return new WaitForSeconds(1 / 10);

    }
}
