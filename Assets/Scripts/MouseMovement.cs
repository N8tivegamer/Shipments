using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse y") * mouseSensitivity * Time.deltaTime;

        // Roation around the X axis (Look up and down)
       xRotation -= mouseY;

        //Clamp the roation
        xRotation = Mathf.Clamp(xRotation, 90f, 90f);

        // Roation around the y axis (Look left and right)
        xRotation += mouseX;

        // Apply
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

       
    }

}
