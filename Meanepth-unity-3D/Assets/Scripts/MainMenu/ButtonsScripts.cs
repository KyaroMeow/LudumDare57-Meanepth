using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsScripts : MonoBehaviour
{
    void Start()
    {
        if(Cursor.lockState == CursorLockMode.Locked){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public Animator CameraAnimator;
    public Slider VolumeValue;
    public Slider SensitivityValue;
    public void SetVolume()
    {
        SettingsManager.instance.volume = VolumeValue.value;
    }
    public void SetSesitivity()
    {
        SettingsManager.instance.Sensitivity = SensitivityValue.value;
    }
    public void OpenSettings(){
        CameraAnimator.SetTrigger("Rotate");
    }
    public void CloseSettings(){
        CameraAnimator.SetTrigger("RotateBack");
    }
    public void Exit(){
        Application.Quit();
    }
    public void StartGame(){
        SceneManager.LoadScene("Layer1");
    }

}
