using UnityEngine;

public class GameState : MonoBehaviour
{
    //need this class for transfer of any type of data across all scenes. Points will need to be calculated here prolly
    public static GameState Instance { get; private set; }
    public EnemyType selectedEnemyType;
    public int completedBattles = 0;
    public int lastBattlePoints;
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
