using UnityEngine;

public abstract class Trap : MonoBehaviour, IDamagable
{
    public int Health { get; set; }
    public int Damage = 1;

    void ApplyDamage(IDamagable damagable)
    {
        damagable.TakeDamage(Damage);
    }

    public void Die()
    {
        Debug.Log("Trap destroyed");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
       if (Health <= 0)
        {
            Die();
        }
    }
}
