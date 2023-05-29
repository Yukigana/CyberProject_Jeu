using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Champion")]
    [SerializeField] private Champion champion;

    Rigidbody2D _rigidbody;

    public bool isPlayer1;

    public bool isCrounch;
    public bool canMoving;
    public bool doubleJump;
    public bool isRunning;
    public bool isGrounded;
    [SerializeField] Transform checkGround;
    [SerializeField] LayerMask whatIsGround;

    private float moveX;

    public bool isFlip;
    private Animator anim;



    public Transform attackPoint;
    private void Awake()
    {
        if (isPlayer1) champion = GameManager.player1;
        else champion = GameManager.player2;
    }

    // appelé après la première frame
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = champion.getAnimator();
    }

    // appelé à chaque frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.position, 0.5f, whatIsGround);

        anim.SetBool("isGrounded", isGrounded);

        if (moveX == 1 || moveX == -1) anim.SetBool("isMoving", true);
        else anim.SetBool("isMoving", false);
        
        Jump();
        Run();
        Move();
        Crounch();
    }

    private void Move()
    {
        if (!canMoving && !isCrounch)
        {
            if (isPlayer1)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    moveX = -1f;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    moveX = 1f;
                }
                else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Q)) moveX = 0f;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
                {
                    moveX = -1f;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    moveX = 1f;
                }
                else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) moveX = 0f;
            }


            Debug.Log(moveX);


            Vector2 movement;
            if (isRunning) movement = new Vector2(moveX * (champion.getMovementSpeed() * 2) * Time.fixedDeltaTime, _rigidbody.velocity.y);
            else movement = new Vector2(moveX * champion.getMovementSpeed() * Time.fixedDeltaTime, _rigidbody.velocity.y);

            _rigidbody.velocity = movement;
        }
        if ((moveX < 0 && !isFlip) || (moveX > 0 && isFlip)) Flip();
    }


    // Change le sens du sprite (droite ou gauche)
    private void Flip()
    {
        isFlip = !isFlip;

        Vector3 t = transform.localScale;
        t.x *= -1;
        transform.localScale = t;
    }


    private void Jump()
    {
        anim.SetFloat("VerticalSpeed", _rigidbody.velocity.y);

        // Quand la barre espace est appuyé et que le personnage est au sol alors le saut est effectué 
        // Il est néammoins possible de faire un double saut 
        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (isGrounded)
                { // Saut depuis le sol            
                    doubleJump = true; // Quand il est au sol on recharge le double saut
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, champion.getJumpForce());
                }
                else if (doubleJump)// Saut depuis les airs
                {
                    doubleJump = false; // Le saut n'est pas fait depuis le sol donc on utilise le double saut 
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, champion.getJumpForce());
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isGrounded)
                { // Saut depuis le sol            
                    doubleJump = true; // Quand il est au sol on recharge le double saut
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, champion.getJumpForce());
                }
                else if (doubleJump)// Saut depuis les airs
                {
                    doubleJump = false; // Le saut n'est pas fait depuis le sol donc on utilise le double saut 
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, champion.getJumpForce());
                }
            }
        }
    }

    private void Run()
    {
        // Quand la touche Shift gauche est appuyée la course est activée
        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = true;
                anim.SetBool("isRunning", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift)) // Quand la touche Shift gauche n'est pas appuyée la course est désactivé
            {
                isRunning = false;
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                isRunning = true;
                anim.SetBool("isRunning", true);
            }
            else if (Input.GetKeyUp(KeyCode.RightShift)) // Quand la touche Shift gauche n'est pas appuyée la course est désactivé
            {
                isRunning = false;
                anim.SetBool("isRunning", false);
            }
        }
    }

    private void Crounch()
    {
        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                isCrounch = true;
                // On change d'animation
                anim.SetBool("isCrounching", true);

                // On réduit la boite de collision
                this.GetComponent<BoxCollider2D>().size = new Vector2(1.17f, 1.3f);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                isCrounch = false;
                anim.SetBool("isCrounching", false);
                this.GetComponent<BoxCollider2D>().size = new Vector2(1.4f, 2f);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isCrounch = true;
                // On change d'animation
                anim.SetBool("isCrounching", true);

                // On réduit la boite de collision
                this.GetComponent<BoxCollider2D>().size = new Vector2(1.17f, 1.3f);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                isCrounch = false;
                anim.SetBool("isCrounching", false);
                this.GetComponent<BoxCollider2D>().size = new Vector2(1.4f, 2f);
            }
        }
    }

    public void CanMove()
    {
        canMoving = !canMoving;
    }

    public Champion GetChampion()
    {
        return champion;
    }
}
