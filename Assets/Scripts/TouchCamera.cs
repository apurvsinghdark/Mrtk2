﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCamera : MonoBehaviour
{
    public bool canPan = true;
    public bool canScale = true;

    public MouseSettings mouseSettings = new MouseSettings(0, 0.5f, 10);

    public Range angleRange = new Range(-89, 89);
    public Range distanceRange = new Range(1, 1000);

    //around center
    public Transform target;
    public Vector3 offset;

    private Vector2 oldPos1;
    private Vector2 oldPos2;

    private bool m_isSinleFinger;

    private Vector3 targetPan;
    private Vector3 currentPan;

    private Vector2 targetAngles;
    private Vector2 currentAngles;

    private float targetDistance;
    private float currentDistance;

    private bool getCurrentDA = true;

    //Damper (damping) for move and rotate
    [Range(0, 10)]
    [SerializeField] private float damper = 0.5f;

    void Start()
    {
        GameObject camTargetObj = GameObject.Find("Main Camera Target");
        if (camTargetObj == null)
            camTargetObj = new GameObject("Main Camera Target");
        target = camTargetObj.transform ;

        currentAngles = targetAngles = transform.eulerAngles;
        currentPan = targetPan = transform.position + offset;
        currentDistance = targetDistance = Vector3.Distance(transform.position + offset, target.position + offset);
    }

    void Update()
    {
        if (Input.touchCount <= 0)
        {
            getCurrentDA = true;
            return;
        }
        else
        {
            //  Make sure to get the latest Camera status
            if (getCurrentDA)
            {
                getCurrentDA = false;
                currentAngles = targetAngles = transform.eulerAngles;
                currentDistance = targetDistance = Vector3.Distance(transform.position + offset, target.position + offset);
                if (Camera.main.orthographic)
                {
                    currentPan = targetPan = transform.position + offset ;
                    currentDistance = targetDistance = Camera.main.orthographicSize;
                }
            }
        }
        
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);
                //rotate
                if (!Camera.main.orthographic)
                {
                    targetAngles.y += touch.deltaPosition.x * mouseSettings.pointerSensitivity;
                    targetAngles.x -= touch.deltaPosition.y * mouseSettings.pointerSensitivity;

                    targetAngles.x = ClampAngle(targetAngles.x, angleRange.min, angleRange.max);

                    currentAngles = Vector2.Lerp(currentAngles, targetAngles, damper * Time.deltaTime);
                    //rotate of target
                    Quaternion rotation = Quaternion.Euler(currentAngles);
                    Vector3 newPosition =  target.position + rotation * Vector3.back * currentDistance;
                    transform.position = newPosition;
                    transform.rotation = rotation;
                }
                else
                {
                    //Pan
                    if (canPan)
                    {
                        targetPan.x -= touch.deltaPosition.x/10;
                        targetPan.z -= touch.deltaPosition.y/10;
                        currentPan = Vector3.Lerp(currentPan, targetPan, (damper) * Time.deltaTime);
                        transform.position = targetPan;
                    }
                }

            }
            m_isSinleFinger = true;
        }

        //mouse scrollewheel zoom
        if (canScale)
        {
            if (Input.touchCount > 1)
            {
                if (m_isSinleFinger)
                {
                    oldPos1 = Input.GetTouch(0).position;
                    oldPos2 = Input.GetTouch(1).position;
                }

                if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    var tempPos1 = Input.GetTouch(0).position;
                    var tempPos2 = Input.GetTouch(1).position;

                    float currentTouchDistance = Vector3.Distance(tempPos1, tempPos2);
                    float lastTouchDistance = Vector3.Distance(oldPos1, oldPos2);

                    targetDistance -= (currentTouchDistance - lastTouchDistance) * Time.deltaTime * mouseSettings.wheelSensitivity;


                    targetDistance = Mathf.Clamp(targetDistance, distanceRange.min, distanceRange.max);
                    currentDistance = Mathf.Lerp(currentDistance, targetDistance, damper * Time.deltaTime);

                    if(Camera.main.orthographic)
                        Camera.main.orthographicSize = currentDistance;
                    else 
                        transform.position = target.position - transform.forward * currentDistance;


                    oldPos1 = tempPos1;
                    oldPos2 = tempPos2;
                    m_isSinleFinger = false;
                }
            }
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }


    // void OnGUI()
    // {
    //     GUI.color = Color.black;
    //     GUI.Label(new Rect(50, 120, 200, 30), "targetAngles: " + targetAngles.ToString());
    //     GUI.Label(new Rect(50, 140, 200, 30), "currentAngles: " + currentAngles.ToString());
    //     GUI.Label(new Rect(50, 160, 200, 30), "targetDistance: " + targetDistance.ToString());
    //     GUI.Label(new Rect(50, 180, 200, 30), "currentDistance: " + currentDistance.ToString());
    //     GUI.Label(new Rect(50, 200, 200, 30), "targetPan: " + targetPan.ToString());
    //     GUI.Label(new Rect(50, 220, 200, 30), "currentPan: " + currentPan.ToString());
    //     GUI.Label(new Rect(50, 240, 200, 30), "targetPosition: " + target.position.ToString());
    //     GUI.Label(new Rect(50, 260, 200, 30), "rotation: " + transform.rotation.ToString());
    //     GUI.Label(new Rect(50, 280, 200, 30), "position: " + transform.position.ToString());
    // }
}
public struct MouseSettings
{
    public int mouseButtonID;
    public float pointerSensitivity;
    public float wheelSensitivity;

    public MouseSettings(int mouseButtonID, float pointerSensitivity, float wheelSensitivity)
    {
        this.mouseButtonID = mouseButtonID;
        this.pointerSensitivity = pointerSensitivity;
        this.wheelSensitivity = wheelSensitivity;
    }
}

public struct Range
{
    public float min;
    public float max;

    public Range(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}

