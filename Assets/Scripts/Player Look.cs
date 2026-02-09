using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    float xRotation = 0f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -55f, 40f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
