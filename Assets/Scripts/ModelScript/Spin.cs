using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Spin : MonoBehaviour
{
    private Camera cam;
    private Vector3 touchPos;
    private Vector3 touchWorldPos;
    private bool bottleTouch;
    private float spinSpeed;
    private float spinAdd;
    private float orientation;
    private float positionDelta;
 
    public GameObject promptMenu;
    public GameObject promptMenuNormal;
    public GameObject backButton;
    public GameObject backButtonNormal;
    public bool spinning;
    public float angle;
 
    void Start(){
        cam = Camera.main;
    }
    void Update(){
        RotateObject();
        FreeSpinning();
    }
    void RotateObject(){
        //if touching the screen
        if(Input.touchCount == 1 && !spinning){
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
 
            //only move bottle if touch is on bottle
            if (Physics.Raycast(ray, out hit, 100)){
                if(hit.transform.name == "Top") {
                    bottleTouch = true;
                    orientation = 90;
                }
                if(hit.transform.name == "Buttom") {
                    bottleTouch = true;
                    orientation = 270;
                }
            }
 
            //if touch is on bottle
            if(bottleTouch){
                //get touch position and convert to world position
                touchPos = touch.position;
                touchPos.z = cam.transform.position.y - transform.position.y;  
                touchWorldPos = cam.ScreenToWorldPoint(touchPos);  
 
                //get angle from object to touch
                angle = -Mathf.Atan2(transform.position.z - touchWorldPos.z, transform.position.x - touchWorldPos.x) * Mathf.Rad2Deg - orientation;
                //rotate based on angle
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, -90), 1000 * Time.deltaTime);
            }
 
            //if touch ended
            if(touch.phase == TouchPhase.Ended && bottleTouch == true){
                bottleTouch = false;
                spinning = true;
 
                positionDelta = touch.deltaPosition.x * touch.deltaPosition.y * Time.deltaTime / 10;
               
                //limit spin speed
                if(positionDelta > 10){
                    positionDelta = 10;
                }
                if(positionDelta < 2 && positionDelta > 0){
                    positionDelta = 5;
                }
                if(positionDelta < -10){
                    positionDelta = -10;
                }
                if(positionDelta > -2 && positionDelta < 0){
                    positionDelta = -5;
                }
                if(positionDelta == 0){
                    spinning = false;
                }
            }
        }
    }
 
    void FreeSpinning(){
        if(!bottleTouch && spinning){
            //stop the bottle after spin
            if(positionDelta < 0.1f && positionDelta > 0){
                positionDelta = 0;
                StartCoroutine("Prompt");
            }
            if(positionDelta > -0.1f && positionDelta < 0){
                positionDelta = 0;
                StartCoroutine("Prompt");
            }
 
            //add freespin rotation
            transform.Rotate(positionDelta, 0, 0);
 
            //decrease speed in both directions
            if(positionDelta > 0){
                positionDelta -= 1f * Time.deltaTime;
            }
            if(positionDelta < 0){
                positionDelta += 1f * Time.deltaTime;
            }
        }
    }
 
    //choose if truth or dare
    private IEnumerator Prompt(){
        yield return new WaitForSeconds (1f);
 
        promptMenu.SetActive(true);
        promptMenuNormal.SetActive(true);
 
        backButton.SetActive(false);
        backButtonNormal.SetActive(false);
 
        this.gameObject.SetActive(false);
    }
}