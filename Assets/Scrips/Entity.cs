using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected BaseStats stats;

    public float GetHealth()
    {
        return stats.GetHealth();
    }

    public float GetSpeed()
    {
        return stats.GetSpeed();
    }

    public bool IsDead()
    {
        return stats.IsDead();
    }

    public abstract void TakeDamage(float damage, ElementType element);
}