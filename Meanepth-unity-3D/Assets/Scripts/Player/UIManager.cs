using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public float typingSpeed = 0.1f;
    public float fadeDelay = 2f;
    public TextMeshProUGUI ItemMessage; 
    private string currentText = "";
    private Coroutine TypingCourutine;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartTypingText(string fullText)
    {
        if(TypingCourutine == null){
        TypingCourutine = StartCoroutine(ShowText(fullText));
        }
        else{
            StopCoroutine(TypingCourutine);
            TypingCourutine = null;
            TypingCourutine = StartCoroutine(ShowText(fullText));
        }
    }
    IEnumerator ShowText(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            ItemMessage.text = "";
            currentText += letter;
            ItemMessage.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
         yield return new WaitForSeconds(fadeDelay);
         StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        while (currentText.Length > 0)
        {
            currentText = currentText.Substring(0, currentText.Length - 1);
            ItemMessage.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}
