using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DistanceToCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform checkpoint;

    public TextMeshProUGUI distanceText;

    private float distance;

    // Update is called once per frame
    void Update()
    {
            distance = -1*(checkpoint.transform.position.z - transform.position.z);
            distanceText.text = "Distance: " + distance.ToString("F1") + " meters";
    }

    
}
