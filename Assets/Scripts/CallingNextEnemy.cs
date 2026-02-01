using UnityEngine;

public class CallingNextEnemy : MonoBehaviour
{
    public EnemyDataDatabase enemyDB;
    public string dialogText;
    public void ShowNextEnemy()
    {
        var enemy = enemyDB.GetRandomEnemy();
       // nameText.text = enemy.displayName;
       // descriptionText.text = enemy.description;
        dialogText = enemy.dialog;
       // EnemyType type = enemy.enemyType;
    }
}
