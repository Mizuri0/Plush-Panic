using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXlimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector.3forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        bool isRunning = Input.getKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) * (right * curSpeedY);

        #endregion
    }
}
    #region Handles Jumping
    if (Input. Getbutton("Jump") && eanmove && characterController.isGrounded)
    {
        moveDirection.y= jumpPower;
    }
    else
    {
        MoveDirection.y = movementDirectionY;
    }
    
    if (!characterController.isGrounded)
    {
        movedirection.y -= gravity * Time.deltaTime;
    }

    #endregion
    