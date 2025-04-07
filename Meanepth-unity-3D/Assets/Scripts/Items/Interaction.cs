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
        GetComponent<ItemsShake>().IsShake = false;
        Debug.Log("Взаимодействие с объектом: " + gameObject.name);
        UIManager.instance.StartTypingText(interactionText);
        LevelManager.instance.CurrentItemCount++;
        IsInteract = false;
        }
    }
}
