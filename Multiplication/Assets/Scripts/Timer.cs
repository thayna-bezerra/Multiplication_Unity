using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerTxt;

    public int duration;

    private int remainingDuration;

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        timerTxt.text = "00:00";

        duration = remainingDuration = 0;
    }

    public Timer SetDuration (int seconds)
    {
        duration = remainingDuration - seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration > 0)
        {
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateUI (int seconds)
    {
        timerTxt.text = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);
    }
}