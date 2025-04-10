using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalCutScene : MonoBehaviour
{
    public string Text;
    public TextMeshProUGUI PlayerChat;
    public GameObject skipText;
    public Image whiteImage; // Ссылка на белую картинку
    public PlayerController playerController; // Ссылка на контроллер игрока
    public Transform targetCameraPosition; // Заготовленная точка для камеры
    public Camera mainCamera; // Ссылка на основную камеру
    public float moveSpeed = 2.0f; // Скорость перемещения камеры
    public float fadeDuration = 1.0f; // Длительность затухания/нарастания
    public Quaternion targetCameraRotation; // Целевой поворот камеры
    private bool canSkip = false;

void Update()
{
    if(canSkip){
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.KeypadEnter)){
            SceneManager.LoadScene("Titrs");
        }
    }
}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.canMove = false;
            StartCoroutine(FinalCutSceneSequence());
        }
    }

    IEnumerator FinalCutSceneSequence()
    {
        // Плавно нарастаем альфу белой картинки
            StartCoroutine(FlashCourutine());

        // Перемещаем и поворачиваем камеру
        if (mainCamera != null)
        {
            yield return StartCoroutine(MoveAndRotateCamera());
        }
        else
        {
            Debug.LogError("Main Camera is not assigned.");
        }
        yield return StartCoroutine(ShowText(Text));
        canSkip = true;
        skipText.SetActive(true);
    }

    IEnumerator MoveAndRotateCamera()
{
    if (targetCameraPosition == null)
    {
        Debug.LogError("Target Camera Position is not assigned.");
        yield break;
    }

    // Получаем начальную позицию и поворот камеры
    Vector3 startPosition = mainCamera.transform.position;
    // Получаем целевую позицию и поворот
    Vector3 endPosition = targetCameraPosition.position;
    Quaternion endRotation = targetCameraRotation;

    float startTime = Time.time;

    while (Vector3.Distance(mainCamera.transform.position, endPosition) > 0.1f || Quaternion.Angle(mainCamera.transform.rotation, endRotation) > 0.1f)
    {
        // Перемещение
        float journeyLength = Vector3.Distance(startPosition, endPosition);
        float distCovered = (Time.time - startTime) * moveSpeed;
        float fractionOfJourney = distCovered / journeyLength;
        mainCamera.transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);

        // Поворот в мировых координатах
        mainCamera.transform.rotation = Quaternion.RotateTowards(mainCamera.transform.rotation, endRotation, moveSpeed * 100f * Time.deltaTime);
        Debug.Log("CameraRotation:" + mainCamera.transform.rotation.ToString());

        yield return null;
    }

    // Устанавливаем точное положение и поворот камеры
    mainCamera.transform.position = endPosition;
    mainCamera.transform.rotation = endRotation;
    Debug.Log("Camera movement and rotation completed.");
}


    
    IEnumerator LightCourutine()
    { 
        Debug.Log("норм");
        Color color = whiteImage.color;
        float startAlpha = color.a;
        float elapsed = 0f;
        while (elapsed < 2f)
        {
            color.a = Mathf.Lerp(startAlpha, 0f, elapsed / 2f);
            whiteImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        //UIManager.instance.StartTypingText(Text);
       
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

    
    IEnumerator FlashCourutine()
    { 
        Color color = whiteImage.color;
        float startAlpha = color.a;
        float elapsed = 0f;
        while (elapsed < 2f)
        {
            color.a = Mathf.Lerp(startAlpha, 1f, elapsed / 1f);
            whiteImage.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(LightCourutine()); 
    }
}
