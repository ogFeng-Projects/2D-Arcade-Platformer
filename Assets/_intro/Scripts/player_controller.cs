using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject bullet;
    private float horizontal;
    public float forceJump = 250f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        Move();
        BounceMovement();


        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

        float moveX = x * speed;
        //float moveY = y * speed;
        rb.velocity = new Vector2(moveX, 0) * speed;
        //rb.velocity = new Vector2(moveX, moveY);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * forceJump);
    }

    void BounceMovement()
    {
        float distance = (this.transform.position - Camera.main.transform.position).z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance)).y;


        Vector3 playerSize = GetComponent<Renderer>().bounds.size;

        this.transform.position = new Vector3(
        Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 2, rightBorder - playerSize.x / 2),
        Mathf.Clamp(this.transform.position.y, topBorder + playerSize.x / 2, bottomBorder - playerSize.x / 2),
        this.transform.position.x
        );
    
    
    
    
    
    }
}
