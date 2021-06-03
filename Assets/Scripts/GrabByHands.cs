using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabByHands : MonoBehaviour
{
    private bool hold;
    public KeyCode mouseButton;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(mouseButton))
        {
            hold = true;
        } else
        {
            hold = false;
            Destroy(GetComponent<FixedJoint2D>());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hold)
        {
            Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();
            if(rb != null && !rb.CompareTag("barrel"))
            {
                FixedJoint2D fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                fj.connectedBody = rb;
            } else
            {
                FixedJoint2D fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            }
        }
    }
}
