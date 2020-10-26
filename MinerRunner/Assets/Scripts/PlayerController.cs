using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public SpriteRenderer sprite;
    public AudioSource sound;
    [HideInInspector] public Animator m_animator;
    public GameObject score;
    private Score scoreScript;

    private float stun;
    private float velX;
    public float jump;
    public float speed;
    private bool stunned;
    private bool isJumping;
    private bool speedBoost;
    private bool jumpBoost;
    private bool killBoost;
    private float boostTimer;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = score.GetComponent<Score>();
        playerRB = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_animator.SetBool("isDead",false);
        isJumping = false;
        stunned = false;
        speed = 5;
        jump = 400;
    }

    // Update is called once per frame
    void Update()
    {
        if(stun > 0f){
            stunned = true;
            stun -= Time.deltaTime;
            PlayerBlinking();
        }else{
            stunned = false;
        }
        
    }

    private void FixedUpdate() {

        if(speedBoost){
            speed = 10;
            boostTimer -= Time.deltaTime;
            sprite.material.color = Color.green;

            if(boostTimer < 0){
                speedBoost = false;
            }

        }else{
            speed = 5;
            sprite.material.color = Color.white;
        }

        if(jumpBoost){
            jump = 800;
            boostTimer -= Time.deltaTime;
            sprite.material.color = Color.blue;

            if(boostTimer < 0){
                jumpBoost = false;
            }
        }else{
            jump = 600;
            sprite.material.color = Color.white;
        }

        if(killBoost){
            boostTimer -= Time.deltaTime;
            sprite.material.color = Color.red;
            if(boostTimer < 0){
                killBoost = false;
                sprite.material.color = Color.white;
            }
        }

        if(!stunned){

             if(Input.GetKey(KeyCode.D)){
                    velX = speed;
            }
            else if(Input.GetKey(KeyCode.A)){
                    velX = -speed;
            }else{
                    velX = 0;
            }

             if(Input.GetKey(KeyCode.Space) && !isJumping){
                playerRB.AddForce(Vector3.up * jump);
                isJumping = true;
            }
 
             playerRB.velocity = new Vector3(velX - 2,playerRB.velocity.y,0);
             sprite.enabled = true;
        }

        if(stunned){
            playerRB.velocity = new Vector3(0 - 2,playerRB.velocity.y,0);
        }


       
       
    }

    private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.tag == "Floor" || other.gameObject.tag == "Platform" || other.gameObject.tag == "Block"){
            isJumping = false;
        }

        if(other.gameObject.tag == "Diamond"){

            scoreScript.updateScore += 100;
            boostTimer = 5;
            Destroy(other.gameObject);
            sound.Play();

        }else if (other.gameObject.tag == "Sapphire"){
            
            jumpBoost = true;
            boostTimer = 5;
            Destroy(other.gameObject);
            sound.Play();



        }else if (other.gameObject.tag == "Jade"){
            
            speedBoost = true;
            boostTimer = 5;
            Destroy(other.gameObject);
            sound.Play();


        }else if (other.gameObject.tag == "Ruby"){
            
            killBoost = true;
            boostTimer = 5;
            Destroy(other.gameObject);
            sound.Play();


        }


        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Bat1" || other.gameObject.name == "Bat2" && !killBoost){
            stun = 3f;
        }

        if(other.gameObject.name == "CollapsingCave" || other.gameObject.name == "KillFloor"){
            m_animator.SetBool("isDead", true);
            SceneManager.LoadScene("Main");
        }

    }

    private void PlayerBlinking(){
       
            if(sprite.enabled == true){
                sprite.enabled = false;
            }else{
                sprite.enabled = true;
            }   
             
    }
}
