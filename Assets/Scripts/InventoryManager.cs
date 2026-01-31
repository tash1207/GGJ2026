using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemSlot[] hatItemSlots;
    [SerializeField] ItemSlot[] shirtItemSlots;
    [SerializeField] ItemSlot[] weaponItemSlots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < shirtItemSlots.Length; i++)
        {
            shirtItemSlots[i].selectedShader.SetActive(false);
            shirtItemSlots[i].thisItemSelected = false;
        }
    }

    public enum ItemType
    {
        head,
        body,
        weapon
    }
}
