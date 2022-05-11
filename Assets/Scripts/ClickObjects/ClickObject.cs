
using System;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] public GameObject clickObject;

    [SerializeField] public Vector3 currentClickPos;
    [SerializeField] public Vector3 finalClickPos;

    [SerializeField] public float clickObjectWeight;
    [SerializeField] public Animator clickObjectAnimator;

    [Header("PlayerScripts")] 
    [SerializeField] public PlayerStats playerStats;
    
    private void Start()
    {
        clickObject = GameObject.FindWithTag("ClickObject");
        clickObjectAnimator = clickObject.GetComponent<Animator>();
        playerStats = FindObjectOfType<PlayerStats>();
    }
    

    public void ObjectShake()
    {
        clickObjectAnimator.SetBool("ShakeStart",true);
    }

    public void ObjectShakeEnd()
    {
        clickObjectAnimator.SetBool("ShakeStart",false);
    }

    public void CameraShakeStart()
    {
        playerStats.CameraShake();
    }
    
    
}
