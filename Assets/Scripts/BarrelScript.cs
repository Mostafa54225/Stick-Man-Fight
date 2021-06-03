using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class BarrelScript : MonoBehaviour
{
    private int health = 5;
    // materials to Flash The Enemy
    private Material matFlash;
    private Material matDefault;
    private Object explosionRef;
    SpriteRenderer sr;

    // for the player to get force if he is near by barrel
    public float fieldImpact;
    public float force;
    public LayerMask LayerToHit;

    public GameObject playerPosition;
    //public GameObject enemyPosition;
    
    [SerializeField] private playerHealth playerHealth;
    //[SerializeField] private healthEnemyScript healthEnemy;

    GameObject[] enemies;

    //public GameObject HealthBarEnemy;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        matFlash = Resources.Load<Material>("Flash");
        matDefault = sr.material;
        explosionRef = Resources.Load("WFXMR_ExplosiveSmoke Big");
        playerPosition = GameObject.FindGameObjectWithTag("playerPos");
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health--;
            sr.material = matFlash;
            if(health <= 0)
            {
                killSelf();
            } else
            {
                Invoke("ResetMaterial", 0.01f);
            }
        }
        if(collision.CompareTag("enemyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }
    void killSelf()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);

        SoundScript.playSound("Explosion+3");


        
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldImpact, LayerToHit);
        foreach(Collider2D obj in objects)
        { 
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        

        
        // for damagin the player
        if (Vector2.Distance(playerPosition.transform.position, gameObject.transform.position) < 9f)
        {
            playerHealth.takeDamage(5.0f);
        }

        // for damaging Enemies
        for(int i = 0; i < enemies.Length; i++)
        {
            if(Vector2.Distance(gameObject.transform.position, enemies[i].transform.position) < 9f)
            {
                enemies[i].GetComponent<Enemy>().takeDamage(5.0f);
            }
        }

        
        CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, fieldImpact);
    }
}
