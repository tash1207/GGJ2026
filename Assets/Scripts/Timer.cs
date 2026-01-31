using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timerImage;
    [SerializeField] float timeToEquip = 30f;

    public float fillFraction;
    public bool timeIsUp = false;

    float timerValue;

    void Start()
    {
        timerValue = timeToEquip;
    }

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    public void ResetTimer()
    {
        timerValue = timeToEquip;
        timeIsUp = false;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (timerValue > 0)
        {
            fillFraction = timerValue / timeToEquip;
            timerImage.fillAmount = fillFraction;
        }
        else
        {
            timerValue = timeToEquip;
            timeIsUp = true;
        }
    }
}