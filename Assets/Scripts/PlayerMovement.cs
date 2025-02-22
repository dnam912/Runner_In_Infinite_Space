using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* REFERENCE
 * All Things Game Dev
 * https://youtu.be/qQLvcS9FxnY?si=SDu8JZYDDvXccaVq
 */

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 30f;
    Vector3 movementDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;
    CharacterController characterController;

    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Vector3 left = transform.TransformDirection(Vector3.left);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float cursorSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float cursorSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = movementDirection.y;
        movementDirection = (forward * cursorSpeedX) + (right * cursorSpeedY);
    
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            movementDirection.y = jumpPower;
        } else
        {
            movementDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            movementDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(movementDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
