using UnityEngine;

public class LevelUnlockedData : MonoBehaviour
{
    static int lv1 = 1;
    static int lv2 = 0;
    static int lv3 = 0;
    static int lv4 = 0;
    static int lv5 = 0;
    static int lv6 = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("Level1", lv1);
        PlayerPrefs.SetInt("Level2", lv2);
        PlayerPrefs.SetInt("Level3", lv3);
        PlayerPrefs.SetInt("Level4", lv4);
        PlayerPrefs.SetInt("Level5", lv5);
        PlayerPrefs.SetInt("Level6", lv6);
    }

    public void UnlockLevel(int lvNum)
    {
        switch (lvNum)
        {
            case 2:
                lv2 = 1;
                PlayerPrefs.SetInt("Level2", lv2);
                break;
            case 3:
                lv3 = 1;
                PlayerPrefs.SetInt("Level3", lv3);
                break;
            case 4:
                lv4 = 1;
                PlayerPrefs.SetInt("Level4", lv4);
                break;
            case 5:
                lv5 = 1;
                PlayerPrefs.SetInt("Level5", lv5);
                break;
            case 6:
                lv6 = 1;
                PlayerPrefs.SetInt("Level6", lv6);
                break;
        }
    }

    public int GetLevelStatus(string levelName)
    {
        return PlayerPrefs.GetInt(levelName);
    }
    
}
