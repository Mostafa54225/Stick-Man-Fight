using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public GameObject playerPosition;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerPosition.transform.position + new Vector3(0,2.99f,0);
    }
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(1f, .45f);
        
    }

    

    public void setSize(float sizeNormalized)
    {
        if (sizeNormalized < 0) sizeNormalized = 0;
        bar.localScale = new Vector3(sizeNormalized, .45f);
    }
}
