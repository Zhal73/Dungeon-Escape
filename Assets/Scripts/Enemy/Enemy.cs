using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;   //protected = only object that ihnerit can modify it.
    [SerializeField] protected int speed;    //protected = only object that ihnerit can modify it.
    [SerializeField] protected int gems;     //protected = only object that ihnerit can modify it.

    [SerializeField] protected Transform pointA, pointB; //waypoints

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    private void Start()
    {
        Init();
    }
    //Initalization function
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    public virtual void Movement()
    {
        //face the Enemy sprite in the correct direction
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        //set the target waypoint
        if (this.transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (this.transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        //move the Enemy
        this.transform.position = Vector3.MoveTowards(this.transform.position, currentTarget, speed * Time.deltaTime);
    }

    public virtual void Update()
    {
        //if idle animation  in playing
        //do nothing
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }
}
