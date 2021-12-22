using UnityEngine;

public class SoundFXController : MonoBehaviour
{
    [Header("SoundFX")] public AudioSource navSFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            navSFX.Play();
        }
    }
    
}
