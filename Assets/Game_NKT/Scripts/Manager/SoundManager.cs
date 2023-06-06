using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource musicAudioSource;

    public AudioSource effectAudioSource;

    public AudioClip mainMenuSound;

    public AudioClip gamePlaySound;

    public AudioClip winSound;

    public AudioClip loseSound;

    public AudioClip triggerSound;

    public AudioClip throwSound;

    public AudioClip btnSound;

    private bool isMute;
    public bool IsMute { get => isMute; set => isMute = value; }


    public void MuteMusic(bool isMove)
    {
        IsMute = isMove;

        if (IsMute)
        {
            Pref.SetBool(PrefConst.MUTE, true);

            musicAudioSource.mute = true;

            effectAudioSource.mute = true;
        }

        else
        {
            Pref.SetBool(PrefConst.MUTE, false);

            musicAudioSource.mute = false;

            effectAudioSource.mute = false;
        }
    }

    public void ButtonClickSound()
    {
        if (effectAudioSource && btnSound)
        {
            effectAudioSource.PlayOneShot(btnSound);
        }
    }


    public void LoseSoundPlay()
    {
        if(effectAudioSource && loseSound)
        {
            effectAudioSource.PlayOneShot(loseSound);

            musicAudioSource.mute = true;
        }
    }

    public void WinSoundPlay()
    {
        if (effectAudioSource && winSound)
        {
            effectAudioSource.PlayOneShot(winSound);
            musicAudioSource.mute = true;
        }
    }

    public void ThrowWeaponMusic()
    {
        if (effectAudioSource && throwSound && GameManager.Ins.IsPlayGame)
        {
            effectAudioSource.PlayOneShot(throwSound);
        }
    }

    public void PlayGameMusic()
    {
        if (musicAudioSource && gamePlaySound)
        {
            musicAudioSource.clip = gamePlaySound;
            musicAudioSource.Play();
        }
    }

    public void MainMenuMusic()
    {
        if (musicAudioSource && mainMenuSound)
        {
            musicAudioSource.clip = mainMenuSound;
        }
    }

    public void TriggerWeaponMusic()
    {
        if (effectAudioSource && triggerSound && GameManager.Ins.IsPlayGame)
        {
            effectAudioSource.PlayOneShot(triggerSound);
        }
    }


}
