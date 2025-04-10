using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour
{
    public void GoToMenu(){
    SceneManager.LoadScene("Menu");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            GoToMenu();
        }
    }
}
