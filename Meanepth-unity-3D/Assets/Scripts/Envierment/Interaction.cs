using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string interactionText = "Interact"; // Текст для отображения в UI

    public void Interact()
    {
        // Логика взаимодействия
        Debug.Log("Взаимодействие с объектом: " + gameObject.name);
        // Пример: открытие двери
        // GetComponent<Door>().Open();
    }
}
