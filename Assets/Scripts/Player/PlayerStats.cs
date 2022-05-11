using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = System.Random;

public class PlayerStats : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float powerPoints;
    [SerializeField] private int money;
    [SerializeField] private int moneyMultiplier;
    [SerializeField] private int clickScores;
    [SerializeField] private GameObject[] moneyEffects;
    [Header("PlayerUI")] 
    [SerializeField] private Text moneyCounter;
    [Header("Object")]
    [SerializeField] public ClickObject clickObject;
    [Header("CameraShake")]
    [SerializeField]
    [Range(0,5)]
    private float _duration = 2;
    [SerializeField]
    private Vector3 _strength = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField]
    [Range(0, 10)]
    private int _vibrato = 10;
    [SerializeField]
    [Range(0, 180)]
    private float _randomness = 90;
    [SerializeField]
    private bool _fadeout = true;

    private void Update()
    {
        moneyCounter.text = money.ToString();
    }

    public void Click()
    {
        if (clickObject.currentClickPos.y >= clickObject.finalClickPos.y)
        {
            Debug.Log("Win!");
        }
        else
        {
           clickObject.clickObject.transform.position = clickObject.clickObject.transform.position +  new Vector3(0, (powerPoints / clickObject.clickObjectWeight),0);
           money += 1 * moneyMultiplier;
           clickObject.ObjectShake();
           clickObject.currentClickPos = clickObject.clickObject.transform.localPosition;
           clickScores++;
           Random random = new Random();
           Instantiate(moneyEffects[new Random().Next(0, moneyEffects.Length)]);
        }
    }

    public void CameraShake()
    {
        if (clickScores % 10 == 0)
        {
            Camera.main.DOShakePosition(_duration, _strength, _vibrato, _randomness, _fadeout);    
        }
    }
}
