using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    // CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        // characterController = GetComponent<CharacterController>();
        //rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        // Player and Camera rotation
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
            }
            if (Input.GetMouseButton(0))
            {
                rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
                rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, rotation.y, 0);
                //transform.eulerAngles = new Vector2(0, rotation.y);
            }
        }
    }
}
