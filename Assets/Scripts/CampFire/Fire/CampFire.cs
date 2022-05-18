using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] public float bakeTimeCounter;
    [SerializeField] public float bakeTime;
    [SerializeField] private bool inFire;

    [Header("MarshMellow")] 
    [SerializeField] public GameObject woodObject;
    [SerializeField] public GameObject marshMellowObject;
    [SerializeField] public GameObject bakedMarshMellowObject;
    [SerializeField] public GameObject overBakedMarshMellowObject;

    [Header("Clones")]
    [SerializeField] private GameObject bakedMarshMellowClone;
    [SerializeField] private GameObject overBakedMarshMellowClone;
    [Header("Animation")] 
    [SerializeField] private Animator marshMellowAnim;

    private void Update()
    {
        if (inFire)
        {
            bakeTimeCounter += Time.deltaTime;
        }
        else
        {
            return;
        }

        if (bakeTimeCounter >= bakeTime)
        {
            if (bakeTimeCounter >= bakeTime + 2)
            {
                /*overBakedMarshMellowClone = Instantiate(overBakedMarshMellowObject, bakedMarshMellowObject.transform.position, Quaternion.identity);
                /*createdObject.transform.localScale = new Vector3(marshMellowObject.transform.localScale.x * woodObject.transform.localScale.x,
                    marshMellowObject.transform.localScale.y * woodObject.transform.localScale.y,
                    marshMellowObject.transform.localScale.z * woodObject.transform.localScale.z);#1#
                overBakedMarshMellowClone.transform.parent = woodObject.transform;
                Destroy(bakedMarshMellowClone);*/
                Debug.Log("OverBaked");
            }
            else
            {
                bakedMarshMellowClone = Instantiate(bakedMarshMellowObject, marshMellowObject.transform.position, Quaternion.identity);
                /*createdObject.transform.localScale = new Vector3(marshMellowObject.transform.localScale.x * woodObject.transform.localScale.x,
                    marshMellowObject.transform.localScale.y * woodObject.transform.localScale.y,
                    marshMellowObject.transform.localScale.z * woodObject.transform.localScale.z);*/
                bakedMarshMellowClone.transform.parent = woodObject.transform;
                Destroy(marshMellowObject); 
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Marshmellow")
        {
            inFire = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Marshmellow")
        {
            inFire = false;
        }
    }
}
