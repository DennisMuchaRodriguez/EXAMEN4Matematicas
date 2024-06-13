using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    private Rigidbody _compRigidbody;
    public float speed;
    private float MovementX;
    public float JumpingPower = 10;
    public int maxJumps = 2;
    private int jumpsRemaining;
    public float raycastDistance = 1f;
    public LayerMask collisionMask;
    public int LayerMaskDistance;
    private float DirectionY;
    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();

    }
    void Start()
    {
        
    }

    
    void Update()
    {
      
        if (jumpsRemaining > 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _compRigidbody.AddForce(Vector3.up * JumpingPower * DirectionY, ForceMode.Impulse);
                jumpsRemaining = jumpsRemaining - 1;
            }
        }

     
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, collisionMask))
        {
            jumpsRemaining = maxJumps;
        }
    }
    
    private void FixedUpdate()
    {

        _compRigidbody.AddForce(Vector3.right * MovementX * speed, ForceMode.VelocityChange);
    }

    public void OnMovementX(InputAction.CallbackContext context)
    {
        MovementX = context.ReadValue<float>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        DirectionY = context.ReadValue<float>();
    }
}
