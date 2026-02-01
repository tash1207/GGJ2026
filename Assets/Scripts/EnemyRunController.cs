using UnityEngine;

public class EnemyRunController : MonoBehaviour
{
    void Start()
    {
        if (GameState.Instance == null)
        {
            Debug.Log("GameState.Instance is null. You probably started from a scene that doesn't create PersistentManagers.");
            return;
        }
        // Pick a new enemy each time Dispatcher scene is entered
        var enemy = EnemyDataDatabase.Instance.GetEnemyByType(GameState.Instance.selectedEnemyType);

        GameState.Instance.selectedEnemyType = enemy.enemyType;


       
    }

}
