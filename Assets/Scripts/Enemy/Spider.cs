using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _spiderSprite;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _spiderSprite = GetComponentInChildren<SpriteRenderer>();    
    }

    public override void Update()
    {
        //if idle animation is playing 
        //do nothing
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    private void Movement()
    {
        //face the spider sprite in the correct direction
        if (_currentTarget == pointA.position)
        {
            _spiderSprite.flipX = true;
        }
        else
        {
            _spiderSprite.flipX = false;
        }

        //set the target waypoint
        if (this.transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (this.transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");
        }
        //move the spider sprite
        this.transform.position = Vector3.MoveTowards(this.transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
