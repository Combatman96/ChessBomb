using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [Header("End Level Display")] 
    public GameObject endLevelDisplay;
    public TextMeshProUGUI endMessage;

    [Header("Level To Unlock After Won")] public int nextLevel;
    [Header("Model")] public LevelUnlockedData levelUnlockedData;
    
    
    public void GameOver()
    {
        //Display the GAME OVER and reload the level 
        Debug.Log("GAME OVER");
        endLevelDisplay.SetActive(true);
        endMessage.SetText("YOU LOSE");
        
        //Reload the level after ...
        Invoke(nameof(ReloadThisScene), 2.3f);
    }

    public void GameWin()
    {
        //Display the YOU WIN and return to the map, also unlock next level
        Debug.Log("You Win");
        endLevelDisplay.SetActive(true);
        endMessage.SetText("YOU WIN");
        
        //Unlock next level
        levelUnlockedData.UnlockLevel(nextLevel);

        //back to the scene LEVEL SELECT after ... 
        Invoke(nameof(BackToLevelSelect), 2.3f);
    }
    
    private void ReloadThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    
    private void BackToLevelSelect()
    {
        SceneManager.LoadScene("AdventureLevelSelector", LoadSceneMode.Single);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToLevelSelect();
        }
    }
    
}
