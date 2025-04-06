using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f; // Максимальная дистанция взаимодействия
    public Camera playerCamera; // Камера игрока
    public KeyCode interactKey = KeyCode.E; // Клавиша для взаимодействия

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            AttemptInteract();
        }
    }

    void AttemptInteract()
    {
        RaycastHit hit;
        // Отправляем луч из камеры игрока
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange))
        {
            Interaction interactable = hit.collider.GetComponent<Interaction>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    // Для визуализации луча (опционально)
    void OnDrawGizmosSelected()
    {
        if (playerCamera != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(playerCamera.transform.position, playerCamera.transform.position + playerCamera.transform.forward * interactRange);
        }
    }
}
