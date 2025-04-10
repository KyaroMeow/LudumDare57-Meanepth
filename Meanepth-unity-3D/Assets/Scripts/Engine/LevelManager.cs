using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int ItemCount;
    public int CurrentItemCount = 0;
    public GameObject wall;
    public GameObject HintWall;
    private int ItemCountHintWall = 1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(CurrentItemCount == ItemCount){
            wall.SetActive(false);
            CurrentItemCount++;
        }
        if(HintWall!=null){
            if(CurrentItemCount == ItemCountHintWall){
                HintWall.SetActive(false);
            }
        }
    }
}
