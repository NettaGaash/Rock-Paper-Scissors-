using UnityEngine;

public interface IDamagable
{
    int CurrentHp { get; set; }
    void TakeDamage(int damage);
    void Die();

}
