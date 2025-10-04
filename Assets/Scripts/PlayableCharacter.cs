using System;
using TMPro;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour, IDamagable
    
{
    private InputHandler input;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Camera camera;
    private void Awake()
    {
        input = GetComponent<InputHandler>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var TargetVector = new Vector3(input.inputVector.x, 0, input.inputVector.y);

        // Move in the direction we are aiming
        var movementVector = MoveTowardTarget(TargetVector);

        // Rotate in the direction we are traveling
        RotateTowardMovementVector(movementVector);
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
     
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    public int Health { get; set; }

    public void Die()
    {
       
    }

    public void TakeDamage(int damage)
    {
        
    }
}
