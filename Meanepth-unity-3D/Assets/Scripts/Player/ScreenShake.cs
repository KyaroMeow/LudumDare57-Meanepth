using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeMagnitudeStart = 0.1f; // Начальная амплитуда тряски
    public float shakeMagnitudeEnd = 0.5f; // Конечная амплитуда тряски
    public float shakeIncreaseSpeed = 0.1f; // Скорость увеличения амплитуды
    public Transform PlayerCamera;
    private Vector3 originalPosition;
    private Coroutine shakeCoroutine;

    void Start()
    {
        // Сохраняем исходное положение камеры
        originalPosition = PlayerCamera.localPosition;
    }

    // Метод для запуска тряски
    public void StartShake()
    {
        if (shakeCoroutine == null)
        {
            shakeCoroutine = StartCoroutine(Shake());
        }
    }

    // Метод для остановки тряски
    public void StopShake()
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            shakeCoroutine = null;
            // Возвращаем камеру в исходное положение
            PlayerCamera.localPosition = originalPosition;
        }
    }

    // Корутина для тряски
    IEnumerator Shake()
    {
        float currentMagnitude = shakeMagnitudeStart;

        while (true)
        {
            // Генерируем случайное смещение
            float x = Random.Range(-1f, 1f) * currentMagnitude;
            float y = Random.Range(-1f, 1f) * currentMagnitude;

            // Обновляем положение камеры
            PlayerCamera.localPosition = originalPosition + new Vector3(x, y, 0);

            // Увеличиваем амплитуду
            currentMagnitude = Mathf.Min(currentMagnitude + shakeIncreaseSpeed * Time.deltaTime, shakeMagnitudeEnd);

            // Ждем следующего кадра
            yield return null;
        }
    }

}
