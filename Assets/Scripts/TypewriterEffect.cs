using UnityEngine;
using System.Collections;
using TMPro;
public class TypewriterEffect : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    public float typingSpeed = 0.05f; // Time between each character
    public string cursorSymbol = "_"; // The symbol to use as the cursor
    public float cursorBlinkSpeed = 0.5f; // Blink speed of the cursor

    private string fullText;
    private bool isTyping;
    private Coroutine cursorBlinkCoroutine;
    //private CallingNextEnemy ene;
    public EnemyDataDatabase enemyDB;
    public string dialogText;
    private void Start()
    {
        //Debug.Log(ene.dialogText);
        var enemy = enemyDB.GetRandomEnemy();
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();
        fullText = enemy.dialog;
        // fullText = ene.dialogText;
        //fullText = textMeshPro.text;
        textMeshPro.text = "";
        StartTypewriterEffect();
    }

    public void StartTypewriterEffect()
    {
        if (isTyping) return;

        if (cursorBlinkCoroutine != null)
        {
            StopCoroutine(cursorBlinkCoroutine);
            cursorBlinkCoroutine = null;
        }

        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        isTyping = true;
        textMeshPro.text = "";

        foreach (char letter in fullText.ToCharArray())
        {
            textMeshPro.text += letter + cursorSymbol;
            yield return new WaitForSeconds(typingSpeed);
            textMeshPro.text = textMeshPro.text.Substring(0, textMeshPro.text.Length - cursorSymbol.Length);
        }

        textMeshPro.text = fullText + cursorSymbol;
        isTyping = false;

        cursorBlinkCoroutine = StartCoroutine(BlinkCursor());
    }

    private IEnumerator BlinkCursor()
    {
        while (true)
        {
            textMeshPro.text = fullText;
            yield return new WaitForSeconds(cursorBlinkSpeed);
            textMeshPro.text = fullText + cursorSymbol;
            yield return new WaitForSeconds(cursorBlinkSpeed);
        }
    }
}
