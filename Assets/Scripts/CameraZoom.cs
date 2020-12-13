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
    
    

    private void OnBeaCamerat()
    {
        Debug.LogError("DUASDJSAD");
        var seq = DOTween.Sequence();
        seq.Append( camera.DOFieldOfView(camera.fieldOfView + 10f, 0.1f));
        seq.Append( camera.DOFieldOfView(camera.fieldOfView - 10f, 0.1f));
       seq.Play();

    }
}
