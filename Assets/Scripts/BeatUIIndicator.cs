using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BeatUIIndicator : MonoBehaviour
{
    [SerializeField] private float duration = 0.3f;
    
    private Image image;

    private void OnEnable()
    {
        Beat.OnBeat += OnBeat;
    }

    private void OnDisable()
    {
        Beat.OnBeat -= OnBeat;
    }

    private void OnBeat()
    {
        if (image is null)
            image = GetComponent<Image>();

        image.DOFade(1, duration).From();
    }
}
