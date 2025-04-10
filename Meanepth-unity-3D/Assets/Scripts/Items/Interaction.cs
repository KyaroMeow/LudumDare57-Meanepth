using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string interactionText = "Interact";
    public bool IsInteract = true;
    public GameObject hintCanvas;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&&IsInteract){
            hintCanvas.SetActive(true);
        }
    }
     void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            hintCanvas.SetActive(false);
        }
    }
    public void Interact()
    {
        if(IsInteract){
        SFXManager.instance.PlayTouch();
        GetComponent<ItemsShake>().IsShake = false;
        Debug.Log("Взаимодействие с объектом: " + gameObject.name);
        UIManager.instance.StartTypingText(interactionText);
        if(LevelManager.instance != null){
        LevelManager.instance.CurrentItemCount++;
        }
        hintCanvas.SetActive(false);
        IsInteract = false;
        }
    }
}
