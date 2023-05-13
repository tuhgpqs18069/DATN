using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 8f;
    private Rigidbody2D rb;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jumpButton()
    {
        
            //rb.velocity = Vector2.up * jumpSpeed;
            rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
        

    }

}
