using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarEnemy : MonoBehaviour
{
    private Transform bar;
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(1f, .45f);
    }

    // Update is called once per frame
    public void setSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, .45f);
    }
}
