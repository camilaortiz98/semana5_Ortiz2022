using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidad = 10;

    private Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameController.scoreValue += 10;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
