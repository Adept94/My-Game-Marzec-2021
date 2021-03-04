using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public bool canMove;
    public float moveSpeed;
    private Vector2 moveInput;

    public float dashSpeed;
    public float timeBtwDash;
    [HideInInspector] public float dashTime;
    public ParticleSystem dashFX;

    private Rigidbody2D rb;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dashTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();


        // flip
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
        }


        // dash
        if (dashTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DashMove();

                dashTime = timeBtwDash;
            }
        }
        else
        {
            dashTime -= Time.deltaTime;
        }



    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = moveInput * moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void DashMove()
    {
        Vector3 dashDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        dashDirection.Normalize();

        transform.position += dashDirection * dashSpeed * Time.deltaTime;
        
        Instantiate(dashFX, transform.position, Quaternion.identity);
    }
}
