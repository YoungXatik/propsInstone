using UnityEngine;
using UnityEngine.UI;

public class CampManager : MonoBehaviour
{
    [SerializeField] public int healthPoints;
    [SerializeField] public ParticleSystem damageEffect;
    [SerializeField] public GameObject hitEffect;
    
    [Header("Timer")]
    [SerializeField] private Text Minutes;
    [SerializeField] private Text Seconds;

    [SerializeField] private float param;
    
    [SerializeField] public float Minutes1;
    [SerializeField] public float Seconds1;

    [Header("Bees")]
    [SerializeField] public BeeSpawner beeSpawner;

    private void Update()
    {
        if (healthPoints <= 0)
        {
            Debug.Log("Failed");
            beeSpawner.StopAllCoroutines();
            EndGame();
        }
        
        Seconds1 -= Time.deltaTime;

        if (Minutes1 <= 0 && Seconds1 <= 0)
        {
            if (beeSpawner.beeCount == 0)
            {
                EndGame();
            }
        }

        if (Seconds1 <= 0 && Minutes1 >= 1)
        {
            Minutes1--;
            Seconds1 = 60;
        }

        Seconds.text = Mathf.Round(Seconds1).ToString();
        Minutes.text = Mathf.Round(Minutes1).ToString();
        if (Seconds1 <= 0)
        {
            Seconds1 = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bee")
        {
            healthPoints--;
            beeSpawner.beeCount--;
            Destroy(other.gameObject);
            PlayDamageEffect();
            Instantiate(hitEffect, other.gameObject.transform.position,Quaternion.identity);
        }
    }

    public void PlayDamageEffect()
    {
        damageEffect.Play();
    }

    public void EndGame()
    {
        //Завершение игры
        Minutes1 = 0;
        Seconds1 = 0;
        Debug.Log("EndGame");
    }
}
