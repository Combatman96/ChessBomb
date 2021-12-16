using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int health;
    public int maxHealth = 3;

    private void Start()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage()
    {
        health--;
    }
}
