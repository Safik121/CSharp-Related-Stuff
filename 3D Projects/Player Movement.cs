using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower = 6f;
    private bool isJumping = false;

    public Vector2 turn;

    private Rigidbody rb; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); 
        rb.freezeRotation = true; 

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
            isJumping = true;
        }
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(0, turn.x, 0);  

        Camera.main.transform.localRotation =
            Quaternion.Euler(-turn.y, 0, 0);    
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    }
