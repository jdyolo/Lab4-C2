using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float speed = 5f;

    [Header("Ataque")]
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float attackInterval = 1.5f;
    [SerializeField] private ElementType attackElement = ElementType.Fire;

    private int experience = 0;
    private float nextAttackTime;

    private void Awake()
    {
        stats = new BaseStats(maxHealth, speed);

        Debug.Log("Player creado.");
        Debug.Log("Vida: " + stats.GetHealth());
    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            AttackNearbyEnemies();
            nextAttackTime = Time.time + attackInterval;
        }
    }

    private void AttackNearbyEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            transform.position,
            attackRange
        );

        foreach (Collider2D col in colliders)
        {
            Entity entity = col.GetComponent<Entity>();

            if (entity != null && entity != this)
            {
                entity.TakeDamage(attackDamage, attackElement);

                Debug.Log(
                    "Player atacó a " + entity.gameObject.name +
                    " con " + attackElement
                );
            }
        }
    }

    public override void TakeDamage(float damage, ElementType element)
    {
        stats.TakeDamage(damage);

        Debug.Log("Player recibió " + damage + " de daño.");
        Debug.Log("Vida del Player: " + stats.GetHealth());

        if (stats.IsDead())
        {
            Debug.Log("Player derrotado.");
        }
    }

    public void Heal(float amount)
    {
        stats.Heal(amount);

        Debug.Log("Player recuperó " + amount + " de vida.");
        Debug.Log("Vida actual: " + stats.GetHealth());
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        Debug.Log("XP obtenida: " + amount);
        Debug.Log("XP total: " + experience);
    }

    public int GetExperience()
    {
        return experience;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}