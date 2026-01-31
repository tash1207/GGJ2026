using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemSlot[] hatItemSlots;
    [SerializeField] ItemSlot[] shirtItemSlots;
    [SerializeField] ItemSlot[] weaponItemSlots;

    [SerializeField] ItemsHeader hatHeader;
    [SerializeField] ItemsHeader shirtHeader;
    [SerializeField] ItemsHeader weaponHeader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DeselectAllHeaders()
    {
        hatHeader.selectedShader.SetActive(false);
        shirtHeader.selectedShader.SetActive(false);
        weaponHeader.selectedShader.SetActive(false);
    }

    public void DeselectAllSlots()
    {
        DeselectHatSlots();
        DeselectShirtSlots();
        DeselectWeaponSlots();
    }

    public void DeselectHatSlots()
    {
        for (int i = 0; i < hatItemSlots.Length; i++)
        {
            hatItemSlots[i].selectedShader.SetActive(false);
            hatItemSlots[i].thisItemSelected = false;
        }
    }

    public void DeselectShirtSlots()
    {
        for (int i = 0; i < shirtItemSlots.Length; i++)
        {
            shirtItemSlots[i].selectedShader.SetActive(false);
            shirtItemSlots[i].thisItemSelected = false;
        }
    }

    public void DeselectWeaponSlots()
    {
        for (int i = 0; i < weaponItemSlots.Length; i++)
        {
            weaponItemSlots[i].selectedShader.SetActive(false);
            weaponItemSlots[i].thisItemSelected = false;
        }
    }

    public enum ItemType
    {
        head,
        body,
        weapon
    }
}
