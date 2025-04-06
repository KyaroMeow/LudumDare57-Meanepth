using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeZone : MonoBehaviour
{

    public float timeToVoicesInHead = 120f;
    public float timeToScreenShake = 180f;
    public float timeToRedScreen = 240f;
    private Collider zone;
    private bool isPlayerInArea = false;
    private float timer = 0f;
    private GameObject Player;
    private bool IsVoiceCourutine = false;
    private bool IsRedCourutine = false;
    private bool IsShakeCourutine = false;

    // Start is called before the first frame update
    void Start()
    {
        zone = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
         if (isPlayerInArea)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if(timer >  timeToVoicesInHead && !IsVoiceCourutine)
            {
                IsVoiceCourutine = true;
                Player.GetComponent<VoicesInHead>().StartFadeIn();
            }
            if(timer >  timeToScreenShake && !IsShakeCourutine)
            {
                IsShakeCourutine = true;
                Player.GetComponent<ScreenShake>().StartShake();
            }
            if(timer >  timeToRedScreen && !IsRedCourutine)
            {
                IsRedCourutine = true;
                Player.GetComponent<RedScreen>().StartRed();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInArea = true;
            Debug.Log("Игрок вошел в область. Секундомер запущен.");
            Player = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsRedCourutine = false;
            IsVoiceCourutine = false;
            IsShakeCourutine = false;
            isPlayerInArea = false;
            timer = 0f;
            Debug.Log("Игрок покинул область. Секундомер остановлен.");
            Player.GetComponent<RedScreen>().StopRed();
            Player.GetComponent<VoicesInHead>().StopFade();
            Player.GetComponent<ScreenShake>().StopShake();
            Player = null;
        }
    }

}
