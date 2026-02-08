using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 20f;

    public Rigidbody rb;

    private Vector3 moveDirection;

    private void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up *mouseX * rotateSpeed * Time.deltaTime);    
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection = transform.right * x + transform.forward * z;
        moveDirection = moveDirection.normalized;
        rb.linearVelocity = new Vector3( moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);

        rb.angularVelocity = Vector3.zero;
    }
}
