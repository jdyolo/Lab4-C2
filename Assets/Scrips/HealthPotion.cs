using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private float healAmount = 25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.Heal(healAmount);

            Debug.Log("Poción recogida: +" + healAmount + " de vida.");

            Destroy(gameObject);
        }
    }
}