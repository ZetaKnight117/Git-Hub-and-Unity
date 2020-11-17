using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidBodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accerationForce = 10;

    [SerializeField]
    private float maxSpeed = 2f;

    private Vector3 moveVec;
    public void OnMove(InputAction.CallbackContext input)
    {
        Vector2 inputVec = input.ReadValue<Vector2>();

        moveVec = new Vector3(inputVec.x, 0, inputVec.y);
    }

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        var inputDirection = moveVec;
            //new Vector3(input.x, 0, input.y);


        if (rigidbody.velocity.magnitude < maxSpeed)
        {
          rigidbody.AddForce(inputDirection * accerationForce, ForceMode.Acceleration);
        }       
       
    }

    private void Update()
    {
       // input.x = Input.GetAxisRaw("Horizontal");
       // input.y = Input.GetAxisRaw("Vertical");

    }
}
