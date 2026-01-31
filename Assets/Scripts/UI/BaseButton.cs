using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Image buttonBackground = GetComponent<Image>();
        buttonBackground.alphaHitTestMinimumThreshold = 0.9f;
        //Debug.Log("buttonBackground.alphaHitTestMinimumThreshold " + buttonBackground.alphaHitTestMinimumThreshold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
