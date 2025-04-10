using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer2 : MonoBehaviour
{
   public Animator RibaAnimator;
   public AudioSource RibaSong;
   private bool IsntPlayed = true;
   void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player")){
    if(IsntPlayed){
    SFXManager.instance.PlayScream();
    RibaAnimator.SetTrigger("Screamer");
    RibaSong.Play();
    IsntPlayed = false;
    }
    }
   }
}
