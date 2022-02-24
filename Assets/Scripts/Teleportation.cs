using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
   private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

   public void TeleportPlayer(){
       player.transform.position=new Vector3(transform.position.x,transform.position.y+1.5f,transform.position.z);
   }
}
