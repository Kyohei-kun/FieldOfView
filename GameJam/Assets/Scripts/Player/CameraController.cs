using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] [Range(-90, 0)] private float minAngle;
    [SerializeField] [Range(0, 90)] private float maxAngle;

    private Transform cameraHolder;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cameraHolder = transform.Find("CameraHolder");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RotateWithMouse();
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime   ;

        xRotation += -mouseY;
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

        cameraHolder.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
