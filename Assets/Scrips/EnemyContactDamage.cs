using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField] private float contactDamage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(contactDamage, ElementType.Normal);

            Debug.Log(
                gameObject.name +
                " golpeó al Player por contacto."
            );
        }
    }
}