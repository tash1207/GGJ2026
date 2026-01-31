using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Star : MonoBehaviour
{
    [SerializeField] Image[] stars;
    [SerializeField] float speed = 0.5f;

    public int numStars = 3;

    float animationDuration = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numStars = Mathf.Clamp(numStars, 0, stars.Length);
        for (int i = 0; i < numStars; i++)
        {
            Image starImage = stars[i];
            StartCoroutine(GetStar(starImage, i + 1));
        }
    }

    IEnumerator GetStar(Image image, int waitTime)
    {
        yield return new WaitForSeconds(waitTime * speed);

        Color startColor = Color.black;
        Color endColor = Color.white;

        //yield return new WaitForSeconds(waitTime);
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            image.color = Color.Lerp(startColor, endColor, Mathf.Clamp(elapsedTime += Time.deltaTime, 0f, 1f));
        }

        image.color = endColor;

        yield return new WaitForEndOfFrame();
    }
}
