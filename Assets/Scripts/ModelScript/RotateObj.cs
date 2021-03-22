using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rigidbody;
    private Camera m_camera;


    private void Awake()
    {
        m_camera = Camera.main;
    }

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag() {
        dragging = true;    
    }

    private void Update() {
        
        if(Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    private void FixedUpdate() {
        if(dragging)
        {
            // float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            // float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

            // rigidbody.AddTorque (Vector3.down * x);
            // rigidbody.AddTorque (Vector3.right * y);

            float XaxisRotation = Input.GetAxis("Mouse X")*rotationSpeed;
	        float YaxisRotation = Input.GetAxis("Mouse Y")*rotationSpeed;
	        // select the axis by which you want to rotate the GameObject
	        transform.RotateAroundLocal (Vector3.down, XaxisRotation);
	        transform.RotateAround (Vector3.right, YaxisRotation);
        }
    }
}