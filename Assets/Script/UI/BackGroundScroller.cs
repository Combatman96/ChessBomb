using UnityEngine;
using UnityEngine.UI;

public class BackGroundScroller : MonoBehaviour
{
    public RawImage backgroundIMG;
    public float x, y;

    // Update is called once per frame
    void Update()
    {
        backgroundIMG.uvRect = new Rect(backgroundIMG.uvRect.position + new Vector2(x, y) * Time.deltaTime,
            backgroundIMG.uvRect.size);
    }
}
