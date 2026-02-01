using UnityEngine;
using System;
using System.Collections.Generic;
public class EnemyDataDatabase : MonoBehaviour
{
    //public string test;
    [Serializable]
    public struct EnemyData
    {
        public string enemyType;

        public string displayName;

        [TextArea(2, 5)]
        public string description;

        [TextArea(2, 5)]
        public string dialog;
    }

   [Header("Enemy Data")]
    public List<EnemyData> enemies = new List<EnemyData>();
    private EnemyData lastEnemy;

    public EnemyData GetRandomEnemy(bool avoidImmediateRepeat = true)
    {
        Debug.LogWarning("Inside enemy Database");
        if (enemies.Count == 0)
        {
            Debug.LogWarning("EnemyDataDatabase: No enemies defined.");
            return default;
        }

        if (!avoidImmediateRepeat || enemies.Count == 1)
        {
            lastEnemy = enemies[UnityEngine.Random.Range(0, enemies.Count)];
            return lastEnemy;
        }

        EnemyData chosen;
        do
        {
            chosen = enemies[UnityEngine.Random.Range(0, enemies.Count)];
        }
        while (chosen.enemyType == lastEnemy.enemyType);

        lastEnemy = chosen;
        return chosen;
    }


}
