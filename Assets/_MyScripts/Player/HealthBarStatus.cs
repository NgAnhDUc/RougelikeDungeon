using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarStatus : MonoBehaviour
{
    [SerializeField] public float maxHealth;

    private void Awake()
    {
        maxHealth = transform.GetComponentInParent<PlayerStatus>().heath;
       
    }
    // Update is called once per frame
    void Update()
    {
        float currentHealth = transform.GetComponentInParent<PlayerStatus>().heath;
        transform.GetChild(1).GetComponent<Image>().fillAmount = currentHealth/maxHealth;
    }


}
