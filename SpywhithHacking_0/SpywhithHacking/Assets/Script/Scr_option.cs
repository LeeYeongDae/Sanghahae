using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_option : MonoBehaviour
{
    public GameObject Panel_option;
    public GameObject Button_option;
    public GameObject Button_goto_main;
    public GameObject Button_option_close;
    public GameObject Button_excit;

    public void Loadmain()
    {
        SceneManager.LoadScene("1_Main");
        Panel_option.SetActive(false);
    }

    public void Open_option()
    {
        Panel_option.SetActive(true);
    }

    public void Close_option()
    {
        Panel_option.SetActive(false);
    }

    public void Excit()
    {
        Application.Quit();
    }

    public void Start()
    {
        Panel_option.SetActive(false);
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "1_Main") Button_goto_main.SetActive(false);
        else Button_goto_main.SetActive(true);
    }
}
