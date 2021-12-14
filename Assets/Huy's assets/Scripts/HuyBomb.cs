using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuyBomb : MonoBehaviour
{
    [Header("Models")]
    public GameObject model;
    public GameObject explodeModel;

    [Header("Bomb properties")]
    public int bombId; // (1) Knight, (2) Rook, (3) Bishop, (4) King, (5) Queen
    public float timeCountdown;
    public int damage = 1;
    private bool timeIsRunning = false;
    private float modelX;
    private float modelY;

    // Start is called before the first frame update
    void Start()
    {
        modelX = model.transform.position.x;
        modelY = model.transform.position.y;
        timeIsRunning = true;
    }

    // Update is called once per frame
    // Update until explode
    void Update()
    {
        if (timeIsRunning)
        {
            if (timeCountdown <= 0)
            {
                Destroy(model);
                CreateExplode(bombId);
            }
        else
            timeCountdown -= Time.deltaTime;
        }
    }

    public void CreateExplodeArea(float x, float y)
    {
        if (
            x <= HuyVariable.END_BOARD_X &&
            x >= HuyVariable.START_BOARD_X &&
            y <= HuyVariable.END_BOARD_Y &&
            y >= HuyVariable.START_BOARD_Y
            )
        {
            GameObject obj = Instantiate(explodeModel, new Vector3(x, y, -1), Quaternion.identity);
        }
    }
    private void CreateExplodeAreaLoop(float x, float y, float directionX, float directionY)
    {
        CreateExplodeArea(x + directionX, y + directionY);
        if (!Is_ObstacleOnWay(x + directionX, y + directionY) && !(directionX == 0f && directionY == 0f))
            CreateExplodeAreaLoop(x + directionX, y + directionY, directionX, directionY);
    }

    private bool Is_ObstacleOnWay(float x, float y)
    {
        if (x < HuyVariable.START_BOARD_X || x > HuyVariable.END_BOARD_X)
            return true;
        if (y < HuyVariable.START_BOARD_Y || y > HuyVariable.END_BOARD_Y)
            return true;
        // Hien chua co cai gi de check obstacle tren duong, chi moi check xem da cham bien hay chua
        return false;
    }

    public void CreateExplode(int id)
    {
        CreateExplodeArea(modelX, modelY);
        switch (id)
        {
            case 1: // Knight
                CreateExplodeArea(modelX + 1, modelY - 2);
                CreateExplodeArea(modelX - 1, modelY - 2);
                CreateExplodeArea(modelX - 1, modelY + 2);
                CreateExplodeArea(modelX + 1, modelY + 2);
                CreateExplodeArea(modelX + 2, modelY - 1);
                CreateExplodeArea(modelX - 2, modelY - 1);
                CreateExplodeArea(modelX - 2, modelY + 1);
                CreateExplodeArea(modelX + 2, modelY + 1);
                break;
            case 2: // Rook
                CreateExplodeAreaLoop(modelX, modelY, -1, 0); // Tu phai sang trai
                CreateExplodeAreaLoop(modelX, modelY, 1, 0); // Tu trai sang phai
                CreateExplodeAreaLoop(modelX, modelY, 0, -1); // Tu duoi len tren
                CreateExplodeAreaLoop(modelX, modelY, 0, 1); // Tu tren xuong duoi
                break;
            case 3: // Bishop
                CreateExplodeAreaLoop(modelX, modelY, -1, -1); // Tu phai sang trai, tu duoi len tren
                CreateExplodeAreaLoop(modelX, modelY, 1, -1); // Tu trai sang phai, tu duoi len tren
                CreateExplodeAreaLoop(modelX, modelY, 1, 1); // Tu trai sang phai, tu tren xuong duoi
                CreateExplodeAreaLoop(modelX, modelY, -1, 1); // Tu trai sang phai, tu tren xuong duoi
                break;
            case 4: // Queen
                CreateExplodeAreaLoop(modelX, modelY, -1, -1); // Tu phai sang trai, tu duoi len tren
                CreateExplodeAreaLoop(modelX, modelY, 1, -1); // Tu trai sang phai, tu duoi len tren
                CreateExplodeAreaLoop(modelX, modelY, 1, 1); // Tu trai sang phai, tu tren xuong duoi
                CreateExplodeAreaLoop(modelX, modelY, -1, 1); // Tu trai sang phai, tu tren xuong duoi
                CreateExplodeAreaLoop(modelX, modelY, -1, 0); // Tu phai sang trai
                CreateExplodeAreaLoop(modelX, modelY, 1, 0); // Tu trai sang phai
                CreateExplodeAreaLoop(modelX, modelY, 0, -1); // Tu duoi len tren
                CreateExplodeAreaLoop(modelX, modelY, 0, 1); // Tu tren xuong duoi
                break;
            default: // King : 5
                CreateExplodeArea(modelX, modelY - 1);
                CreateExplodeArea(modelX + 1, modelY - 1);
                CreateExplodeArea(modelX + 1, modelY);
                CreateExplodeArea(modelX + 1, modelY + 1);
                CreateExplodeArea(modelX, modelY + 1);
                CreateExplodeArea(modelX - 1, modelY + 1);
                CreateExplodeArea(modelX - 1, modelY);
                CreateExplodeArea(modelX - 1, modelY - 1);
                break;
        }
    }

}
