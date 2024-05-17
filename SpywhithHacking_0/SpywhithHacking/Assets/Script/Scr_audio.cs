using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_audio : MonoBehaviour
{
    public GameObject Button_Audio_on;
    public GameObject Button_Audio_off;
    public GameObject Img_audio_on;
    public GameObject Img_audio_off;
    //public AudioSource Background_audio;

    public void AudioOn()
    {
        Button_Audio_on.SetActive(false);
        Img_audio_on.SetActive(false);

        Button_Audio_off.SetActive(true);
        Img_audio_off.SetActive(true);

       // Background_audio.Play();
    }

    public void AudioOff()
    {
        Button_Audio_off.SetActive(false);
        Img_audio_off.SetActive(false);

        Button_Audio_on.SetActive(true);
        Img_audio_on.SetActive(true);

        //Background_audio.Pause();
    }

    public void Start()
    {
        Button_Audio_off.SetActive(false);
        Img_audio_off.SetActive(false);
    }
}
