/*==============================================================================
Copyright (c) 2019 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class BackImageTracker : MonoBehaviour, ITrackableEventHandler
{
    public UnityEngine.Video.VideoPlayer VideoPlayerEN1,VideoPlayerEN2,VideoPlayerEN3, VideoPlayerHN, VideoPlayerKN,VideoPlayerTL;
    public GameObject QEN1,QEN2,QEN3, QHN, QKN,QTL, revEN1, revEN2, revHN1, revHN2, revKN1, revKN2,revTL1,revTL2,descEN,descHN,descKN,descTL;
    private string selectedLang;
    
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        selectedLang = vb_app.languageSel;
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;
        
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + 
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        Debug.Log("language" + vb_app.languageSel);
        selectedLang = vb_app.languageSel;
        if (selectedLang == "EN")
        {

            QHN.SetActive(false);
            QKN.SetActive(false);
            QTL.SetActive(false);
            revHN1.SetActive(false);
            revHN2.SetActive(false);
            revKN1.SetActive(false);
            revKN2.SetActive(false);
            revTL1.SetActive(false);
            revTL2.SetActive(false);
            descHN.SetActive(false);
            descKN.SetActive(false);
            descTL.SetActive(false);
            if (QEN1.activeSelf == false && QEN2.activeSelf==false&& QEN3.activeSelf==false&& revEN1.activeSelf == false && revEN2.activeSelf == false)
            {
                Debug.Log("putting desc");
                descEN.SetActive(true);
            }
            if (QEN1.activeSelf)
            {
                VideoPlayerEN1.Play();
            }
            if (QEN2.activeSelf)
            {
                VideoPlayerEN2.Play();
            }
            if (QEN3.activeSelf)
            {
                VideoPlayerEN3.Play();
            }
        }
        else if (selectedLang == "HN")
        {
            QEN1.SetActive(false);
            QEN2.SetActive(false);
            QEN3.SetActive(false);
            QKN.SetActive(false);
            QTL.SetActive(false);
            revEN1.SetActive(false);
            revEN2.SetActive(false);
            revKN1.SetActive(false);
            revKN2.SetActive(false);
            revTL1.SetActive(false);
            revTL2.SetActive(false);
            descEN.SetActive(false);
            descKN.SetActive(false);
            descTL.SetActive(false);
            if (QHN.activeSelf == false && revHN1.activeSelf == false && revHN2.activeSelf == false)
            {
                descHN.SetActive(true);
            }
            if (QHN.activeSelf)
            {
                VideoPlayerHN.Play();
            }
        }
        else if (selectedLang == "KN")
        {
            QEN1.SetActive(false);
            QEN2.SetActive(false);
            QEN3.SetActive(false);
            QHN.SetActive(false);
            QTL.SetActive(false);
            revEN1.SetActive(false);
            revEN2.SetActive(false);
            revHN1.SetActive(false);
            revHN2.SetActive(false);
            revTL1.SetActive(false);
            revTL2.SetActive(false);
            descEN.SetActive(false);
            descHN.SetActive(false);
            descTL.SetActive(false);
            if (QKN.activeSelf == false && revKN1.activeSelf == false && revKN2.activeSelf == false)
            {
                descKN.SetActive(true);
            }
            if (QKN.activeSelf)
            {
                VideoPlayerHN.Play();
            }
        }
        else if (selectedLang == "TL")
        {
            QEN1.SetActive(false);
            QEN2.SetActive(false);
            QEN3.SetActive(false);
            QKN.SetActive(false);
            QHN.SetActive(false);
            revEN1.SetActive(false);
            revEN2.SetActive(false);
            revKN1.SetActive(false);
            revKN2.SetActive(false);
            revHN1.SetActive(false);
            revHN2.SetActive(false);
            descEN.SetActive(false);
            descKN.SetActive(false);
            descHN.SetActive(false);
            if (QTL.activeSelf == false && revTL1.activeSelf == false && revTL2.activeSelf == false)
            {
                descTL.SetActive(true);
            }
            if (QTL.activeSelf)
            {
                VideoPlayerTL.Play();
            }
        }
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;
        }
    }


    protected virtual void OnTrackingLost()
    {
        if (VideoPlayerEN1.isPlaying)
        {
            VideoPlayerEN1.Pause();
        }else if (VideoPlayerEN2.isPlaying)
        {
            VideoPlayerEN2.Pause();
        }
        else if (VideoPlayerEN3.isPlaying)
        {
            VideoPlayerEN3.Pause();
        }
        else if (VideoPlayerHN.isPlaying)
        {
            VideoPlayerHN.Pause();
        }
        else if (VideoPlayerKN.isPlaying)
        {
            VideoPlayerKN.Pause();
        }
        else if (VideoPlayerTL.isPlaying)
        {
            VideoPlayerTL.Pause();
        }
        else
        {

        }
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
        }
    }

    #endregion // PROTECTED_METHODS
}
