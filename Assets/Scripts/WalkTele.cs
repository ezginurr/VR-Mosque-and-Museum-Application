using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WalkTele : MonoBehaviour
{
    public Image imgGaze;
    private float TotalTime=1;
    bool gvrStatus;
    bool teleport;
    float gvrTimer;
    private int distanceOfRay=100;
    private RaycastHit _hit;
    private GameObject[] cubes;
    public Material newMat;
    public Material oldMat;
    public float speed =1.1f;
    private float gravity= 10f;
    private CharacterController controller;
    
    void Start(){
        controller=GetComponent<CharacterController>();
        cubes=GameObject.FindGameObjectsWithTag("Teleport");
        teleport=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(teleport){
            if(gvrStatus){
                Debug.Log("teleporta geçiş");
                foreach (GameObject cube in cubes)
                {
                    cube.GetComponent<Renderer>().material=newMat;
                }
                
                gvrTimer+=Time.deltaTime;
                imgGaze.fillAmount=gvrTimer/TotalTime;
                
            }
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0.5f));
            if(Physics.Raycast(ray,out _hit,distanceOfRay)){
            
                if(imgGaze.fillAmount==1 && _hit.transform.CompareTag("Teleport")){
                    _hit.transform.gameObject.GetComponent<Teleportation>().TeleportPlayer();
                }
            }
        }
        else{
            Debug.Log(gvrStatus);
            Debug.Log("player movement açık");
            PlayerMovement();
        }
    }
    public void GVROn(){
        gvrStatus=true;
        teleport=true;
    }
    public void GVROff(){
        gvrStatus=false;
        teleport=false;
        gvrTimer=0;
        imgGaze.fillAmount=0;
        foreach (GameObject cube in cubes)
        {
            cube.GetComponent<Renderer>().material=oldMat;
        }
    }
    void PlayerMovement(){
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        Vector3 direction=new Vector3(horizontal,0,vertical);
        Vector3 velocity=direction*speed;
        velocity=Camera.main.transform.TransformDirection(velocity);
        velocity.y-=gravity;
        controller.Move(velocity*Time.deltaTime);
    }
}
