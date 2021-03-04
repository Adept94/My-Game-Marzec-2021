using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChort : EnemyBehavior
{
    public bool noObstacle;

    // Start is called before the first frame update
    void Start()
    {
        shootTime = Random.Range(0, 1f);

        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        // shooting
        if (noObstacle && canAttack && shootTime < 0)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);

            shootTime = Random.Range(1f, timeBtwShoots);
        }
        else
        {
            shootTime -= Time.deltaTime;
        }

        Vector3 playerPos = PlayerController.instance.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerPos);


        if(hit.collider.tag == "Obstacle")
        {
            noObstacle = false;
        } else
        {
            noObstacle = true;
        }




        Debug.DrawLine(transform.position, hit.point, Color.red);


    }
}
