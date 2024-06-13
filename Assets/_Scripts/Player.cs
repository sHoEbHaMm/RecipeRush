using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameInput gameInput;

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 inputVector = gameInput.GetInputVectorNormalized();
        Vector3 movementDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.forward = Vector3.Slerp(transform.forward, movementDirection, rotationSpeed * Time.deltaTime);
        transform.position += movementDirection * movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        
    }
}
