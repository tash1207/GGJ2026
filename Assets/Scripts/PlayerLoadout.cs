using UnityEngine;
using System.Collections.Generic;
public class PlayerLoadout : MonoBehaviour
{
    // persistent object again.. for player loadout thingu
    public static PlayerLoadout Instance { get; private set; }

    private Dictionary<InventoryManager.ItemType, string> equippedNames = new();

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetEquipped(InventoryManager.ItemType type, string itemName)
    {
        equippedNames[type] = itemName;   // needs overwriting so this
        Debug.Log($"[LoadoutStore] {type} = {itemName}");
    }

    public string GetEquipped(InventoryManager.ItemType type)
    {
        return equippedNames.TryGetValue(type, out var name) ? name : "";
    }
}
