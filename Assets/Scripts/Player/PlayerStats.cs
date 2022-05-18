using System;
using System.Collections;
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
    [SerializeField] public GameObject finalPoint;
    [Header("Timing")]
    [Range(0,2)]
    [SerializeField] public float timeBetweenObjectGoesBack;
    [SerializeField] public float distanceToChange;
    [SerializeField] public float clickDelay;
    [SerializeField] public float clickDelayCounter;
    [Header("PlayerUI")] 
    [SerializeField] private Text moneyCounter;
    [SerializeField] private Animator completeAnimator;

    [Header("Object")] [SerializeField] public ClickObject clickObject;


    private void Update()
    {
        moneyCounter.text = money.ToString();
        clickDelayCounter += Time.deltaTime;
        if (clickDelayCounter >= clickDelay)
        {
            StartCoroutine(GiveObjectBack());
        }
    }

    public void Click()
    {
        if (clickObject.currentClickPos.y >= clickObject.finalClickPos.y)
        {
            Debug.Log("Win!");
            Invoke("CompleteLevel",1f);
            clickDelayCounter = -100;
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
           if (clickScores % 10 == 0)
           {
              // Camera.main.DOShakePosition(_duration, _strength, _vibrato, _randomness, _fadeout);
              clickObject.PlayEffect();
           }

           if (clickScores % clickObject.clicksToMultiple == 0)
           {
               clickObject.shakeAngle += 1;
               clickObject.shakeDuration += 0.02f;
           }

           clickDelayCounter = 0;
        }
    }

    public void CompleteLevel()
    {
        Camera.main.transform.DOMove(finalPoint.transform.position, 1f);
        clickObject.PlayCompleteEffect();
        completeAnimator.SetBool("Complete",true);
    }

    IEnumerator GiveObjectBack()
    {
        if (Mathf.Abs(clickObject.clickObject.transform.position.y) < Mathf.Abs(clickObject.startClickPos.y))
        {
            clickObject.clickObject.transform.position = clickObject.clickObject.transform.position +  new Vector3(0, -distanceToChange,0);
            Debug.Log("Start");
            if (clickObject.shakeDuration >= 0.08f)
            {
                clickObject.shakeDuration -= 0.01f;
            }
            else if(clickObject.shakeDuration <= 0.08f)
            {
                clickObject.shakeDuration = 0.08f;
            }
        }
        else if(Mathf.Abs(clickObject.clickObject.transform.position.y) >= Mathf.Abs(clickObject.startClickPos.y))
        {
            StopAllCoroutines();
            Debug.Log("Finish");
            clickObject.shakeAngle = 1;
            clickObject.shakeDuration = 0.08f;
        }
        yield return new WaitForSeconds(timeBetweenObjectGoesBack);
    }
    

    
}
