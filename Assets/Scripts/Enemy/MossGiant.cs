using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _mossSprite;
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _mossSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        //if idle animation  in playing
        //do nothing
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        
        Movement();

    }

    private void Movement()
    {
        //face the Moss Giant sprite in the correct direction
        if (_currentTarget == pointA.position)
        {
            _mossSprite.flipX = true;
        }
        else
        {
            _mossSprite.flipX = false;
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

        //move the moss giant
        this.transform.position = Vector3.MoveTowards(this.transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
