using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class Bee : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private Transform targetPoint;
    [SerializeField] public GameObject deathEffect;
    [SerializeField] public BeeSpawner beeSpawner;

    private void Start()
    {
        beeSpawner = FindObjectOfType<BeeSpawner>();
        Random random = new Random();
        speed = random.Next(1, 5);
        targetPoint = GameObject.FindWithTag("TargetPoint").GetComponent<Transform>();
        gameObject.transform.DOMove(targetPoint.position, speed).SetEase(Ease.Linear);
    }

    private void OnMouseDown()
    {
        beeSpawner.beeCount--;
        Destroy(gameObject);
        var objectEffect = Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(objectEffect,2f);
        
    }
}
