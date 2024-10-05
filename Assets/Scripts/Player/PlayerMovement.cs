using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private Transform playerBody;

    [SerializeField] private Rigidbody playerRigidbody;

    [Header("Movement Speed")]
    [SerializeField] private float playerSpeed;

    private Vector3 movementInput;

    private void Start()
    {
        if(playerRigidbody == null) 
        {
            playerRigidbody = GetComponentInChildren<Rigidbody>();
        }
    }

    public void MovementLogic() 
    {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 movementVector = transform.TransformDirection(movementInput) * playerSpeed;

        playerRigidbody.velocity = new Vector3(movementVector.x, playerRigidbody.velocity.y, movementVector.z);
    }
}
