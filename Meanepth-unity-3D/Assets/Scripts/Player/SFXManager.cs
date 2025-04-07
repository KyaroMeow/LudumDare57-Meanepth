using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public AudioSource SFXSource;
    public AudioClip Touch;
    public AudioClip LeviScream;
    public AudioClip Steps1;
    public AudioClip Steps2;
    private bool first = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySteps(){
        first = ! first;
        if(first){
        SFXSource.PlayOneShot(Steps1);
        }
        else{
        SFXSource.PlayOneShot(Steps2);  
        }
    }
    public void PlayTouch(){
        SFXSource.PlayOneShot(Touch);
    }
    public void PlayScream(){
        SFXSource.PlayOneShot(LeviScream);
    }

}
