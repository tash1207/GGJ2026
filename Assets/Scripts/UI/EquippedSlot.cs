using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquippedSlot : MonoBehaviour
{
    [SerializeField] Image slotImage;
    [SerializeField] InventoryManager.ItemType itemType;

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private bool slotInUse;

    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        // Update Image
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        
        // Update Data
        this.itemName = itemName;
        this.itemDescription = itemDescription;

        slotInUse = true;
    }

}
