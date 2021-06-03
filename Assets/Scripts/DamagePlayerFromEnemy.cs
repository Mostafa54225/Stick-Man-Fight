using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerFromEnemy : MonoBehaviour
{
    [SerializeField] private playerHealth playerHealth;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemyBullet"))
        {
            Destroy(collision.gameObject);
            playerHealth.takeDamage(1.0f);
        }
    }
}
