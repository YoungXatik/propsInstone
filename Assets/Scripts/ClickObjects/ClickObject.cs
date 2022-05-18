
using System;
using DG.Tweening;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] public GameObject clickObject;

    [SerializeField] public Vector3 currentClickPos;
    [SerializeField] public Vector3 finalClickPos;
    [SerializeField] public Vector3 startClickPos;

    [SerializeField] public float clickObjectWeight;
    [SerializeField] public Animator clickObjectAnimator;
    [SerializeField] public int shakeMultiple;
    [SerializeField] public int clicksToMultiple;
    [SerializeField] public ParticleSystem effect;
    [SerializeField] public GameObject completeEffect;
    [SerializeField] public ClickObjectData clickObjectData;

    [Header("PlayerScripts")] 
    [SerializeField] public PlayerStats playerStats;
    [Header("ClickObjectShake")]
    [SerializeField] public float shakeAngle;
    [Range(0,1)]
    [SerializeField] public float shakeDuration;
    
    private void Start()
    {
        clickObject = GameObject.FindWithTag("ClickObject");
        clickObjectAnimator = clickObject.GetComponent<Animator>();
        playerStats = FindObjectOfType<PlayerStats>();
        clickObjectWeight = clickObjectData.weight;
        completeEffect.SetActive(false);
        startClickPos = clickObject.transform.position;
    }


    public void ObjectShake()
    {
        /*if (shakeMultiple == 1)
        {
            clickObjectAnimator.SetBool("ShakeStart",true);
            clickObjectAnimator.SetBool("ShakeStart1",false);
        }
        else if(shakeMultiple == 2)
        {
            clickObjectAnimator.SetBool("ShakeStart1", true);
            clickObjectAnimator.SetBool("ShakeStart",false);
            clickObjectAnimator.SetBool("ShakeStart2",false);
        }
        else if (shakeMultiple == 3 || shakeMultiple > 3)
        {
            clickObjectAnimator.SetBool("ShakeStart2", true);
            clickObjectAnimator.SetBool("ShakeStart1", false);
            clickObjectAnimator.SetBool("ShakeStart",false);
        }*/
       // clickObject.transform.DOShakePosition(_duration, _strength, _vibrato, _randomness, _fadeout);
       var Seq = DOTween.Sequence();
       
       Seq.Append(clickObject.transform.DORotate(
           new Vector3(clickObject.transform.rotation.x, clickObject.transform.rotation.y,
               clickObject.transform.rotation.z + shakeAngle), shakeDuration)).SetEase(Ease.Linear);
       Seq.Append(clickObject.transform.DORotate(
           new Vector3(clickObject.transform.rotation.x, clickObject.transform.rotation.y,
               clickObject.transform.rotation.z - shakeAngle), shakeDuration)).SetEase(Ease.Linear);
       Seq.Append(clickObject.transform.DORotate(
           new Vector3(clickObject.transform.rotation.x, clickObject.transform.rotation.y,
               0), shakeDuration)).SetEase(Ease.Linear);
    }

    public void ObjectShakeEnd()
    {
        clickObjectAnimator.SetBool("ShakeStart",false);
        clickObjectAnimator.SetBool("ShakeStart1",false);
        clickObjectAnimator.SetBool("ShakeStart2",false);
    }

    public void PlayEffect()
    {
        effect.Play();
    }
    

    public void PlayCompleteEffect()
    {
        completeEffect.SetActive(true);
    }
    


}
