using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartCutScene : MonoBehaviour
{
   public GameObject Scope;
   public TextMeshProUGUI PlayerChat;
   public string Text;
   public Image BlackImage;
   public PlayerController player;
    void Start()
    {
        player.canMove = false;
        PlayerChat.color = Color.white;
        StartCoroutine(StartCutSceneSequence());
    }
    IEnumerator StartCutSceneSequence()
    {
        yield return StartCoroutine(ShowText(Text));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeText());
        StartCoroutine(LightCourutine());
        player.canMove = true;
        PlayerChat.color = Color.black;
        Scope.SetActive(true);
    }
    IEnumerator FadeText()
    {
        string currentText = PlayerChat.text;
        while (currentText.Length > 0)
        {
            currentText = currentText.Substring(0, currentText.Length - 1);
            PlayerChat.text = currentText;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator ShowText(string text)
    {
        string currentText = "";
        foreach (char letter in text.ToCharArray())
        {
            currentText += letter;
            PlayerChat.text = currentText;
            yield return new WaitForSeconds(0.1f);
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
            color.a = Mathf.Lerp(startAlpha, 0f, elapsed / 2f);
            BlackImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        }

    }
}
