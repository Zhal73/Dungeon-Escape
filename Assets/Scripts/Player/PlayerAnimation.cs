using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //handle to Animator
    private Animator _playerAnimator;

    //reference to sword animation
    private Animator _swordAnimator;


    // Start is called before the first frame update
    void Start()
    {
        //assign handler to animator
        //_playerAnimator = GetComponentInChildren<Animator>();
        _playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        //anim set Move to move  
        _playerAnimator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _playerAnimator.SetBool("Jumping",jumping);
    }

    public void Attack()
    {
            _playerAnimator.SetTrigger("Attack");
            //play sword anim
            _swordAnimator.SetTrigger("SwordAnimation");
    }


}
