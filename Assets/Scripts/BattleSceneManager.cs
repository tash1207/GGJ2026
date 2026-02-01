using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField] Image bgImage;
    [SerializeField] GameObject winPanel; // Show star rating and advance to next round.
    [SerializeField] GameObject losePanel; // Dead, game over.
    [SerializeField] GameObject gameWinPanel; // Last battle, return to menu.

    [SerializeField] Sprite bgLava;
    [SerializeField] Sprite bgWater;
    [SerializeField] Sprite bgElectric;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
            bgImage.sprite = bgLava;
        }

        StartCoroutine(ShowResults());
    }

    IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(3f);

        // if win
        if (GameState.Instance.completedBattles >= 3)
        {
            gameWinPanel.SetActive(true);
        }
        else
        {
            winPanel.SetActive(true);
        }
        
        //losePanel.SetActive(true);
    }
}
