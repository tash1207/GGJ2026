using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ItemsHeader : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject hatsPanel;
    [SerializeField] GameObject shirtsPanel;
    [SerializeField] GameObject weaponsPanel;

    // Description Panel
    [SerializeField] TMP_Text itemNameText;
    [SerializeField] TMP_Text itemDescriptionText;

    public GameObject selectedShader;
    bool isSelected;

    public InventoryManager.ItemType itemType;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        //inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<inventoryManager>();
    }

    public void ShowHats()
    {
        inventoryManager.DeselectAllHeaders();
        selectedShader.SetActive(true);
        hatsPanel.SetActive(true);
        shirtsPanel.SetActive(false);
        weaponsPanel.SetActive(false);
    }

    public void ShowShirts()
    {
        inventoryManager.DeselectAllHeaders();
        selectedShader.SetActive(true);
        hatsPanel.SetActive(false);
        shirtsPanel.SetActive(true);
        weaponsPanel.SetActive(false);
    }

    public void ShowWeapons()
    {
        inventoryManager.DeselectAllHeaders();
        selectedShader.SetActive(true);
        hatsPanel.SetActive(false);
        shirtsPanel.SetActive(false);
        weaponsPanel.SetActive(true);
    }

    private void UpdateDescription()
    {
        GameObject selectedPanel;
        if (itemType == InventoryManager.ItemType.head)
        {
            selectedPanel = hatsPanel;
        }
        else if (itemType == InventoryManager.ItemType.body)
        {
            selectedPanel = shirtsPanel;
        }
        else if (itemType == InventoryManager.ItemType.weapon)
        {
            selectedPanel = weaponsPanel;
        }
        else
        {
            return;
        }

        ItemSlot[] itemSlots = selectedPanel.GetComponentsInChildren<ItemSlot>();
        foreach(ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.thisItemSelected)
            {
                itemNameText.text = itemSlot.itemName;
                itemDescriptionText.text = itemSlot.itemDescription;
                return;
            }
        }

        itemNameText.text = "";
        itemDescriptionText.text = "Select an object to equip it";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedShader.SetActive(true);
        if (itemType == InventoryManager.ItemType.head)
        {
            ShowHats();
        }
        if (itemType == InventoryManager.ItemType.body)
        {
            ShowShirts();
        }
        if (itemType == InventoryManager.ItemType.weapon)
        {
            ShowWeapons();
        }
        UpdateDescription();
    }
}
