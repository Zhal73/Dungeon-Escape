using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player : MonoBehaviour
{
    // get reference to rigidbody
    private Rigidbody2D _playerRigidbody;
    //player speed
    [SerializeField] float _playerSpeed = 3.0f;

    //Variable for jump force
    [SerializeField] private float _jumpForce = 5.0f;

    [SerializeField] private bool _resetJump = false;
    private bool _grounded;

    //handler to playerAnimation
    private PlayerAnimation _playerAnimation;
    //hanlde to SpriteRenderer
    private SpriteRenderer _playerSpriteRenderer;
    
    private SpriteRenderer _swordSpriteReneder;
    

    private bool _isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        //assign handle to rigidbody  
        _playerRigidbody = GetComponent<Rigidbody2D>();
        //assign handle playerAnimation
        _playerAnimation = GetComponent<PlayerAnimation>();
        //assign SpriteRenderer
        // _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _playerSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _swordSpriteReneder = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    private void Movement()
    {
        // horizontal input for left/right
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();

        if(horizontalInput > 0)
        {
            _isFacingRight = true;
        }
        else if (horizontalInput < 0)
        {
            _isFacingRight = false;
        }

        Flip(_isFacingRight);
        
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            // jump
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnimation.Jump(true);
        }

        // current velocity = new velocity(x, current velocity.y);
        _playerRigidbody.velocity = new Vector2(horizontalInput * _playerSpeed, _playerRigidbody.velocity.y);
        _playerAnimation.Move(horizontalInput);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnimation.Attack();
        }
    }


    private void Flip(bool _isFacingRight)
    {
        if (_isFacingRight == true)
        {
            _playerSpriteRenderer.flipX = false;
            _swordSpriteReneder.flipY = false;

            Vector2 newPos = _swordSpriteReneder.transform.localPosition;
            newPos.x = 0.4f;
            _swordSpriteReneder.transform.localPosition = newPos;
        }
        else if (_isFacingRight == false)
        {
            _playerSpriteRenderer.flipX = true;
            _swordSpriteReneder.flipY = true;

            Vector2 newPos = _swordSpriteReneder.transform.localPosition;
            newPos.x = -0.4f;
            _swordSpriteReneder.transform.localPosition = newPos;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down * 0.6f, 1 << 8);
        Debug.Log(hitInfo.transform.name);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(1f);
        _resetJump = false;
    }
}
