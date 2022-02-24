using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GazeTeleport : MonoBehaviour
{
    public Image imgGaze;
    private float TotalTime=1;
    bool gvrStatus;
    float gvrTimer;
    private int distanceOfRay=100;
    private RaycastHit _hit;
    private GameObject[] cubes;
    public Material newMat;
    public Material oldMat;
    
    void Start(){
        cubes=GameObject.FindGameObjectsWithTag("Teleport");
        //newMat =Resources.Load("Assets/teleportAreaMat.mat",typeof(Material)) as Material;
        //oldMat=Resources.Load("Assets/teleportCube.mat",typeof(Material)) as Material;

    }
    


    // Update is called once per frame
    void Update()
    {
        if(gvrStatus){
            
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
    public void GVROn(){
        gvrStatus=true;
    }
    public void GVROff(){
        gvrStatus=false;
        gvrTimer=0;
        imgGaze.fillAmount=0;
        foreach (GameObject cube in cubes)
        {
            cube.GetComponent<Renderer>().material=oldMat;
        }
    }
}
