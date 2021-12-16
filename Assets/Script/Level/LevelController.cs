using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public void GameOver()
    {
        //Display the GAME OVER and reload the level 
        Debug.Log("GAME OVER");
    }

    public void GameWin()
    {
        //Display the YOU WIN and return to the map, also unlock next level
        Debug.Log("You Win");
    }
}
