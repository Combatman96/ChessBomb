using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    [Header("Level Buttons")] 
    public Button[] levelBtn = new Button[6];
    
    [Header("Model")] 
    public LevelUnlockedData levelUnlockedData;

    private void Start()
    {
        //Make buttons which load unlocked levels interactable
        for (int i = 2; i < 7; i++)
        {
            string levelName = "Level" + i;
            if (levelUnlockedData.GetLevelStatus(levelName) == 1)
            {
                levelBtn[i-1].interactable = true;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //Back to Title Screen
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
        }
    }

    public void OnLevelBtnClicked(int lv)
    {
        //Load the Level lv Scene
        switch (lv)
        {
            case 1:
                //Load Level1
                SceneManager.LoadScene("Level1", LoadSceneMode.Single);
                break;
            case 2:
                //Load Level2
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
                break;
            case 3:
                //Load Level3
                SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                break;
            case 4:
                //Load Level4
                SceneManager.LoadScene("Level4", LoadSceneMode.Single);
                break;
            case 5:
                //Load Level5
                SceneManager.LoadScene("Level5", LoadSceneMode.Single);
                break;
            case 6:
                //Load Level6
                SceneManager.LoadScene("Level6", LoadSceneMode.Single);
                break;
        }
    }
}
