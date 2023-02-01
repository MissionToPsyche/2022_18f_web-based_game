using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    private Image fuelBar;
    // Start is called before the first frame update
    void Start()
    {
        fuelBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fuelBar.fillAmount = FindObjectOfType<psycheResourceController>().getFuelPercentage();
    }
}
