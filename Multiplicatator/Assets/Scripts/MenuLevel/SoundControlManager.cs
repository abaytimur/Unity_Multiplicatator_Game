using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControlManager : MonoBehaviour
{
    public void UnmuteSound()
    {
        PlayerPrefs.SetInt("SoundMute",1);
        
    }
    
    public void MuteSound()
    {
        PlayerPrefs.SetInt("SoundMute",0);
    }

    private void Start()
    {
        UnmuteSound();
    }
}
