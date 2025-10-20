using System;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour, IDamagable

{
    public int Damage = 1;
    private InputHandler input;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    protected LayerMask specialAbilityLayerMask;

    [SerializeField]
    protected float specialAbilityDistance = 5;


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


    public int MaxHp = 3;
    public int CurrentHp { get; set; }

    void ApplyDamage(IDamagable damagable)
    {
        damagable.TakeDamage(Damage);
    }

    public void Die()
    {
        Debug.Log("You Died");
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    public virtual void SpecialAbility()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, specialAbilityDistance, specialAbilityLayerMask))
        {
            Trap hitTrap = hitInfo.transform.GetComponentInParent<Trap>();
            hitTrap.Interact();
        }
    }
}
