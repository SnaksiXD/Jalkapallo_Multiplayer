using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseLook : MonoBehaviour
{
    public CursorLockMode mode;

    public float mouseSensitivity = 200f;
    public float minXAngle = -80f;
    public float maxXAngle = 90f;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

    CinemachineVirtualCamera virtualCamera;
    Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.transform.parent;
        Cursor.lockState = mode;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXAngle,maxXAngle);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
