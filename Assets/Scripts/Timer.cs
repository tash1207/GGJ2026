using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timerImage;
    [SerializeField] float timeToEquip = 30f;
    [SerializeField] AudioClip timerEnd;

    public float fillFraction;
    public bool timeIsUp = false;
    private bool timerRan = false;

    float timerValue;

    AudioSource audioSource;

    bool playedTimerEnd = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        timerRan = true;
    }

    void UpdateTimer()
    {
        if (timerRan) return;

        timerValue -= Time.deltaTime;

        if (timerValue < 2.5 && !playedTimerEnd)
        {
            audioSource.PlayOneShot(timerEnd);
            playedTimerEnd = true;
        }

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