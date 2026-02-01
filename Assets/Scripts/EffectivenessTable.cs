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
                { "Fire Extinguisher", Player.Effectiveness.Weak },
                { "Acid Sword", Player.Effectiveness.Defeated },
                { "Baseball Bat", Player.Effectiveness.Neutral },
                { "Pool Noodle", Player.Effectiveness.Strong },
                { "Tire Launcher", Player.Effectiveness.Neutral },
                // Masks
                { "Stone Mask", Player.Effectiveness.Weak },
                { "Glass Mask", Player.Effectiveness.Strong },
                { "Rubber Mask", Player.Effectiveness.Neutral },
                { "Paper Bag", Player.Effectiveness.Defeated },
                { "Welding Mask", Player.Effectiveness.Weak },
                // Shoes
                { "Marble Feet", Player.Effectiveness.Neutral },
                { "Rollerblades", Player.Effectiveness.Neutral },
                { "Wheelchair", Player.Effectiveness.Weak },
                { "Boogie Board", Player.Effectiveness.Strong },
                { "Rubber Boots", Player.Effectiveness.Defeated },
            }
        },
        {
            "Fireater",
            new Dictionary<string, Player.Effectiveness>
            {
                // Weapons
                { "Fire Extinguisher", Player.Effectiveness.Strong },
                { "Acid Sword", Player.Effectiveness.Neutral },
                { "Baseball Bat", Player.Effectiveness.Defeated },
                { "Pool Noodle", Player.Effectiveness.Neutral },
                { "Tire Launcher", Player.Effectiveness.Weak },
                // Masks
                { "Stone Mask", Player.Effectiveness.Defeated },
                { "Glass Mask", Player.Effectiveness.Weak },
                { "Rubber Mask", Player.Effectiveness.Neutral },
                { "Paper Bag", Player.Effectiveness.Weak },
                { "Welding Mask", Player.Effectiveness.Strong },
                // Shoes
                { "Marble Feet", Player.Effectiveness.Defeated },
                { "Rollerblades", Player.Effectiveness.Strong },
                { "Wheelchair", Player.Effectiveness.Weak },
                { "Boogie Board", Player.Effectiveness.Neutral },
                { "Rubber Boots", Player.Effectiveness.Neutral },
            }
        },
        {
            "Bzzzzzzzt",
            new Dictionary<string, Player.Effectiveness>
            {
                // Weapons
                { "Fire Extinguisher", Player.Effectiveness.Neutral },
                { "Acid Sword", Player.Effectiveness.Weak },
                { "Baseball Bat", Player.Effectiveness.Neutral },
                { "Pool Noodle", Player.Effectiveness.Defeated },
                { "Tire Launcher", Player.Effectiveness.Strong },
                // Masks
                { "Stone Mask", Player.Effectiveness.Neutral },
                { "Glass Mask", Player.Effectiveness.Defeated },
                { "Rubber Mask", Player.Effectiveness.Strong },
                { "Paper Bag", Player.Effectiveness.Weak },
                { "Welding Mask", Player.Effectiveness.Neutral },
                // Shoes
                { "Marble Feet", Player.Effectiveness.Neutral },
                { "Rollerblades", Player.Effectiveness.Neutral },
                { "Wheelchair", Player.Effectiveness.Defeated },
                { "Boogie Board", Player.Effectiveness.Weak },
                { "Rubber Boots", Player.Effectiveness.Strong },
            }
        },
            {
            "Something",
            new Dictionary<string, Player.Effectiveness>
            {
                // Weapons
                { "Fire Extinguisher", Player.Effectiveness.Weak },
                { "Acid Sword", Player.Effectiveness.Strong },
                { "Baseball Bat", Player.Effectiveness.Weak },
                { "Pool Noodle", Player.Effectiveness.Weak },
                { "Tire Launcher", Player.Effectiveness.Weak },
                // Masks
                { "Stone Mask", Player.Effectiveness.Weak },
                { "Glass Mask", Player.Effectiveness.Weak },
                { "Rubber Mask", Player.Effectiveness.Weak },
                { "Paper Bag", Player.Effectiveness.Strong },
                { "Welding Mask", Player.Effectiveness.Weak },
                // Shoes
                { "Marble Feet", Player.Effectiveness.Weak },
                { "Rollerblades", Player.Effectiveness.Weak },
                { "Wheelchair", Player.Effectiveness.Strong },
                { "Boogie Board", Player.Effectiveness.Weak },
                { "Rubber Boots", Player.Effectiveness.Weak },
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
