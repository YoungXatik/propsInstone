using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectDragging : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    [SerializeField] private Vector3 maxLeftPos;
    [SerializeField] private Vector3 maxRightPos;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 currentPos;
    [SerializeField] private bool dragging;
    [SerializeField] private GameObject draggingObject;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        startPos = draggingObject.transform.position;
    }

    private void Update()
    {
        if (dragging == true)
        {
            currentPos = draggingObject.transform.position;
            float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
        }
        else
        {
            return;
        }
    }

    private void OnMouseUp()
    {
        dragging = false;
        if (currentPos.x >= maxRightPos.x)
        {
            //gameObject.transform.position = startPos;
            gameObject.transform.DOMove(startPos, 0.5f);
        }
        else if (currentPos.x <= maxLeftPos.x)
        {
            //gameObject.transform.position = startPos;
            gameObject.transform.DOMove(startPos, 0.5f);
        }
        else if(gameObject.transform.position != maxLeftPos || gameObject.transform.position != maxRightPos)
        {
            Debug.Log("All okey");
        }
    }

    private void OnMouseDown()
    {
        dragging = true;
    }
}
