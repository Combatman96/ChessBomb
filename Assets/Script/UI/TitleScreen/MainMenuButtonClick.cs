﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonClick : MonoBehaviour
{
    public void OnMainMenuBtnClick(int btn)
    {
        switch (btn)
        {
            case 1:
                //Load the Level Select Scene for SinglePlayer
                //SceneManager.LoadScene()
                break;
            case 2:
                //Load the Level Select Scene for Puzzel
                break;
            case 3:
                //Load the Multiplayer Scene
                break;
            case 4:
                //Exit Game
                Application.Quit();
                break;
        }
    }
}
