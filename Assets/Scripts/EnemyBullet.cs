using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    private Vector3 Direction;
    public float bulletSpeed;

    public int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Direction = PlayerController.instance.transform.position - transform.position;
        Direction.Normalize();

    }

    private void FixedUpdate()
    {
        rb.velocity = Direction * bulletSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth.instance.DamagePlayer(damageAmount);

            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
