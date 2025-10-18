using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    public int Damage = 1;

    public virtual void ApplyDamage(IDamagable damagable)
    {
        damagable.TakeDamage(Damage);
    }


    public abstract void Interact();

}
