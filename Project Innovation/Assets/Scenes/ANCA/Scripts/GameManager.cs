using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int flowerStage;
    public int elixirCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
