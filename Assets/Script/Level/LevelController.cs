using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public bool multiplayer = false;
    
    [Header("End Level Display")] 
    public GameObject endLevelDisplay;
    public TextMeshProUGUI endMessage;

    [Header("Level To Unlock After Won")] public int nextLevel;

    [Header("Model")] public LevelUnlockedData levelUnlockedData;
    public PlayerHealth player1Health;
    public PlayerHealth player2Health;
    
    public void GameOver()
    {
        //Display the GAME OVER and reload the level 
        Debug.Log("GAME OVER");
        endLevelDisplay.SetActive(true);
        if (!multiplayer)
        {
            endMessage.SetText("YOU LOSE");
        }
        else
        {
            if (player1Health.GetHealth() > player2Health.GetHealth())
            {
                endMessage.SetText("PLAYER 1 WINS");
            }
            else
            {
                endMessage.SetText("PLAYER 2 WINS");
            }
        }
        //Reload the level after ...
        Invoke(nameof(ReloadThisScene), 2.3f);
    }

    public void GameWin()
    {
        endLevelDisplay.SetActive(true);
        
        if (!multiplayer)
        {
            //Display the YOU WIN and return to the map, also unlock next level
            Debug.Log("You Win");
            endMessage.SetText("YOU WIN");

            //Unlock next level
            levelUnlockedData.UnlockLevel(nextLevel);
        }


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
            if (!multiplayer)
            {
                BackToLevelSelect();
            }
            else
            {
                SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
            }
        }
    }
    
}
