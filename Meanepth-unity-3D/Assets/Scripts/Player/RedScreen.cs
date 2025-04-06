using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class RedScreen : MonoBehaviour
{
    public float duration = 60f;
    public float targetAlpha = 0.4f;
    public Image redImage;
    private Coroutine redCoroutine;
    public void StartRed()
    {
        Color color = redImage.color;
        color.a = 0f;
        redImage.color = color;
        redCoroutine = StartCoroutine(RedCorutine());
    }
    IEnumerator RedCorutine()
    { 
        Color color = redImage.color;
        float startAlpha = color.a;

        // Вычисляем время, прошедшее с начала корутины
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Вычисляем интерполированное значение альфы
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsed / duration);
            redImage.color = color;

            // Увеличиваем прошедшее время
            elapsed += Time.deltaTime;

            // Ждем следующего кадра
            yield return null;
        }

    }
    public void StopRed()
    {
        if(redCoroutine != null){
        StopCoroutine(redCoroutine);
        redCoroutine = null;
        }
        Color color = redImage.color;
        color.a = 0f;
        redImage.color = color;
        Debug.Log("Color.a = 0");
    }

}
