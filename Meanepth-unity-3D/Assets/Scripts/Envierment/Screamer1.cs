using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer1 : MonoBehaviour
{
    public GameObject Riba;
    public bool isScream = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!isScream)
            {
                Riba.SetActive(true);
                SFXManager.instance.PlayScream();
                isScream = true;
            }
        }
    }
}
