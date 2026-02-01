using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private ItemSlot items;

    public enum Loadout
    {
        Mask,
        Weapon,
        Armor
    }

    public enum Effectiveness
    {
        Strong,
        Neutral,
        Weak,
        Defeated
    }

    //List<Loadout> loadout = new List<Loadout>();

    private Dictionary<Loadout, List<string>> loadoutTypes = new()
    {
        { Loadout.Mask, new List<string> { "Rubber Mask", "Welding Mask", "Glass Mask" } },
        { Loadout.Weapon, new List<string> { "Extinguisher", "Foam Finger", "Acid Sword" } },
        { Loadout.Armor, new List<string> { "Grandma's Wheelchair", "Latex Catsuit" } }
    };


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
