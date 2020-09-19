using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1)
        {
        scoreText.GetComponent<score>().scores -= 5;
        scoreText.GetComponent<score>().UpdateScore();
        Destroy(this.gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            scoreText.GetComponent<score>().scores += 10;
            scoreText.GetComponent<score>().UpdateScore();
        }
    }
}
