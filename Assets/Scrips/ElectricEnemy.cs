using UnityEngine;

public class ElectricEnemy : Entity
{
    private void Awake()
    {
        stats = new BaseStats(40f, 3f);

        Debug.Log("ElectricEnemy creado con " + stats.GetHealth() + " de vida.");
    }

    public override void TakeDamage(float damage, ElementType element)
    {
        float finalDamage = damage;

        // Resistente a electricidad
        if (element == ElementType.Electric)
        {
            finalDamage *= 0.5f;
            Debug.Log("ElectricEnemy resistió el ataque eléctrico.");
        }

        // Débil al daño normal
        if (element == ElementType.Normal)
        {
            finalDamage *= 2f;
            Debug.Log("ElectricEnemy es débil al daño normal.");
        }

        stats.TakeDamage(finalDamage);

        Debug.Log("ElectricEnemy recibió " + finalDamage + " de daño.");
        Debug.Log("Vida restante: " + stats.GetHealth());

        if (stats.IsDead())
        {
            Debug.Log("ElectricEnemy derrotado.");
            Destroy(gameObject);
        }
    }
}