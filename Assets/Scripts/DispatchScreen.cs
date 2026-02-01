using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DispatchScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator anim;
    public string endSceneName = "MainMenu";

    [Header("UI")]
    public TMP_Text enemyNameText;          // optional
    public TypewriterEffect typewriter;     // your typewriter on EnemyDialogText

    void Start()
    {
        if (!EnemyDataDatabase.Instance.TryDrawNext(out var enemy))
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }

        GameState.Instance.selectedEnemyType = enemy.enemyType;

        // Update UI
        if (enemyNameText != null)
            enemyNameText.text = enemy.displayName;

        if (typewriter != null)
            typewriter.SetTextAndPlay(enemy.dialog);
        else
            Debug.LogWarning("DispatcherController: typewriter not assigned.");
    }
}
