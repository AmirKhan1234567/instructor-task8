using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Animator animator;
    private Rigidbody2D player;
    private Vector2 startpos;
    private bool stair = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput !=0 && stair)
        {
            player.isKinematic = true;
            player.velocity = new Vector2(player.velocity.x, verticalInput * speed);
        }
        if (horizontalInput != 0)
        {
            if (horizontalInput > 0)
            {
                transform.Translate(Vector2.right * speed * horizontalInput * Time.deltaTime);
                transform.localEulerAngles = new Vector2(0, 0);
                animator.SetFloat("run", horizontalInput);
            }
            else if (horizontalInput < 0)
            {
                transform.Translate(Vector2.left * speed * horizontalInput * Time.deltaTime);
                transform.localEulerAngles = new Vector2(0, 180);
                animator.SetFloat("run", -horizontalInput);
            }
        }
        else
        {
            animator.SetFloat("run", 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            player.AddForce(Vector2.up * 1, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            transform.position = startpos;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stairs"))
        {
            stair = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stairs"))
        {
            stair = false;
            player.isKinematic = false;
        }
    }
}