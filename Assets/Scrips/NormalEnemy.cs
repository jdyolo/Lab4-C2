using UnityEngine;

public class NormalEnemy : Entity
{
    private void Awake()
    {
        stats = new BaseStats(70f, 2.5f);

        Debug.Log("NormalEnemy creado con " + stats.GetHealth() + " de vida.");
    }

    public override void TakeDamage(float damage, ElementType element)
    {
        // No tiene resistencia elemental
        stats.TakeDamage(damage);

        Debug.Log("NormalEnemy recibió " + damage + " de daño.");
        Debug.Log("Vida restante: " + stats.GetHealth());

        if (stats.IsDead())
        {
            Debug.Log("NormalEnemy derrotado.");
            Destroy(gameObject);
        }
    }
}