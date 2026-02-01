using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleSceneManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image bgImage;
    [SerializeField] Image maskImage;
    [SerializeField] Image weaponImage;
    [SerializeField] Image shoeImage;

    [SerializeField] GameObject winPanel; // Show star rating and advance to next round.
    [SerializeField] GameObject losePanel; // Dead, game over.
    [SerializeField] GameObject gameWinPanel; // Last battle, return to menu.

    [Header("Backgrounds")]
    [SerializeField] Sprite bgLava;
    [SerializeField] Sprite bgWater;
    [SerializeField] Sprite bgElectric;
    [SerializeField] Sprite bgUnknown;

    [Header("Masks")]
    [SerializeField] Sprite maskPaperBag;
    [SerializeField] Sprite maskGlass;
    [SerializeField] Sprite maskRubber;

    [Header("Weapons")]
    [SerializeField] Sprite weaponPoolNoodle;
    [SerializeField] Sprite weaponExtinguisher;
    [SerializeField] Sprite weaponAcidSword;

    [Header("Shoes")]
    [SerializeField] Sprite shoeWheelchair;
    [SerializeField] Sprite shoeMarble;
    [SerializeField] Sprite shoeRubber;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBackgound();
        SetWeapons();

        StartCoroutine(ShowResults());
    }

    void SetBackgound()
    {
        var enemy = EnemyDataDatabase.Instance.GetEnemyByType(GameState.Instance.selectedEnemyType);
        if (GameState.Instance.selectedEnemyType == EnemyType.Fireater)
        {
            bgImage.sprite = bgLava;
        }
        if (GameState.Instance.selectedEnemyType == EnemyType.Splashy)
        {
            bgImage.sprite = bgWater;
        }
        if (GameState.Instance.selectedEnemyType == EnemyType.Bzzzzzzzt)
        {
            bgImage.sprite = bgElectric;
        }
        if (GameState.Instance.selectedEnemyType == EnemyType.Something)
        {
            bgImage.sprite = bgUnknown;
        }
    }

    void SetWeapons()
    {
        string head = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.head);
        string body = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.body);
        string weapon = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.weapon);

        if (head == "Paper Bag")
        {
            maskImage.sprite = maskPaperBag;
        }
        if (body == "Grandma's Wheelchair")
        {
            shoeImage.sprite = shoeWheelchair;
        }
        if (weapon == "Pool Noodle")
        {
            weaponImage.sprite = weaponPoolNoodle;
        }
    }

    IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(3f);

        if (GameState.Instance.defeated)
        {
            losePanel.SetActive(true);
        }
        else
        {
            // if win
            if (GameState.Instance.completedBattles > 3)
            {
                gameWinPanel.SetActive(true);
            }
            else
            {
                winPanel.SetActive(true);
            }
        }
    }
}
