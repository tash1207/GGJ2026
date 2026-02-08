using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemSlot[] hatItemSlots;
    [SerializeField] ItemSlot[] shirtItemSlots;
    [SerializeField] ItemSlot[] weaponItemSlots;

    [SerializeField] ItemsHeader hatHeader;
    [SerializeField] ItemsHeader shirtHeader;
    [SerializeField] ItemsHeader weaponHeader;

    [SerializeField] GameObject unequippedCanvas;
    [SerializeField] GameObject timeUpCanvas;

    Timer timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = FindFirstObjectByType<Timer>();
    }

    void Update()
    {
        if (timer.timeIsUp)
        {
            TimeUp();
        }
    }

    private void TimeUp()
    {
        timer.ResetTimer();
        timeUpCanvas.SetActive(true);
        Invoke("GoToBattleScene", 2.5f);
    }

    public void CheckForEquipment()
    {
        string head = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.head);
        string body = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.body);
        string weapon = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.weapon);

        if (head == "" || body == "" || weapon == "")
        {
            StartCoroutine(UnequippedDialog());
        }
        else
        {
            GoToBattleScene();
        }
    }

    IEnumerator UnequippedDialog()
    {
        Time.timeScale = 0;
        unequippedCanvas.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        unequippedCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    private void GoToBattleScene()
    {
        SceneManager.LoadScene("Battle");
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
