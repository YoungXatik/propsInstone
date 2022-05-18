using System;
using KartGame.KartSystems;
using UnityEditor.SearchService;
using UnityEngine;

public class LoadMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] miniGameObjects;
    [SerializeField] private GameObject loadScreen;
    [SerializeField] private GameObject[] playerGameObjects;
    [SerializeField] public FuelManager fuelManager;
    [SerializeField] public ArcadeKart arcadeKart;

    private void Start()
    {
        fuelManager = FindObjectOfType<FuelManager>();
        arcadeKart = FindObjectOfType<ArcadeKart>();
        
        for (int i = 0; i < miniGameObjects.Length; i++)
        {
            miniGameObjects[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(loadScreen);
            fuelManager.enabled = false;
            arcadeKart.enabled = false;
            Invoke("LoadMiniGameObjects",2f);
        }
    }

    public void LoadMiniGameObjects()
    {
        for (int i = 0; i < miniGameObjects.Length; i++)
        {
            miniGameObjects[i].SetActive(true);
        }

        for (int i = 0; i < playerGameObjects.Length; i++)
        {
            playerGameObjects[i].SetActive(false);
        }
    }

    public void ConfirmButton()
    {
        Instantiate(loadScreen);
        Invoke("SetActiveObjectsBack",2f);
    }
    
    public void SetActiveObjectsBack()
    {
        arcadeKart.enabled = true;
        fuelManager.enabled = true;
        fuelManager.ContinueDriving();
        
        for (int i = 0; i < miniGameObjects.Length; i++)
        {
            Destroy(miniGameObjects[i]);
        }

        for (int i = 0; i < playerGameObjects.Length; i++)
        {
            playerGameObjects[i].SetActive(true);
        }

        
    }
}
