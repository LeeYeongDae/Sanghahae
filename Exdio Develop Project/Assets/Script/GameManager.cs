using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float Ready;
    int up;
    GameObject Force;
    GameObject Gameover;
    GameObject Stageclear;
    GameObject Retry;
    GameObject Stage;

    // Start is called before the first frame update
    void Start()
    {
        Ready = 0f;
        up = 2;
        Force = GameObject.Find("Background").transform.Find("Unforce").gameObject;
        Gameover = GameObject.Find("Canvas").transform.Find("GameOver").gameObject;
        Stageclear = GameObject.Find("Canvas").transform.Find("StageClear").gameObject;
        Retry = GameObject.Find("Canvas").transform.Find("Retry_B").gameObject;
        Stage = GameObject.Find("Canvas").transform.Find("Stage_B").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver.isOver)
        {
            Gameover.SetActive(true);
        }

        if (Move.isClear)
        {
            Force.SetActive(true);
            Ready += Time.deltaTime;
            Stageclear.SetActive(true);
            if(Ready > up)
            {
                Retry.SetActive(true);
                Stage.SetActive(true);
            }
                
        }
    }
}
