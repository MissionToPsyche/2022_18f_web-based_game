using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class DistanceUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DistanceText;

    void Start()
    {
        DistanceText.text = "Distance: 0m";
    }

    // Update is called once per frame
    void Update()
    {
        float score = FindObjectOfType<psycheResourceController>().getDistance();
        int scoreInt = (int)Math.Round(score);
        DistanceText.text = "Distance: " + scoreInt.ToString() + "m";
    }
}
