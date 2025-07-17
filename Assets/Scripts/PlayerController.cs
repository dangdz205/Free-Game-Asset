using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator ani;
    [SerializeField] float moveSpeed;
    private float xInput;
    [Header("CollisionCheck")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundRadius;
    bool Grounded;
    bool canDoubleJump;
    [SerializeField] private float jumpForce;
    public HEALTH_BAR health;
     public float damage;
    public thanhmau thanhmau;
    public float mauhientai;
    public float mautoida = 10;
    public Text scoreText;
    public AudioClip getscore, die, gameover;
    public GameObject gameOver;
    
     float score;
    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        ani= GetComponent<Animator>();
    }
    private void Start()
    {
        mauhientai = mautoida;
        thanhmau.capnhatthanhmau(mauhientai, mautoida);
        score = 0;
        Time.timeScale = 1;

    }
    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) JumpController();
        CollisionCheck();
        AnimationCoontroller();
        Flip();
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    ani.SetBool("JUMP", true);
        //    Jump();
        //}
        //else ani.SetBool("JUMP", false);
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void JumpController()
    {
        if(Grounded)  Jump();
        else if(canDoubleJump)
        {
            canDoubleJump = false;
            Jump();
        }
        if(Grounded)  canDoubleJump = true;
    }
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
    private void Movement()
    {
        rb.velocity = new Vector2(xInput * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void AnimationCoontroller()
    {
        bool isMoving = rb.velocity.x != 0;
        ani.SetBool("isMoving", isMoving);
        ani.SetFloat("Xvelocity", rb.velocity.x);
        ani.SetFloat("Yvelocity", rb.velocity.x);
        ani.SetBool("Grounded", Grounded);
    }
    void Flip()
    {
        if(xInput != 0)
        {
            if (xInput < 0) transform.localScale = new Vector2(-1f, 1f);
            else transform.localScale = new Vector2(1f, 1f);
        }
    }
    void CollisionCheck()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);  
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            mauhientai -= 2;
            thanhmau.capnhatthanhmau(mauhientai, mautoida);
            if (mauhientai <= 0)
            {
                AudioSource.PlayClipAtPoint(gameover, transform.position, 20);
                Destroy(gameObject);
                Time.timeScale = 0;
               gameOver.SetActive(true);
            }
        }
        //if(collision.gameObject.tag == "Enemy")
        //{
        //    health.HEALTH(1);
        //}
        if(collision.gameObject.tag == "1")
        {
            mauhientai += 2;
            thanhmau.capnhatthanhmau(mauhientai, mautoida);
            if(mauhientai >= mautoida)
            {
                mauhientai = mautoida;
            }
        }
        if(collision.gameObject.tag == "coin")
        {
            score += 10;

            scoreText.text = score.ToString();

            AudioSource.PlayClipAtPoint(getscore, transform.position, 20);
            Destroy(collision.gameObject);



        }
        if (collision.gameObject.tag == "2")
        {
            
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(die, transform.position, 20);
            gameOver.SetActive(true);
            Time.timeScale = 0;

        }
        if (collision.gameObject.tag == "next3")
        {

            
            SceneManager.LoadScene("Scene3");


        }

    }

}
