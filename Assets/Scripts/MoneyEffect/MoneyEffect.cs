using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyEffect : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
