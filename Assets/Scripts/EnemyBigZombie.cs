using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigZombie : EnemyBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        shootTime = Random.Range(0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // shooting
        if (canAttack && shootTime < 0)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);

            shootTime = Random.Range(1f, timeBtwShoots);
        }
        else
        {
            shootTime -= Time.deltaTime;
        }

    }


}
