using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;
    private float stun;
    private float velX;
    public float jump;
    public float speed;
    private bool stunned;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        isJumping = false;
        stunned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stun > 0f){
            stunned = true;
            stun -= Time.deltaTime;
        }else{
            stunned = false;
        }
        
    }

    private void FixedUpdate() {

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
 
             playerRB.velocity = new Vector3(velX,playerRB.velocity.y,0);
        }

       
       
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Bat1"){
            stun = 3f;
            Debug.Log("Hit");
        }

        if(other.gameObject.tag == "Floor" || other.gameObject.tag == "Platform" || other.gameObject.tag == "Block"){
            Debug.Log("Landed");
            isJumping = false;
        }

        
    }
}
