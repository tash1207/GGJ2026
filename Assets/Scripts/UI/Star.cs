using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Star : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private TMP_Text totalText;

    private float animationDuration = 1f;

    void Start()
    {
        int points = 0;

        if (GameState.Instance != null)
            points = Mathf.Clamp(GameState.Instance.lastBattlePoints, 0, 9);

        if (totalText != null)
            totalText.text = points.ToString();

        // Convert points (0..9) to stars (0..5)
        int numStars = Mathf.Clamp(
            Mathf.RoundToInt((points / 9f) * stars.Length),
            0,
            stars.Length
        );

        // Optional: reset all stars to "unfilled" color first
        for (int i = 0; i < stars.Length; i++)
            stars[i].color = Color.black;

        // Animate earned stars
        for (int i = 0; i < numStars; i++)
        {
            StartCoroutine(GetStar(stars[i], i + 1));
        }
    }

    IEnumerator GetStar(Image image, int waitTime)
    {
        yield return new WaitForSeconds(waitTime * speed);

        Color startColor = Color.black;
        Color endColor = Color.white;

        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / animationDuration);
            image.color = Color.Lerp(startColor, endColor, t);
            yield return null; // IMPORTANT: yield each frame
        }

        image.color = endColor;
    }
}
