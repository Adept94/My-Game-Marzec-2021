using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int healthEnemy;

    public bool canAttack;
    [HideInInspector] public float shootTime;
    public float timeBtwShoots;
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        shootTime = Random.Range(0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void EnemyDamage(int damage)
    {
        healthEnemy -= damage;

        if(healthEnemy < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameVisible()
    {
        canAttack = true;
    }
}
