using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip LoveSong,Tension,Bells,Sheep ;
    static AudioSource audioSrc;
    void Start()
    {
        LoveSong=Resources.Load<AudioClip>("lovesong");
        Tension=Resources.Load<AudioClip>("tension");
        Bells=Resources.Load<AudioClip>("Bells");   
        Sheep=Resources.Load<AudioClip>("Sheep");       


        audioSrc=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound(string clip){

        switch(clip){
            case "lovesong":
                audioSrc.PlayOneShot(LoveSong);
                break;
            case "tension":
                audioSrc.PlayOneShot(Tension);
                break;
            case "Bells":
                audioSrc.PlayOneShot(Bells);
                break;
             case "Sheep":
                audioSrc.PlayOneShot(Sheep);
                break;
        }
    }
}
