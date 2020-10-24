using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveUp = Input.GetAxisRaw("Vertical");
        float moveSide = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSide * moveSpeed, moveUp * moveSpeed);
    }
}
