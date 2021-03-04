using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float offset;

    public bool canRotate;

    public Transform shootPoint;
    public GameObject bullet;

    public float timeBtwShoots;
    private float shootCounter;


    // Start is called before the first frame update
    void Start()
    {
        shootCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if(canRotate)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }



        // shooting
        if(shootCounter < 0)
        {
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(Shooting(timeBtwShoots));
                shootCounter = timeBtwShoots;
            }
        } else 
        {
            shootCounter -= Time.deltaTime;
        }

    }

    public IEnumerator Shooting(float timeBtwShoots)
    {
        yield return new WaitForSeconds(timeBtwShoots);
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
