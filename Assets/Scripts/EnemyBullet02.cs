using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet02 : MonoBehaviour
{

    public float bulletSpeed;

    private Vector3 Direction;

    public int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        Direction = PlayerController.instance.transform.position - transform.position;
        Direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth.instance.DamagePlayer(damageAmount);

            Destroy(this.gameObject);
        }

        if (other.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }


    }



    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
