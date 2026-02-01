using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DispatchScreen : MonoBehaviour
{
    public Animator anim;
    public string endSceneName = "MainMenu";

    [Header("UI")]
    public TMP_Text enemyNameText;         
    public TypewriterEffect typewriter;    

    void Start()
    {
 
        //Debug.Log("Dispatcher instances found: " + all.Length);
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
