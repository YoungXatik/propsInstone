using System;
using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private float driveTime;
    [SerializeField] private float driveTimeCounter;
    [SerializeField] private Image fuelBarImage;
    [SerializeField] private ArcadeKart arcadeKart;

    private void Start()
    {
        arcadeKart.enabled = true;
        fuelBarImage.DOFillAmount(0, driveTime).SetEase(Ease.Linear);
    }

    private void Update()
    {
        driveTimeCounter += Time.deltaTime;
        if (driveTimeCounter >= driveTime)
        {
            arcadeKart.enabled = false;
        }
        
        
    }

    public void MuteEngine()
    {
        var kartSpeed = arcadeKart.baseStats.TopSpeed;
        //сделать тут плавное затухание скорости карта, чтобы немного проехаться можно было
    }

    public void ContinueDriving()
    {
        driveTime -= driveTimeCounter;
        driveTimeCounter = 0;
        fuelBarImage.fillAmount = 1f;
        fuelBarImage.DOFillAmount(0, driveTime).SetEase(Ease.Linear);
    }
}
