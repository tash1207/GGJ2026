using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    public EnemyType selectedEnemyType;
    public int completedBattles = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
