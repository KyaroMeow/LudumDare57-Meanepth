using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer2 : MonoBehaviour
{
   public GameObject Riba;
   private bool IsntPlayed = true;
   void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player")){
    if(IsntPlayed){
    SFXManager.instance.PlayScream();
    Riba.SetActive(true);
    IsntPlayed = false;
    }
    }
   }
}
