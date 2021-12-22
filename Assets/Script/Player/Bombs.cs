using UnityEngine;

public class Bombs : MonoBehaviour
{
    private int _nextBomb;
    //There are 5 types of bomb: (1) Knight, (2) Rook, (3) Bishop, (4) King, (5) Queen
    public GameObject knightBomb;
    public GameObject rookBomb;
    public GameObject bishopBomb;
    public GameObject kingBomb;
    public GameObject queenBomb;
    //The next bomb to be set is random.
    private GameObject _bomb;

    // Start is called before the first frame update
    void Start()
    {
        _nextBomb = RandomBomb();
    }

    public void GetBomb()
    {
        switch (_nextBomb)
        {
            case 1:
                _bomb = knightBomb;
                break;
            case 2 :
                _bomb = rookBomb;
                break;
            case 3 :
                _bomb = bishopBomb;
                break;
            case 4:
                _bomb = kingBomb;
                break;    
            case 5:
                _bomb = queenBomb;
                break;
        }
        Instantiate(_bomb, transform.TransformPoint(0f, 0f, -3f), Quaternion.Euler(0f,0f,0f));
        if(AstarPath.active != null)
            AstarPath.active.Scan(); //Rescan the navigation grid

        _nextBomb = RandomBomb();
    }

    private int RandomBomb()
    {
        int randomNumber = Random.Range(1, 6);
        return randomNumber;
    }

    public int GetNextBomb()
    {
        return _nextBomb;
    }
}
