using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float speed;

    public float destroyTime;

    public int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed * Time.fixedDeltaTime;

        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if(other.GetComponent<EnemyBehavior>() != null)
            {
                other.GetComponent<EnemyBehavior>().EnemyDamage(damageAmount);

                Destroy(gameObject);

            }
        }

        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
        }

        if(other.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

       // Debug.Log(other.name);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
