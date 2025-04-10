using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screamer3 : MonoBehaviour
{
    public GameObject Levi;
    public PlayercantMove playercantMove;
    public ScreenFade screenFade;
    [HideInInspector]
    public bool IsInteract = true;
    public GameObject hintCanvas;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&&IsInteract){
            hintCanvas.SetActive(true);
        }
    }
     void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            hintCanvas.SetActive(false);
        }
    }
    public void Interact()
    {
        if(IsInteract){
        SFXManager.instance.PlayScream();
        Levi.SetActive(true);
        playercantMove.Rotate();
        screenFade.FadeToDark();
        StartCoroutine(ChangeSceneAfterDelay());
        hintCanvas.SetActive(false);
        IsInteract = false;
        }

    }
    IEnumerator ChangeSceneAfterDelay()
    {
        // Ждем указанное количество времени
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Layer4");
    }
}
