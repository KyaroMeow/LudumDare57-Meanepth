using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image BlackImage;
    public void FadeToDark()
    {
        StartCoroutine(DarkCourutine());
    }
    void Start()
    {
        StartCoroutine(LightCourutine());
    }
   IEnumerator DarkCourutine()
    { 
        Color color = BlackImage.color;
        float startAlpha = color.a;

        // Вычисляем время, прошедшее с начала корутины
        float elapsed = 0f;

        while (elapsed < 2f)
        {
            // Вычисляем интерполированное значение альфы
            color.a = Mathf.Lerp(startAlpha, 1f, elapsed / 2f);
            BlackImage.color = color;

            // Увеличиваем прошедшее время
            elapsed += Time.deltaTime;

            // Ждем следующего кадра
            yield return null;
        }

    }
     IEnumerator LightCourutine()
    { 
        Color color = BlackImage.color;
        float startAlpha = color.a;
        if(startAlpha != 0f){
        float elapsed = 0f;
        while (elapsed < 3f)
        {
            color.a = Mathf.Lerp(startAlpha, 0f, elapsed / 3f);
            BlackImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        }

    }
}
