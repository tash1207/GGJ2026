using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

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
    [SerializeField] TMP_Text defeatedText;

    [Header("Backgrounds")]
    [SerializeField] Sprite bgLava;
    [SerializeField] Sprite bgWater;
    [SerializeField] Sprite bgElectric;
    [SerializeField] Sprite bgUnknown;

    [Header("Masks")]
    [SerializeField] Sprite maskPaperBag;
    [SerializeField] Sprite maskGlass;
    [SerializeField] Sprite maskRubber;
    [SerializeField] Sprite maskWelding;
    [SerializeField] Sprite maskStone;

    [Header("Weapons")]
    [SerializeField] Sprite weaponPoolNoodle;
    [SerializeField] Sprite weaponExtinguisher;
    [SerializeField] Sprite weaponBaseballBat;
    [SerializeField] Sprite weaponAcidSword;
    [SerializeField] Sprite weaponTireLauncher;

    [Header("Shoes")]
    [SerializeField] Sprite shoeWheelchair;
    [SerializeField] Sprite shoeMarble;
    [SerializeField] Sprite shoeRubber;
    [SerializeField] Sprite shoeRollerblades;
    [SerializeField] Sprite shoeBoogie;


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

        // Masks
        if (head == "Paper Bag")
        {
            maskImage.sprite = maskPaperBag;
        }
        else if (head == "Glass Mask")
        {
            maskImage.sprite = maskGlass;
        }
        else if (head == "Rubber Mask")
        {
            maskImage.sprite = maskRubber;
        }
        else if (head == "Stone Helmet")
        {
            maskImage.sprite = maskStone;
        }
        else if (head == "Welding Mask")
        {
            maskImage.sprite = maskWelding;
        }

        // Weapons
        if (weapon == "Pool Noodle")
        {
            weaponImage.sprite = weaponPoolNoodle;
        }
        else if (weapon == "Fire Extinguisher")
        {
            weaponImage.sprite = weaponExtinguisher;
        }
        else if (weapon == "Tire Launcher")
        {
            weaponImage.sprite = weaponTireLauncher;
        }
        else if (weapon == "Baseball Bat")
        {
            weaponImage.sprite = weaponBaseballBat;
        }
        else if (weapon == "Acid Sword")
        {
            weaponImage.sprite = weaponAcidSword;
        }

        // Shoes
        if (body == "Grandma's Wheelchair")
        {
            shoeImage.sprite = shoeWheelchair;
        }
        else if (body == "Boogie Board")
        {
            shoeImage.sprite = shoeBoogie;
        }
        else if (body == "Marble Feet")
        {
            shoeImage.sprite = shoeMarble;
        }
        else if (body == "Rollerblades")
        {
            shoeImage.sprite = shoeRollerblades;
        }
        else if (body == "Rubber Boots")
        {
            shoeImage.sprite = shoeRubber;
        }
    }

    IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(3f);

        if (GameState.Instance.defeated)
        {
            if (GameState.Instance.defeatedItem == "Nothing")
            {
                defeatedText.text = "Bad idea not fully equipping the hero in this battle.\n\nYou're fired!";
                GameState.Instance.ResetBattleResult();
                PlayerLoadout.Instance.ResetLoad();
            }
            else
            {
                defeatedText.text = "Equipment failure!\nBad idea using a *" + GameState.Instance.defeatedItem + "* in this battle.\n\nYou're fired!";
                GameState.Instance.ResetBattleResult();
                PlayerLoadout.Instance.ResetLoad();
            }
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
