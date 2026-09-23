using UnityEngine;

public class IceEnemy : Entity
{
    private void Awake()
    {
        stats = new BaseStats(60f, 1.5f);

        Debug.Log("IceEnemy creado con " + stats.GetHealth() + " de vida.");
    }

    public override void TakeDamage(float damage, ElementType element)
    {
        float finalDamage = damage;

        // Resistente al hielo
        if (element == ElementType.Ice)
        {
            finalDamage *= 0.5f;
            Debug.Log("IceEnemy resistió el ataque de hielo.");
        }

        // Débil al fuego
        if (element == ElementType.Fire)
        {
            finalDamage *= 2f;
            Debug.Log("IceEnemy es débil al fuego.");
        }

        stats.TakeDamage(finalDamage);

        Debug.Log("IceEnemy recibió " + finalDamage + " de daño.");
        Debug.Log("Vida restante: " + stats.GetHealth());

        if (stats.IsDead())
        {
            Debug.Log("IceEnemy derrotado.");
            Destroy(gameObject);
        }
    }
}