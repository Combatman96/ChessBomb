using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public int getHealth()
    {
        return health;
    }

    public void degreeHealth()
    {
        health--;
    }
}
