using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int healthPlayerMax;
    [HideInInspector] public int healthPlayerCurrent;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthPlayerCurrent = healthPlayerMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        healthPlayerCurrent -= 1;
    }
}
