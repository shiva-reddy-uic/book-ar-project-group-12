using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Next_rev : MonoBehaviour, IVirtualButtonEventHandler
{
    public VirtualButtonBehaviour next;
    public UnityEngine.Video.VideoPlayer VideoPlayerEN1, VideoPlayerEN2, VideoPlayerEN3, VideoPlayerHN, VideoPlayerKN, VideoPlayerTL;
    public GameObject QEN1, QEN2, QEN3, QHN, QKN, QTL, revEN1, revEN2, revHN1, revHN2, revKN1, revKN2, revTL1, revTL2, descEN, descHN, descKN, descTL;
    private string selectedLang;
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("pressed " +vb);
        Debug.Log("language" + vb_app.languageSel);
        selectedLang = vb_app.languageSel;
        if (selectedLang == "EN")
        {
            Debug.Log("in eng");
            if (descEN.activeSelf)
            {
                descEN.SetActive(false);
                QEN1.SetActive(true);
                VideoPlayerEN1.Play();
            }
            if (QEN1.activeSelf)
            {
                VideoPlayerEN1.Pause();
                QEN1.SetActive(false);
                QEN2.SetActive(true);
                VideoPlayerEN2.Play();
                
            }else if (QEN2.activeSelf)
            {
                VideoPlayerEN2.Pause();
                QEN2.SetActive(false);
                QEN3.SetActive(true);
                VideoPlayerEN3.Play();
            }
            else if (QEN3.activeSelf)
            {
                VideoPlayerEN3.Pause();
                QEN3.SetActive(false);
                revEN1.SetActive(true);
            }
            else if (revEN1.activeSelf)
            {
                revEN1.SetActive(false);
                revEN2.SetActive(true);
            }
            else if (revEN2.activeSelf)
            {
                revEN2.SetActive(false);
                QEN1.SetActive(true);
                VideoPlayerEN1.Play();
            }
            else
            {
               
            }
        }
        if (selectedLang == "HN")
        {
            Debug.Log("in hindi");
            if (descHN.activeSelf)
            {
                descHN.SetActive(false);
                QHN.SetActive(true);
                VideoPlayerHN.Play();
            }
            else if (QHN.activeSelf)
            {
                VideoPlayerHN.Pause();
                QHN.SetActive(false);
                revHN1.SetActive(true);
            }
            else if (revHN1.activeSelf)
            {
                revHN1.SetActive(false);
                revHN2.SetActive(true);
            }
            else if (revHN2.activeSelf)
            {
                revHN2.SetActive(false);
                QHN.SetActive(true);
                VideoPlayerHN.Play();
            }
            else
            {

            }
        }
        if (selectedLang == "KN")
        {
            Debug.Log("in kan");
            if (descKN.activeSelf)
            {
                descKN.SetActive(false);
                QKN.SetActive(true);
                VideoPlayerKN.Play();
            }
            else if (QKN.activeSelf)
            {
                VideoPlayerKN.Pause();
                QKN.SetActive(false);
                revKN1.SetActive(true);
            }
            else if (revKN1.activeSelf)
            {
                revKN1.SetActive(false);
                revKN2.SetActive(true);
            }
            else if (revKN2.activeSelf)
            {
                revKN2.SetActive(false);
                QKN.SetActive(true);
                VideoPlayerKN.Play();
            }
            else
            {

            }
        }
        if (selectedLang == "TL")
        {
            Debug.Log("in tel");
            if (descTL.activeSelf)
            {
                descTL.SetActive(false);
                QTL.SetActive(true);
                VideoPlayerTL.Play();
            }
            else if (QTL.activeSelf)
            {
                VideoPlayerTL.Pause();
                QTL.SetActive(false);
                revTL1.SetActive(true);
            }
            else if (revTL1.activeSelf)
            {
                revTL1.SetActive(false);
                revTL2.SetActive(true);
            }
            else if (revTL2.activeSelf)
            {
                revTL2.SetActive(false);
                QTL.SetActive(true);
                VideoPlayerTL.Play();
            }
            else
            {

            }
        }


    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //throw new System.NotImplementedException();
    }
    //throw new System.NotImplementedException();



    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log("language" + thePlayer.languageSel);
    selectedLang = vb_app.languageSel;
    next.RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
