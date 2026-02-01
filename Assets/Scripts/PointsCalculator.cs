using UnityEngine;
using TMPro;
public class PointsCalculator : MonoBehaviour
{

    [SerializeField] private TMP_Text totalText; // drag a TMP Text here in Inspector

    private void Start()
    {
        if (EnemyDataDatabase.Instance == null)
        {
            Debug.LogError("[PointsCalculator] EnemyDataDatabase.Instance is NULL (missing in scene?)");
            return;
        }

        if (GameState.Instance == null)
        {
            Debug.LogError("[PointsCalculator] GameState.Instance is NULL (missing in scene?)");
            return;
        }

        if (PlayerLoadout.Instance == null)
        {
            Debug.LogError("[PointsCalculator] PlayerLoadout.Instance is NULL (missing in scene?)");
            return;
        }

        // 1. Get enemy
        var eney = EnemyDataDatabase.Instance.GetEnemyByType(GameState.Instance.selectedEnemyType);
        string enemy = eney.enemyType.ToString();
        Debug.Log($"[DEBUG] Enemy: {enemy}");

        // 2. Read equipped items
        string head = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.head);
        string body = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.body);
        string weapon = PlayerLoadout.Instance.GetEquipped(InventoryManager.ItemType.weapon);

        Debug.Log($"[DEBUG] Equipped Head: {head}");
        Debug.Log($"[DEBUG] Equipped Body: {body}");
        Debug.Log($"[DEBUG] Equipped Weapon: {weapon}");

        // 3. Check effectiveness + points
        int total = 0;
        total += LogEffectAndGetPoints("HEAD", head, enemy);
        total += LogEffectAndGetPoints("BODY", body, enemy);
        total += LogEffectAndGetPoints("WEAPON", weapon, enemy);

        Debug.Log($"[TOTAL POINTS] {total}");
        GameState.Instance.lastBattlePoints = total;
        GameState.Instance.completedBattles += 1;
        if (totalText != null)
            totalText.text = total.ToString();

    }

    private int LogEffectAndGetPoints(string slot, string itemName, string enemy)
    {
        if (string.IsNullOrWhiteSpace(itemName))
        {
            Debug.Log($"[MATCHUP] {slot} (NONE) vs {enemy} → (no item) = 0");
            return 0;
        }
        // IMPORTANT: Ensure these types match.
        // If EffectivenessTable returns Player.Effectiveness, you're good.
        // If it returns Effectiveness (another enum), adjust PointsFor to match that enum type.
        var eff = EffectivenessTable.GetEffectiveness(enemy, itemName);

        Debug.Log($"[MATCHUP] {slot} ({itemName}) vs {enemy} → {eff}");

        // Convert to points
        int pts = PointsFor(eff);
        Debug.Log($"[POINTS] {slot} +{pts}");

        return pts;
    }

    // CHANGED: accept the same enum type returned by EffectivenessTable.GetEffectiveness(...)
    public static int PointsFor(Player.Effectiveness eff)
    {
        switch (eff)
        {
            case Player.Effectiveness.Strong: return 3;
            case Player.Effectiveness.Neutral: return 2;
            case Player.Effectiveness.Weak: return 1;
            case Player.Effectiveness.Defeated: return 0;
            default: return 0;
        }
    }
}
