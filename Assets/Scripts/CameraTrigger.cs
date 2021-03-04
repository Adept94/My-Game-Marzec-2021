using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public List<GameObject> Enemies;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       /* if(playerInRoom)
        {
            foreach (GameObject enemy in Enemies)
            {
                if(enemy.gameObject.activeInHierarchy)
                {
                    enemy.gameObject.GetComponent<EnemyBehavior>().canAttack = true;
                }
            }
        }*/


        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CameraController.instance.ChangeTarget(transform);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraController.instance.ChangeTarget(transform);

        }
    }
}
