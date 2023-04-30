using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refiller : MonoBehaviour
{
    [SerializeField]
    int maxBabies = 5;

    [SerializeField]
    float refillDuration = 1f;

    float entry;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<FlightController>())
        {
            entry = Time.timeSinceLevelLoad;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<FlightController>())
        {
            if (Time.timeSinceLevelLoad - entry > refillDuration)
            {
                BabyLauncher.instance.babies = Mathf.Min(BabyLauncher.instance.babies + 1, maxBabies);
                entry = Time.timeSinceLevelLoad;    
            }
        }

    }
}
