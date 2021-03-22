using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPositioning : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;

    Transform ui;
    //Image Name;
    Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;

        foreach(Canvas c in FindObjectsOfType<Canvas>())
        {
            if(c.transform.name == "CanvasName")
            {
                ui = Instantiate(uiPrefab, c.transform).transform;
                //Name = ui.GetChild(0).GetComponent<Image>();
            }
        }
    }
    private void LateUpdate()
    {
        ui.position = target.position;
        ui.forward = -cam.forward;
    }
}
