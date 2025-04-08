using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public PlayerController player;
    public GameObject scope;
    public Slider volumeSlider;
    public Slider sensitivitySlider;
    
    void OnEnable()
    {
        Time.timeScale = 0f;
        player.canMove = false;
        scope.SetActive(false);
        if(SettingsManager.instance != null)
        {
            Debug.Log("Settings != null");
            volumeSlider.value = SettingsManager.instance.volume;
            sensitivitySlider.value = SettingsManager.instance.Sensitivity;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void OnDisable()
    {
        Time.timeScale = 1f;
        scope.SetActive(true);
        player.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void SetVolume(){
        SettingsManager.instance.volume = volumeSlider.value;
    }
    public void SetSensitivity(){
        SettingsManager.instance.Sensitivity = sensitivitySlider.value;
        player.lookSpeed = sensitivitySlider.value;
    }
    public void Exit(){
        SceneManager.LoadScene("Menu");
    }
    public void Continue(){
        gameObject.SetActive(false);
    }
}
