using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string interactionText = "Interact";
    public bool IsInteract = true;
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
        IsInteract = false;
        }
    }
}
