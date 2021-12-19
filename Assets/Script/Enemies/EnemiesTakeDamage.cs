using UnityEngine;

public class EnemiesTakeDamage : MonoBehaviour
{
    public GameObject enemy;
    [Header("Model")]
    public LevelData levelData;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Explode"))
        {
            levelData.DestroyedAnEnemy();
            Destroy(enemy);
        }
    }
}
