using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static int enemiesCount;
    public int MaxEnemiesCount;

    [Header("Controller")]
    public LevelController levelController;
    
    void Start()
    {
        enemiesCount = MaxEnemiesCount;
    }
    
    public void DestroyedAnEnemy()
    {
        enemiesCount--;
        if (enemiesCount == 0)
        {
            levelController.GameWin();
        }
    }

    public int GETEnemiesCount()
    {
        return enemiesCount;
    }
        
    
}
