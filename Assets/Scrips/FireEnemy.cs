using UnityEngine;

public class FireEnemy : Entity
{
    private void Awake()
    {
        stats = new BaseStats(50f, 2f);

        Debug.Log("FireEnemy creado con " + stats.GetHealth() + " de vida.");
    }

    public override void TakeDamage(float damage, ElementType element)
    {
        float finalDamage = damage;

        // Resistente al fuego
        if (element == ElementType.Fire)
        {
            finalDamage *= 0.5f;
            Debug.Log("FireEnemy resistió el ataque de fuego.");
        }

        // Débil al hielo
        if (element == ElementType.Ice)
        {
            finalDamage *= 2f;
            Debug.Log("FireEnemy es débil al hielo.");
        }

        stats.TakeDamage(finalDamage);

        Debug.Log("FireEnemy recibió " + finalDamage + " de daño.");
        Debug.Log("Vida restante: " + stats.GetHealth());

        if (stats.IsDead())
        {
            Debug.Log("FireEnemy derrotado.");
            Destroy(gameObject);
        }
    }
}