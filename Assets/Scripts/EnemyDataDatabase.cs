using UnityEngine;
using System;
using System.Collections.Generic;

public class EnemyDataDatabase : MonoBehaviour
{
    public static EnemyDataDatabase Instance { get; private set; }

    [Serializable]
    public struct EnemyData
    {
        public EnemyType enemyType;
        public string displayName;
        [TextArea(2, 5)] public string description;
        [TextArea(2, 5)] public string dialog;
        public Sprite picture;
    }

    public List<EnemyData> enemies = new List<EnemyData>();

    private List<int> deck = new List<int>();   // shuffled indices
    private bool initialized = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ResetDeck()
    {
        deck.Clear();
        for (int i = 0; i < enemies.Count; i++) deck.Add(i);

        // Fisher-Yates shuffle
        for (int i = 0; i < deck.Count; i++)
        {
            int j = UnityEngine.Random.Range(i, deck.Count);
            (deck[i], deck[j]) = (deck[j], deck[i]);
        }

        initialized = true;
    }

    public int RemainingCount => deck.Count;

    public bool HasMore => deck.Count > 0;

    // Draws ONE enemy. If none left, returns false.
    public bool TryDrawNext(out EnemyData enemy)
    {
        
        enemy = default;

        if (!initialized)
            ResetDeck();

        if (deck.Count == 0)
            return false;

        int idx = deck[0];
        deck.RemoveAt(0);

        enemy = enemies[idx];
        Debug.Log($"DREW: {enemy.enemyType} | Remaining: {deck.Count}");
        return true;
       

    }


    public EnemyData GetEnemyByType(EnemyType type)
    {
        for (int i = 0; i < enemies.Count; i++)
            if (enemies[i].enemyType == type)
                return enemies[i];

        Debug.LogWarning($"EnemyDataDatabase: No enemy found for {type}");
        return default;
    }
}
