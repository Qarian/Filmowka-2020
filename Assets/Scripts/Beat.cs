using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Beat : MonoBehaviour
{
    [SerializeField] private float bpm = 60;
    [SerializeField] private float acceptableOffset = 0.5f;
    private int index = 0;

    public static Action OnBeat;
    
    [SerializeField] private  Color[] colors;
    public static Color selectedColor;


    private static double acceptable;
    private static double time = 0;
    private static double beatInterval;
    private float lastTry = 0;

    private void OnValidate()
    {
        acceptable = acceptableOffset;
    }

    private void Start()
    {
        beatInterval = 60 / bpm;
        acceptable = acceptableOffset;
        OnBeat += () => Debug.Log("Beap!");
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time >= beatInterval)
        {
            index = Random.Range(0, colors.Length);
            selectedColor = colors[index];
            OnBeat?.Invoke();
            time -= beatInterval;
        }
        if (Input.GetKeyDown(KeyCode.T) && lastTry < Time.time + acceptableOffset/2)
            Debug.Log(TryBeat());
    }

    public static bool TryBeat()
    {
        double offset = Mathf.Min((float)time,(float) (beatInterval - time));
        return offset < acceptable;
    }
    
    
    
}
