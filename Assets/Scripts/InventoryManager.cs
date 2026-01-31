using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemSlot[] itemSlots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].thisItemSelected = false;
        }
    }

    public enum ItemType
    {
        head,
        body,
        weapon
    }
}
