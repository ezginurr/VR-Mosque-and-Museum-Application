﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeTimerInteractor : MonoBehaviour
{
    public Image imgGaze;
    public float TotalTime=2;
    bool gvrStatus;
    float gvrTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus){
            gvrTimer+=Time.deltaTime;
            imgGaze.fillAmount=gvrTimer/TotalTime;
        }
    }
    public void GVROn(){
        gvrStatus=true;
    }
    public void GVROff(){
        gvrStatus=false;
        gvrTimer=0;
        imgGaze.fillAmount=0;
    }
}
