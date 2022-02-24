using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVRButtonInteraction : MonoBehaviour
{
    public Image imgCircle;
    public UnityEvent GVRClick;
    public float totalTime = 2;
    bool gvrStatus;
    public float gvrTimer;

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
            gvrTimer += Time.deltaTime;
            imgCircle.fillAmount = gvrTimer / totalTime;
        }
        if (gvrTimer > totalTime)
        {
            GVRClick.Invoke();

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
        gvrTimer = 0;
        imgCircle.fillAmount = 0;
    }
}
