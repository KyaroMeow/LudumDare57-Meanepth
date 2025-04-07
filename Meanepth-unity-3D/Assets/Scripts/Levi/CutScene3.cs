using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene3 : MonoBehaviour
{
    public Transform playerTransform; // Ссылка на трансформ игрока
    public Vector3 offset = new Vector3(0, 5, -10); // Смещение относительно игрока
    public float followSpeed = 5f; // Скорость следования

    private Vector3 targetPosition;

    void OnEnable()
    {
        if (playerTransform != null)
        {
            // Устанавливаем начальную целевую позицию
            targetPosition = playerTransform.position + offset;
            // Плавно перемещаем объект в начальную позицию
            StartCoroutine(MoveToTargetPosition());
        }
        else
        {
            Debug.LogError("Player Transform is not assigned.");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // Обновляем целевую позицию
            targetPosition = playerTransform.position + offset;
            // Плавно перемещаем объект к целевой позиции
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    IEnumerator MoveToTargetPosition()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }
}
