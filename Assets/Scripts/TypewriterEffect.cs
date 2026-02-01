using UnityEngine;
using System.Collections;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float typingSpeed = 0.05f;
    public string cursorSymbol = "_";
    public float cursorBlinkSpeed = 0.5f;

    private string fullText = "";
    private bool isTyping;
    private Coroutine cursorBlinkCoroutine;
    private Coroutine typingCoroutine;

    void Awake()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Call this from another script
    public void SetTextAndPlay(string text)
    {
        fullText = text ?? "";
        Restart();
    }

    public void Restart()
    {
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        if (cursorBlinkCoroutine != null) StopCoroutine(cursorBlinkCoroutine);

        textMeshPro.text = "";
        typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        isTyping = true;
        textMeshPro.text = "";

        foreach (char letter in fullText)
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
