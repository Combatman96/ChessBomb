using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int health;
    public int maxHealth = 3;

    [Header("Controller")] public LevelController levelController;

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
        if (health == 0)
        {
            levelController.GameOver();
        }
    }
}
