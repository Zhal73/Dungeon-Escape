using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HIT : " + other.name);  
    }
}
