using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVRInteraction : MonoBehaviour
{
    
    bool gvrStatus;

    const float SPEED = 6f;

    [SerializeField]
    Transform SecInfo;

    //with gaze//Vector3 desiredScale = Vector3.zero;
    Vector3 desiredScale = Vector3.one;

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            SecInfo.localScale = Vector3.Lerp(SecInfo.localScale, desiredScale, Time.deltaTime * SPEED);
        }
       
    }
    public void GvrOn()
    {
        gvrStatus = true;
    }
    public void GvrOff()
    {
        gvrStatus = false;
        
    }
}
