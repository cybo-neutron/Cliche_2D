using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelper : MonoBehaviour
{

    IEnumerator coolDownTimer;
    bool isRunning;
    public void StartTimer(float timer)
    {
        if (!isRunning)
        {
            coolDownTimer = coolDown(timer);
            StartCoroutine(coolDownTimer);
        }
    }

    public void StopTimer()
    {
        if (coolDownTimer != null)
            StopCoroutine(coolDownTimer);
        isRunning = false;
    }

    public bool isTimerRunning()
    {
        return isRunning;
    }

    IEnumerator coolDown(float time)
    {
        isRunning = true;
        yield return new WaitForSeconds(time);
        isRunning = false;
    }
}
