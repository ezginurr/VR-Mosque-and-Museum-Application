using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MuseumInteraction : MonoBehaviour
{
    
    bool gvrStatus;

    [SerializeField]
    Transform InteractionObject;
    [SerializeField]
    Transform player;


    // Update is called once per frame
    void Update()
    {
        
        if (gvrStatus)
        {
            player.transform.position = InteractionObject.transform.position;
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