public class BaseStats
{
    private float health;
    private float maxHealth;
    private float speed;

    public BaseStats(float health, float speed)
    {
        this.maxHealth = health;
        this.health = health;
        this.speed = speed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health < 0)
            health = 0;
    }

    public void Heal(float amount)
    {
        health += amount;

        if (health > maxHealth)
            health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}