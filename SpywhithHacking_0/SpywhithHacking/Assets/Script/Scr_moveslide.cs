using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scr_moveslide : MonoBehaviour
{
    public GameObject Button_padslide;
    public GameObject Button_ready;
    public GameObject Img_pack;
    public GameObject Img_moz_pack;
    public Transform Pad_slide;
    


    private float Step;
    private bool trigger_slide;
    private bool Command_move;
    private Vector3 Startposition;
    private Vector3 Endposition;
    private float speed = 10f;

    public void GetReady()
    {
        Img_pack.SetActive(false);
        Img_moz_pack.SetActive(true);
    }

    public void PadslideMove()
    {
        Command_move = true;
    }

    public void Start()
    {
        PadslideMove();
        //trigger_slide=false: closed pad 
        trigger_slide = false;
        Startposition = Pad_slide.position;
        Endposition = new Vector3(-8,0,90);
    }
    private void Update()
    {
        Step = speed * Time.deltaTime;
        if (Command_move == false) return;
        
        if (trigger_slide==false)
        {
            Pad_slide.position = Vector3.MoveTowards(Startposition, Endposition, Step);
            trigger_slide = true;
            Command_move = false;

        }
        else
        {
            Pad_slide.position = Vector3.MoveTowards(Endposition, Startposition, Step);
            trigger_slide = false;
            Command_move = false;
        }
    }

   
}
