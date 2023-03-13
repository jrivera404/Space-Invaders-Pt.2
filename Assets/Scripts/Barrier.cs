using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int health = 3;
    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Barrier Destroyed.");

        }
    }
}
