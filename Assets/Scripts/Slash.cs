using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slash : MonoBehaviour
{
    [SerializeField] private Transform[] weapons;
    [SerializeField] private Destroyer destroyerTrigger;
    [SerializeField] private Vector3 rotation = new Vector3(0,0,-110);
    [SerializeField] private float duration = 0.1f;
    
    private int weaponToSlash = 0;
    private float lastSlash = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > lastSlash + duration && Beat.TryBeat())
            Ciach();
    }

    private void Ciach()
    {
        lastSlash = Time.time;
        destroyerTrigger.gameObject.SetActive(true);
        
        Quaternion targetRotation = weapons[weaponToSlash].localRotation * Quaternion.Euler(rotation);
        weapons[weaponToSlash].DOLocalRotateQuaternion(targetRotation, duration)
            .SetLoops(2, LoopType.Yoyo)
            .OnStepComplete(() => destroyerTrigger.gameObject.SetActive(false));
        
        weaponToSlash = ++weaponToSlash % weapons.Length;
    }
}
