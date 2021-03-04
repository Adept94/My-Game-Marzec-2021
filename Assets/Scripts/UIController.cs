using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + PlayerHealth.instance.healthPlayerMax + "/" + PlayerHealth.instance.healthPlayerCurrent;
    }
}
