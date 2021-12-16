using System;
using UnityEngine;


public class HealthControl : MonoBehaviour
{
    [Header("Layer Mask")] public LayerMask whatCauseDamage;
    
    //public PlayerHealth playerHealth;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TrigerEnter");
    }
}
