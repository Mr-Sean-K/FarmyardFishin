using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    public float xLimit = 28;

    void Update()
    {
        // destroys animals and fish that go off screen
        if (transform.position.x < -xLimit){
            Destroy(gameObject);
        }
        else if (transform.position.x > xLimit){
            Destroy(gameObject);
        }
    }
}