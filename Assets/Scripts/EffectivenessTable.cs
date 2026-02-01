using System.Collections.Generic;
using UnityEngine;
public static class EffectivenessTable
{

    // Enemy → ItemName → Effectiveness
    private static Dictionary<string, Dictionary<string, Player.Effectiveness>> table
        = new Dictionary<string, Dictionary<string, Player.Effectiveness>>
    {
        {
            "Splashy",
            new Dictionary<string, Player.Effectiveness>
            {
                { "Acid Sword", Player.Effectiveness.Strong },
                { "Paper Bag", Player.Effectiveness.Weak },
                { "Marble Feet", Player.Effectiveness.Defeated },
            }
        },
        {
            "Fireater",
            new Dictionary<string, Player.Effectiveness>
            {
                { "Fire Extinguisher", Player.Effectiveness.Strong },
                { "Acid Sword", Player.Effectiveness.Neutral },
                { "Paper Bag", Player.Effectiveness.Defeated },
                { "Marble Feet", Player.Effectiveness.Strong },
            }
        },
        {
            "Bzzzzzzzt",
            new Dictionary<string, Player.Effectiveness>
            {
                { "Acid Sword", Player.Effectiveness.Neutral },
                { "Paper Bag", Player.Effectiveness.Weak },
                { "Marble Feet", Player.Effectiveness.Defeated },
            }
        },
            {
            "Bubble King",
            new Dictionary<string, Player.Effectiveness>
            {
                { "Acid Sword", Player.Effectiveness.Neutral },
                { "Paper Bag", Player.Effectiveness.Weak },
                { "Marble Feet", Player.Effectiveness.Defeated },
            }
        }
    };

    public static Player.Effectiveness GetEffectiveness(string enemyType, string itemName)
    {
        if (string.IsNullOrEmpty(enemyType) || string.IsNullOrEmpty(itemName))
            return Player.Effectiveness.Neutral;

        if (table.TryGetValue(enemyType, out var itemTable))
        {
            if (itemTable.TryGetValue(itemName, out var eff))
                return eff;
        }

        return Player.Effectiveness.Neutral;
    }
}
