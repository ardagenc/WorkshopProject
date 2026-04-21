using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    [Header("GroundCheck Parameters")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Vector2 groundCheckSize;
    [SerializeField] Transform groundCheck;

    [Header("Component References")]
    [SerializeField] private Rigidbody2D rb;

    private float moveInput;
    InputSystemActions inputActions;



    public bool IsGrounded { get; private set; }
    public Vector2 PlayerVelocity => rb.linearVelocity;

    private void Awake()
    {
        inputActions = new InputSystemActions();
        inputActions.Player.Enable();

        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;

        inputActions.Player.Jump.performed += OnJump;
        inputActions.Player.Jump.canceled += OnJump;
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();

        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;

        inputActions.Player.Jump.performed -= OnJump;
        inputActions.Player.Jump.canceled -= OnJump;
    }
    private void OnMove(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>().x;

        if (moveInput != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(moveInput) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    private void OnJump(InputAction.CallbackContext value)
    {
        if (inputActions.Player.Jump.WasPressedThisFrame())
        {
            //Jump
            Jump();
        }                
    }
    private void FixedUpdate()
    {
        GroundCheck();
        Move();
    }

    private void Move()
    {
        rb.linearVelocityX = moveInput * moveSpeed;
    }

    private void Jump()
    {
        if (IsGrounded)
        {
            rb.linearVelocityY = jumpForce;
        }
    }

    private void GroundCheck()
    {
        IsGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);
    }
    void OnDrawGizmos()
    {
        if (groundCheck == null) return;

        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }

}
