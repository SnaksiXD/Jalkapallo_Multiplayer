using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

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
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.transform.parent;
        Cursor.lockState = mode;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        view = playerBody.GetComponent<PhotonView>();
        if(!view.IsMine)
        {
            virtualCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
