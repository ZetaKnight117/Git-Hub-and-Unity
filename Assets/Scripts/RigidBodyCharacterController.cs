using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidBodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accerationForce = 10;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicalMaterial;

    [SerializeField]
    private float maxSpeed = 2f;
    private new Rigidbody rigidbody;
    private Vector2 input;
    private object cameraRelativeInputDirection;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);
       
        Vector3 cameraFlattenedForward = Camera.main.transform.forward;
        cameraFlattenedForward.y = 0;
        var cameraRotation = Quaternion.LookRotation(cameraFlattenedForward);

        Vector3 cameraRelativeInputDirection = cameraRotation * inputDirection;
        if(rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(inputDirection * accerationForce, ForceMode.Acceleration);
        } 
        
       //if (cameraRelativeInputDirection.magnitude > 0) 
        //{
          //  var target
        //}
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }
   
}
