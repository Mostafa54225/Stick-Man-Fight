using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionOnPlayer : MonoBehaviour
{
    public GameObject playerPosition;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerPosition.transform.position;
    }
}
