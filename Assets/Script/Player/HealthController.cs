using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public TextMeshProUGUI healthCount;
    
    public PlayerHealth playerHealth;

    void Start()
    {
        healthCount.SetText(""+playerHealth.maxHealth);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("We Got Hit!");
        playerHealth.TakeDamage();
        healthCount.SetText(""+playerHealth.GetHealth());
    }
}
