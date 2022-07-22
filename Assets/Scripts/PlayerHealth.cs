using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float playerHitpoints = 100f;
    // Start is called before the first frame update

    public void TakeDamage(float damage)
    {

        playerHitpoints -= damage;

        if (playerHitpoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath(); 
        }
        

    }
}
