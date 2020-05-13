using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    
    
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        yRotation -= mouseX;
        
        //yRotation = Mathf.Clamp(yRotation, -360, 360);
        transform.localRotation = Quaternion.Euler(0, yRotation * -1, 0f);
        //playerBody.Rotate(Vector3.up * mouseX);
    }
}
