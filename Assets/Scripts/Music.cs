using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Music : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter tavernEmitter_Music; // �cie�ka do event emittera na scenie
    bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        tavernEmitter_Music = FindObjectOfType<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (!tavernEmitter_Music.IsPlaying())
        {
            tavernEmitter_Music.Play();
        }
        switch (gameObject.name)
        {
            case "Food_bottle4":
                tavernEmitter_Music.SetParameter("music_parameter", 0);
                Debug.Log("Switching Music");
                break;
            case "Food_bottle1":
                tavernEmitter_Music.SetParameter("music_parameter", 1);
                Debug.Log("Switching Music");
                break;
            case "Food_bottle3":
                tavernEmitter_Music.SetParameter("music_parameter", 2);
                Debug.Log("Switching Music");
                break;
            case "Food_bottle2":
                tavernEmitter_Music.SetParameter("music_parameter", 3);
                break;
            case "Food_bottle6":
                tavernEmitter_Music.SetParameter("music_parameter", 0);
                Debug.Log(tavernEmitter_Music.IsPlaying());
                break;
        }
    }
}
