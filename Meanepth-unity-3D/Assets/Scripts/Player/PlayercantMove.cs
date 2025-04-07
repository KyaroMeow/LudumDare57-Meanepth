using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayercantMove : MonoBehaviour
{
    public Transform playerTransform; // Ссылка на трансформ игрока
    public float rotationSpeed = 5f; // Скорость поворота
    public void Rotate()
    {
        GetComponent<PlayerController>().canMove = false;
        StartCoroutine(RotateCoroutine());
    }
    IEnumerator RotateCoroutine()
    {
        float elapsed = 0f;
        Quaternion startRotation = playerTransform.rotation;
        Quaternion targetRotation = Quaternion.Euler(playerTransform.eulerAngles.x, -90f, playerTransform.eulerAngles.z);

        while (elapsed < 1f / rotationSpeed)
        {
            playerTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsed * rotationSpeed);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Убедитесь, что окончательный поворот установлен точно
        playerTransform.rotation = targetRotation;
    }
}
