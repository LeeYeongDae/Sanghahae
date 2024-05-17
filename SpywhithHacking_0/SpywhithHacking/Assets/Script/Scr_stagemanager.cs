using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_stagemanager : MonoBehaviour
{
    public GameObject Button_stage_1;
    public GameObject Button_stage_2;
    public GameObject Button_stage_3;
    public bool Loadtrigger;
    public string SceneTOLoad;
   public void LoadStage1()
    {
        SceneTOLoad = "3_Preinspection";
        Loadtrigger = true;
    }
    public void Update()
    {
        if (Loadtrigger == false) return;
        SceneManager.LoadScene(SceneTOLoad);
        Loadtrigger = false;
        
    }

}
