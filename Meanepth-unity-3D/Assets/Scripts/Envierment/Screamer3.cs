using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screamer3 : MonoBehaviour
{
    public GameObject Levi;
    public PlayercantMove playercantMove;
    public ScreenFade screenFade;
     public bool IsInteract = true;
    public void Interact()
    {
        SFXManager.instance.PlayScream();
        Levi.SetActive(true);
        playercantMove.Rotate();
        screenFade.FadeToDark();
        StartCoroutine(ChangeSceneAfterDelay());

    }
    IEnumerator ChangeSceneAfterDelay()
    {
        // Ждем указанное количество времени
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Layer4");
    }
}
