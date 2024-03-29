﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    [SerializeField] Animator _animator;

    private Vector3 velocity = Vector3.zero;
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical") ;
        MovePlayer(horizontalMovement, verticalMovement);
        _animator.SetFloat("Speed", Mathf.Abs(horizontalMovement) + Mathf.Abs(verticalMovement));
    }

    void MovePlayer(float horizontalMovement, float verticalMovement)
    {
        Vector2 movementDirection = new Vector2(horizontalMovement, verticalMovement);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * inputMagnitude * Time.deltaTime, Space.World);

        if (movementDirection != Vector2.zero) {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720f * Time.deltaTime);
        }
    }
}