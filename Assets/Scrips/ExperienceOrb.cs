using UnityEngine;

public class ExperienceOrb : MonoBehaviour
{
    [SerializeField] private int experienceAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.AddExperience(experienceAmount);

            Debug.Log("Esfera recogida: +" + experienceAmount + " XP.");

            Destroy(gameObject);
        }
    }
}