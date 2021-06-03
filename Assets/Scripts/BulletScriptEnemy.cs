using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptEnemy : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D rb;
    public GameObject hitFireEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("playerPos");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Floor"))
        {
            Instantiate(hitFireEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
