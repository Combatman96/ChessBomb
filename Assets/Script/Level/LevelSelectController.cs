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
                break;
            case 2:
                //Load Level2
                break;
            case 3:
                //Load Level3
                break;
            case 4:
                //Load Level4
                break;
            case 5:
                //Load Level5
                break;
            case 6:
                //Load Level6
                break;
        }
    }
}
