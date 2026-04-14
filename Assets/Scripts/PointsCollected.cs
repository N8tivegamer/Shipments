using UnityEngine;
using TMPro;
using System.Collections;



public class PointsCollected : MonoBehaviour
{
    private TextMeshPro pointsCollected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsCollected.text = "Score:" + GameManager.Instance.currentPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
