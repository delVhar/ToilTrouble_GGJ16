using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class SoundManager : MonoBehaviour {

    [FMODUnity.EventRef]
    public string SoundEvent;

    FMOD.Studio.EventInstance musicSound;
    FMOD.Studio.EventInstance potionSound;
    FMOD.Studio.EventInstance buttonSound;
    FMOD.Studio.EventInstance mixSound;
    FMOD.Studio.EventInstance scrollSound;
    FMOD.Studio.EventInstance stingerSound;


    [FMODUnity.EventRef]
    public string MusicEvent;
    FMOD.Studio.ParameterInstance musicParam;    
    [FMODUnity.EventRef]
    public string ButtonEvent;
    [FMODUnity.EventRef]
    public string PotionEventFail;
    [FMODUnity.EventRef]
    public string PotionEventSuccess;
    [FMODUnity.EventRef]
    public string MixEvent;
    [FMODUnity.EventRef]
    public string ScrollEvent;
    [FMODUnity.EventRef]
    public string StingerEvent;

    public bool losingLife = false;
    //float startAmbient = 10f;
    public float ambient = 10f;
    public float stepDown;

    // Use this for initialization
    void Start ()
    {
        musicSound = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
        musicSound.getParameter("Light-Dark", out musicParam);
        //musicSound.setParameterValue("Light-Dark", startAmbient);
        musicSound.start();
    }

    // Update is called once per frame
    void Update ()
    {
	    if(losingLife && ambient > stepDown)
        {
            ambient -= Time.deltaTime;
            musicParam.setValue(ambient);
            if (ambient <= stepDown)
                losingLife = false;
        }      
        
    }

    public void LifeLost()
    {
        losingLife = true;
        stepDown = ambient - 5;
        if (stepDown < 0f || ambient <= 0f)
        {
            stepDown = 0;
            ambient = 0f;
            losingLife = false;
        }
    }

    public void PlayPotion(bool success)
    {
        //soundState.setParameterValue("health", (float)health);
        /*if(potionSound != null)
            potionSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        potionSound = FMODUnity.RuntimeManager.CreateInstance(PotionEvent);
        potionSound.setParameterValue("Success", success ? 1.0f : 0.0f);
        
        potionSound.start();
        potionSound.release();*/
        //FMODUnity.RuntimeManager.PlayOneShot(potionSound.get);
        if(success)
            FMODUnity.RuntimeManager.PlayOneShot(PotionEventSuccess);
        else
            FMODUnity.RuntimeManager.PlayOneShot(PotionEventFail);

    }

    public void PlayMix()
    {
        /*if (mixSound != null)
            mixSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        mixSound = FMODUnity.RuntimeManager.CreateInstance(MixEvent);
        //potionSound.setParameterValue("Success", success ? 1.0f : 0.0f);

        mixSound.start();
        mixSound.release();*/
        FMODUnity.RuntimeManager.PlayOneShot(MixEvent);
    }

    public void PlayButton()
    {
        /*if (buttonSound != null)
            buttonSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        buttonSound = FMODUnity.RuntimeManager.CreateInstance(ButtonEvent);
        //potionSound.setParameterValue("Success", success ? 1.0f : 0.0f);

        buttonSound.start();
        buttonSound.release();*/
        FMODUnity.RuntimeManager.PlayOneShot(ButtonEvent);
    }

    public void PlayScroll()
    {
        /*if (scrollSound != null)
            scrollSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        scrollSound = FMODUnity.RuntimeManager.CreateInstance(ScrollEvent);
        //potionSound.setParameterValue("Success", success ? 1.0f : 0.0f);

        scrollSound.start();
        scrollSound.release();*/
        FMODUnity.RuntimeManager.PlayOneShot(ScrollEvent);
    }

    public void PlayStinger()
    {
        /*if (stingerSound != null)
            stingerSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        stingerSound = FMODUnity.RuntimeManager.CreateInstance(StingerEvent);
        //potionSound.setParameterValue("Success", success ? 1.0f : 0.0f);

        stingerSound.start();
        //stingerSound.release();
        stingerSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);*/
        FMODUnity.RuntimeManager.PlayOneShot(StingerEvent);
    }

    public void GameOver()
    {
        musicSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}
