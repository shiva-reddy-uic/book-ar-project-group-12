using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetPlayAudio : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    AudioSource[] audioData;
    public GameObject riverObj;


    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour) {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            audioData = GetComponents<AudioSource>();
            audioData[0].Play();
            audioData[1].Play();
            audioData[2].Play();
        }
        else
        {
            // Stop audio when target is lost
            //GetComponent<AudioSource>().enabled = false;
            audioData = GetComponents<AudioSource>();
            audioData[0].Pause();
            audioData[1].Pause();
            audioData[2].Pause();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
