using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    
    private float end;

    private void Start()
    {
        end = Time.time + 238;
    }

    private void Update()
    {
        float leftTime = end - Time.time;
        if (leftTime <= 0)
            EndTimer();
        text.text = $"{(int) leftTime / 60}:{(int) leftTime % 60}";
    }

    private void EndTimer()
    {
        SceneManager.LoadScene(1);
    }
}
