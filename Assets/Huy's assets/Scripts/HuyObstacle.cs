using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuyObstacle : MonoBehaviour
{
    [Header("Model")]
    public GameObject model;

    [Header("Properties")]
    public int health = 1;
    public bool is_indestructible = false;

    //Some functions will need reference to the controller
    //public GameObject controller;

    // Constructor
    public void initiateObstacle()
    {
        this.health = 1;
        //controller = GameObject.FindGameObjectWithTag("GameController");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(model);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("HuyObstacle collided with " + col.gameObject.tag + " detected");
        if (col.gameObject.tag == "Explode" && !is_indestructible)
        {
            this.health -= 1;
        }
    }
}
