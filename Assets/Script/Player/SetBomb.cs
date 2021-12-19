using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetBomb : MonoBehaviour
{
    [Header("Images")]
    public Image rookImg;
    public Image knightImg;
    public Image bishopImg;
    public Image kingImg;
    public Image queenImg;

    [Header("Components")] public Bombs bombs;

    private bool callOne = false;
    
    private void ShowBomb()
    {
        switch (bombs.GetNextBomb())
        {
            case 1:
                knightImg.enabled = true;
                rookImg.enabled = false;
                bishopImg.enabled = false;
                kingImg.enabled = false;
                queenImg.enabled = false;
                break;
            case 2:
                knightImg.enabled = false;
                rookImg.enabled = true;
                bishopImg.enabled = false;
                kingImg.enabled = false;
                queenImg.enabled = false;
                break;
            case 3:
                knightImg.enabled = false;
                rookImg.enabled = false;
                bishopImg.enabled = true;
                kingImg.enabled = false;
                queenImg.enabled = false;
                break;
            case 4:
                knightImg.enabled = false;
                rookImg.enabled = false;
                bishopImg.enabled = false;
                kingImg.enabled = true;
                queenImg.enabled = false;
                break;
            case 5:
                knightImg.enabled = false;
                rookImg.enabled = false;
                bishopImg.enabled = false;
                kingImg.enabled = false;
                queenImg.enabled = true;
                break;
        }
    }

    public void InitBomb()
    {
        bombs.GetBomb();
        ShowBomb();
    }

    public void Update()
    {
        if (!callOne)
        {
            ShowBomb();
            callOne = true;
        }
        else
        {
            return;
        }
    }
}
