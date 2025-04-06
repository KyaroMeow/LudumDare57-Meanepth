using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicesInHead : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на AudioSource, который нужно изменить
    public float fadeDuration = 240f; // Продолжительность увеличения громкости в секундах
    public float targetVolume = 1f; // Целевая громкость
    private Coroutine FadeInCoroutine;
    IEnumerator FadeIn()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
            yield break;
        }

        float startVolume = 0f;
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            // Линейно интерполируем громкость от начального к целевому значению
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        // Устанавливаем конечную громкость
        audioSource.volume = targetVolume;
    }

    // Метод для запуска увеличения громкости вручную
    public void StartFadeIn()
    {
       FadeInCoroutine = StartCoroutine(FadeIn());
    }
    public void StopFade()
    {
        if(FadeInCoroutine != null){
        StopCoroutine(FadeInCoroutine);
        FadeInCoroutine = null;
        }
        audioSource.volume = 0f;
    }
}
