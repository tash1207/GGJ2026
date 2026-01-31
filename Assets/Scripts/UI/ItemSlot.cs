using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public InventoryManager.ItemType itemType;

    public GameObject selectedShader;
    public bool thisItemSelected = false;

    [SerializeField] TMP_Text itemNameText;
    [SerializeField] TMP_Text itemDescriptionText;

    [SerializeField] EquippedSlot headSlot, bodySlot, weaponSlot;

    private Image itemImage;

    private InventoryManager inventoryManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        //inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<inventoryManager>();
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;

        UpdateSelectedItem();
        EquipGear();
    }

    private void UpdateSelectedItem()
    {
        itemNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
    }

    private void EquipGear()
    {
        if (itemType == InventoryManager.ItemType.head)
        {
            headSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        if (itemType == InventoryManager.ItemType.body)
        {
            bodySlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        if (itemType == InventoryManager.ItemType.weapon)
        {
            weaponSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnLeftClick();
    }

}
