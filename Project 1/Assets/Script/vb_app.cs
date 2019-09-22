using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vb_app : MonoBehaviour, IVirtualButtonEventHandler {
    public GameObject willyWonkaObj;
    public GameObject textObjects_en;
    public GameObject textObjects_kn;
    public GameObject textObjects_hi;
    public GameObject textObjects_tl;
    public GameObject planeColor;
    public TextMesh textObject;
    public VirtualButtonBehaviour introButton;
    public VirtualButtonBehaviour langButton;
    public AudioSource[] audioData;
    public static string languageSel = "EN";
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("In start");
        
        introButton.RegisterEventHandler(this);
        langButton.RegisterEventHandler(this);



    }
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb == introButton) {
            willyWonkaObj.SetActive(true);
            
            if (languageSel == "EN")
            {
                foreach (AudioSource audio in audioData)
                {
                    if (audio.name == "Intro_en") {
                       // audio.Play();
                    }
                }
                audioData[0].Play();
            }
            else if (languageSel == "KN")
            {
                foreach (AudioSource audio in audioData)
                {
                    if (audio.name == "Intro_kn")
                    {
                        //audio.Play();
                    }
                }
                audioData[1].Play();
            }
            else if (languageSel == "HN")
            {
                foreach (AudioSource audio in audioData)
                {
                    if (audio.name == "Intro_hi")
                    {
                       // audio.Play();
                    }
                }
                audioData[2].Play();
            }
            else {
                foreach (AudioSource audio in audioData)
                {
                    if (audio.name == "Intro_tl")
                    {
                        //audio.Play();
                    }
                }
                audioData[3].Play();
            }
            Debug.Log("Button pressed" + vb);
        }
        if (vb == langButton) {
            Debug.Log("Button pressed" + vb);
            if (languageSel == "EN")
            {
                languageSel = "KN";
                textObjects_en.SetActive(false);
                textObjects_kn.SetActive(true);
                textObject.text = "Change \r\n Language \r\n to \r\n Hindi";
                //Material greenMaterial = new Material(Shader.Find("Green-button"));
                //planeColor.material = greenMaterial;
                planeColor.GetComponent<Renderer>().material.color = new Color(0,0,0);
            }
            else if (languageSel == "KN")
            {
                languageSel = "HN";
                textObjects_hi.SetActive(true);
                textObjects_kn.SetActive(false);
                textObject.text = "Change \r\n Language \r\n to \r\n Telugu";
                planeColor.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            }
            else if (languageSel == "HN")
            {
                languageSel = "TL";
                textObjects_hi.SetActive(false);
                textObjects_tl.SetActive(true);
                textObject.text = "Change \r\n Language \r\n to \r\n English";
                planeColor.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
            }
            else if(languageSel == "TL") {
                languageSel = "EN";
                textObjects_tl.SetActive(false);
                textObjects_en.SetActive(true);
                textObject.text = "Change \r\n Language \r\n to \r\n Kannada";
                planeColor.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            }
        }
        
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        willyWonkaObj.SetActive(false);
        Debug.Log("Button released");
    }
    // Update is called once per frame
    void Update()
    {
        // When a key is pressed list all the gameobjects that are playing an audio
       
    }
}
