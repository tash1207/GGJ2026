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
                // Weapons
                { "Acid Sword", Player.Effectiveness.Defeated },
                { "Pool Noodle", Player.Effectiveness.Strong },
                // Masks
                { "Glass Mask", Player.Effectiveness.Strong },
                { "Paper Bag", Player.Effectiveness.Defeated },
                // Shoes
                { "Marble Feet", Player.Effectiveness.Neutral },
                { "Boogie Board", Player.Effectiveness.Strong },
            }
        },
        {
            "Fireater",
            new Dictionary<string, Player.Effectiveness>
            {
                // Weapons
                { "Fire Extinguisher", Player.Effectiveness.Strong },
                { "Acid Sword", Player.Effectiveness.Neutral },
                // Masks
                { "Paper Bag", Player.Effectiveness.Weak },
                { "Welding Mask", Player.Effectiveness.Strong },
                // Shoes
                { "Marble Feet", Player.Effectiveness.Defeated },
                { "Rollerblades", Player.Effectiveness.Strong },
            }
        },
        {
            "Bzzzzzzzt",
            new Dictionary<string, Player.Effectiveness>
            {
                // Weapons
                { "Acid Sword", Player.Effectiveness.Neutral },
                { "Tire Launcher", Player.Effectiveness.Strong },
                // Masks
                { "Rubber Mask", Player.Effectiveness.Strong },
                { "Paper Bag", Player.Effectiveness.Weak },
                // Shoes
                { "Marble Feet", Player.Effectiveness.Defeated },
                { "Rubber Boots", Player.Effectiveness.Strong },
            }
        },
            {
            "Something",
            new Dictionary<string, Player.Effectiveness>
            {
                { "Acid Sword", Player.Effectiveness.Strong },
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
