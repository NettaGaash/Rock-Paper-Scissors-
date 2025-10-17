using UnityEngine;

public abstract class Trap : MonoBehaviour, IDamagable
{
    public int CurrentHp { get; set; }
    public int Damage = 1;

    public virtual void ApplyDamage(IDamagable damagable)
    {
        damagable.TakeDamage(Damage);
    }

    public void Die()
    {
        Debug.Log("Trap destroyed");
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            Die();
        }
    }
}
