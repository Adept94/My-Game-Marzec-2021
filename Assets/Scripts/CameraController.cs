using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [HideInInspector] public Transform target;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        transform.position = new Vector3(PlayerController.instance.transform.position.x,
            PlayerController.instance.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            new Vector3(target.position.x, target.position.y, transform.position.z), moveSpeed * Time.deltaTime);
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
