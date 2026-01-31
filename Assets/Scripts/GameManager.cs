using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int battlesWon = 0;

    void Awake()
    {
        // if (Instance != null)
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        // Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadDispatch()
    {
        SceneManager.LoadScene("Dispatch");
    }

    public void LoadEquipSelect()
    {
        SceneManager.LoadScene("EquipSelect");
    }

    public void LoadBattle()
    {
        SceneManager.LoadScene("Battle");
    }
}
