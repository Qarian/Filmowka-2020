using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    private void OnBeat()
    {
        camera.DOFieldOfView(camera.fieldOfView + 0.1f, 0.1f);
        camera.DOFieldOfView(camera.fieldOfView - 0.1f, 0.1f);

    }
}
