using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicSwitch_new : MonoBehaviour, IInteractable
{
    private AudioSystem audioSystem;

    private void Start()
    {
        audioSystem = FindObjectOfType<AudioSystem>();
    }

    public void Interact()
    {
        if (audioSystem.isMusicPlaying)
        // StudioEventEmitter.instance.getParameterValue(stringName, out value1, out finalValue);
        {
            switch (gameObject.name)
            {
                case "Food_bottle4":
                    audioSystem.TavernMusic.SetParameter("music_parameter", 0);
                    Debug.Log("Switching Music");
                    break;
                case "Food_bottle1":
                    audioSystem.TavernMusic.SetParameter("music_parameter", 1);
                    Debug.Log("Switching Music");
                    break;
                case "Food_bottle3":
                    audioSystem.TavernMusic.SetParameter("music_parameter", 2);
                    Debug.Log("Switching Music");
                    break;
                case "Food_bottle2":
                    audioSystem.TavernMusic.SetParameter("music_parameter", 3);
                    audioSystem.isMusicPlaying = false;
                    Debug.Log(audioSystem.isMusicPlaying);
                    break;
            }
        }
        else if(gameObject.name == "Food_bottle6" && !audioSystem.isMusicPlaying)
        {
            if(gameObject.name == "Food_bottle6")
            Debug.Log("start");
            audioSystem.TavernMusic.SetParameter("music_parameter", 0);
            audioSystem.TavernMusic.Play();
            audioSystem.isMusicPlaying = true;
        }
    }
}