using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // https://www.youtube.com/watch?v=Tz-2Z0vLLt8
    [SerializeField] float mouseSensitivity = 250f;
    [SerializeField] float maxViewDistance = -30f;
    [SerializeField] float minViewDistance = 35f;
    [SerializeField]  Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // capture la souris ???
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // The movement is managed with the old input system
        float mouseX = mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse X");
        float mouseY = mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse Y");

        xRotation -= mouseY;
        // Clamp give a value between min and max, replace a if statement
        xRotation = Mathf.Clamp(xRotation, maxViewDistance, minViewDistance);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
