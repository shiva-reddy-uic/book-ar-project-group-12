using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class changevideo: MonoBehaviour, IVirtualButtonEventHandler, ITrackableEventHandler
{
 
    public VirtualButtonBehaviour change_video;
    public UnityEngine.Video.VideoPlayer VideoPlayer,VideoPlayer2,VideoPlayer3;
    private TrackableBehaviour mTrackableBehaviour;
    public GameObject q1, q2,q3;
    public string selectedLang = "EN";

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        selectedLang = vb_app.languageSel;

        if (VideoPlayer.isPlaying) { 

            VideoPlayer.Pause();
            q1.SetActive(false);
            q2.SetActive(true);
            VideoPlayer2.Play();
        }
        else if (VideoPlayer2.isPlaying)
        {
            VideoPlayer2.Pause();
            q2.SetActive(false);
            q3.SetActive(true);
            VideoPlayer3.Play();
        }
        else if (VideoPlayer3.isPlaying)
        {
            VideoPlayer3.Pause();
            q3.SetActive(false);
            q1.SetActive(true);
            VideoPlayer.Play();
        }
        else
        {
            VideoPlayer.Play();
        }
        Debug.Log("Button pressed" + vb);        //new WaitForSeconds(5);
    }

   
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        change_video.RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        selectedLang = vb_app.languageSel;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Image Found");
            if (q1.activeSelf && selectedLang == "EN")
            {
                Debug.Log("Video1"+selectedLang);
                VideoPlayer.Play();
            }
            else if (q2.activeSelf && selectedLang == "EN")
            {
                Debug.Log("Video2");
                VideoPlayer2.Play();
            }
            else if (q3.activeSelf && selectedLang == "EN")
            {
                Debug.Log("Video3");
                VideoPlayer3.Play();
            }
            
        }
        else
        {
            Debug.Log("Lost Image");
            VideoPlayer.Pause();
            VideoPlayer2.Pause();
            VideoPlayer3.Pause();
            
        }
    }
}
