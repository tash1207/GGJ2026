using UnityEngine;

public class EnemyRunController : MonoBehaviour
{
    void Start()
    {
        if (GameState.Instance == null)
        {
            Debug.Log("Start from main menu. it will work");
            return;
        }
        // Pick a new enemy each time Dispatcher scene is entered
        var enemy = EnemyDataDatabase.Instance.GetEnemyByType(GameState.Instance.selectedEnemyType);

        GameState.Instance.selectedEnemyType = enemy.enemyType;


       
    }

}
