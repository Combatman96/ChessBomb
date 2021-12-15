using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeArea : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Model")]
    public GameObject model;

    [Header("Properties")]
    public float animationTime = 2f;
    private bool animationIsRunning = false;
    public int damage; // Damage will be inherited from bomb type

    //Location on the board

    void Start()
    {
        animationIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (animationIsRunning)
        {
            if (animationTime <= 0)
                Destroy(model);
            else
                animationTime -= Time.deltaTime;
        }
    }
}
