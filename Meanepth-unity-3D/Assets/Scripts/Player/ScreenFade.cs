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
        float elapsed = 0f;
        while (elapsed < 2f)
        {
            // Вычисляем интерполированное значение альфы
            color.a = Mathf.Lerp(startAlpha, 1f, elapsed / 2f);
            BlackImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

    }
     IEnumerator LightCourutine()
    { 
        Color color = BlackImage.color;
        float startAlpha = color.a;
        if(startAlpha != 0f){
        float elapsed = 0f;
        while (elapsed < 4f)
        {
            color.a = Mathf.Lerp(startAlpha, 0f, elapsed / 4f);
            BlackImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        }

    }
}
