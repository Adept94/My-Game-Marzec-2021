using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashTimer : MonoBehaviour
{
    public Slider timerSlider;
   // private bool ignoreFirstDashUI = false;

    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = PlayerController.instance.timeBtwDash;
        timerSlider.value = PlayerController.instance.dashTime;
    }

    // Update is called once per frame
    void Update()
    {
        timerSlider.value = PlayerController.instance.dashTime;

        if (timerSlider.value > 0)
        {
            timerSlider.gameObject.SetActive(true);
        } else
        {
            timerSlider.gameObject.SetActive(false);
        }
    }
}
