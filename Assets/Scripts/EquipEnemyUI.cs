using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipEnemyUI : MonoBehaviour
{
    public TMP_Text enemyNameText;        // the "Lava Monster" label
    public TMP_Text enemyDescriptionText; // the description box text
    public Image enemyImage;

    void Start()
    {
        if (GameState.Instance == null)
        {
            Debug.LogError("EquipEnemyUI: GameState.Instance is null (did you start from Equip scene directly?)");
            return;
        }

        if (EnemyDataDatabase.Instance == null)
        {
            Debug.LogError("EquipEnemyUI: EnemyDataDatabase.Instance is null (Persistent managers missing?)");
            return;
        }
        
        var enemy = EnemyDataDatabase.Instance.GetEnemyByType(GameState.Instance.selectedEnemyType);

        enemyNameText.text = enemy.displayName;
        enemyDescriptionText.text = enemy.description;
        enemyImage.sprite = enemy.picture;
    }
}
