using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float velocity = 5f;
    public float jumpForce = 70f;
    public GameObject BulletPrefab;

    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //const
    private const int IDLE = 0;
    private const int RUN = 1;
    private const int JUMP = 2;
    private const int SLIDE = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUN);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            changeAnimation(SLIDE);
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            Disparar();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goldCoin") || collision.gameObject.CompareTag("silverCoin")|| collision.gameObject.CompareTag("bronzeCoin"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void Disparar()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bulletGO = Instantiate(BulletPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
        if (sr.flipX)
        {
            var controller = bulletGO.GetComponent<BalaController>();
            controller.velocidad *= -1;
        }
        else
        {
            
        }
    }
   
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
