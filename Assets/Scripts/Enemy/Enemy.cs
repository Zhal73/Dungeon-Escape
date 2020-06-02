using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;   //protected = only object that ihnerit can modify it.
    [SerializeField] protected int speed;    //protected = only object that ihnerit can modify it.
    [SerializeField] protected int gems;     //protected = only object that ihnerit can modify it.

    [SerializeField] protected Transform pointA, pointB; //waypoints
    public virtual void Attack()  //may or maynot be further implemented in the child class
    {
        Debug.Log("My name is: " + this.gameObject.transform.name);
    }

    public abstract void Update(); //must be implemented in the child class
}
