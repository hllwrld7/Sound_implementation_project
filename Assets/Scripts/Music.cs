using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Music : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter tavernEmitter_Music; // �cie�ka do event emittera na scenie
    bool pressed = false;
    FMOD.Studio.EventInstance HealthSnap;
    public EventReference healthSnapshot;
    private bool healthSnapActive;
    private bool snapshotPlaying;

    // Start is called before the first frame update
    void Start()
    {
        //tavernEmitter_Music = FindObjectOfType<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && tavernEmitter_Music.IsPlaying())
            tavernEmitter_Music.Stop();

        if (Input.GetKeyDown(KeyCode.H))
            if (healthSnapActive)
            {
                healthSnapActive = false;
                Debug.Log("health dnap deactivated");
            }
            else
            {
                healthSnapActive = true;
                Debug.Log("health dnap activated");
            }


        if (tavernEmitter_Music != null && tavernEmitter_Music.IsPlaying() && healthSnapActive && !snapshotPlaying) // sprawdzenie czy event emitter istnieje na scenie i czy jest aktywny
                                                                // ENG - checking if the event emitter exists on the scene and if it is active
        {
            HealthSnap = FMODUnity.RuntimeManager.CreateInstance(healthSnapshot); // podanie klasie snapshotu ścieżki do wybranego eventu / snapshotu
                                                                                  // ENG - giving the snapshot class the path to the selected event / snapshot
            HealthSnap.start(); // włączenie snapshotu // ENG - snapshot activation
            snapshotPlaying = true;
            Debug.Log($"health dnap started");
        }
        else if (tavernEmitter_Music != null && tavernEmitter_Music.IsPlaying() && !healthSnapActive && snapshotPlaying)
        {
            snapshotPlaying = false;
            HealthSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // STOP z fadeout // ENG - stop with fading out
            HealthSnap.release(); // zwolnienie pamięci // ENG - memory release
            Debug.Log($"health dnap stopped");
        }
    }

    private void OnKeyDown()
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
