using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEALTH_BAR : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    public float currentHealth;
    public int healthMax = 4;
    //public float damge;
    private void Start()
    {
        currentHealth = healthMax;

    }

    public void HEALTH(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            //is dead
            Destroy(gameObject);
        }
    }
}
