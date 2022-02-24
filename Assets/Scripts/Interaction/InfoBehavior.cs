using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBehavior : MonoBehaviour
{
    const float SPEED = 6f;

    [SerializeField]
    Transform SecInfo;

    //with gaze//Vector3 desiredScale = Vector3.zero;
    Vector3 desiredScale = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        SecInfo.localScale = Vector3.Lerp(SecInfo.localScale, desiredScale, Time.deltaTime * SPEED);
    }

    void OpenInfo()
    {
        desiredScale = Vector3.one;
    }

    void CloseInfo()
    {
        desiredScale = Vector3.zero;
    }
}
