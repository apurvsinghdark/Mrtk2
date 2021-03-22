using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectTouch : MonoBehaviour
{
    private float hori;
    private float vert;
    private float horozontalSpeed = 0.75f;
    private Touch touch;
    private bool active;
    void Update()
    {
        if(!active)
        {
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    hori = Mathf.Clamp(horozontalSpeed * touch.deltaPosition.x, -30.0f, 30.0f);
                    vert = Mathf.Clamp(horozontalSpeed * touch.deltaPosition.y, -30.0f, 30.0f);
                    
                    
                    transform.Rotate( 0, -hori, 0.0f, Space.Self);
                    transform.Rotate( vert, 0, 0.0f, Space.World);
                    
                }
            }
            //this.transform.eulerAngles.x = Mathf.Clamp(transform.eulerAngles.x, -90f, 90f);
        }
    }
    public void StopRotate()
    {
        print ("Stop rotating, damn you!");
        active = !active;
    }
}
