using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource aus;

    public AudioClip mainMenuSound;

    public AudioClip gamePlaySound;

    public AudioClip winSound;

    public AudioClip loseSound;


    public void LoseSoundPlay()
    {
        if(aus && loseSound)
        {
            aus.PlayOneShot(loseSound);
        }
    }
}
