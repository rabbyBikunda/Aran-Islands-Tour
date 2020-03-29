﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
   
    public AudioSource MusicSource;
    public AudioSource MusicSource2;

    public AudioSource[] backgroundAudioSources;


    public void PlaySounds()
    { 
            MusicSource.Play();
            if(MusicSource2 != null)
            {
                MusicSource2.Play();
                Debug.Log("MusicSource2 HAS A SOURCE");
            }
            else
            {
                Debug.Log("MusicSource2 IS EMPTY");
            }
        
           
      
    }

    public void stopAllAudio()
    {
        foreach (AudioSource audioS in backgroundAudioSources)
        {
            audioS.Stop();

        }
    }
}
