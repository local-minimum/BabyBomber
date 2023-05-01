using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refiller : MonoBehaviour
{

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
            if (BabyLauncher.instance.babies >= BabyLauncher.instance.MaxBabies) return;

            var progress = Mathf.Clamp01((Time.timeSinceLevelLoad - entry) / refillDuration);
            BabyLauncher.instance.BabyLoadingProgress(progress);

            if (progress >= 1)
            {
                BabyLauncher.instance.babies = Mathf.Min(BabyLauncher.instance.babies + 1, BabyLauncher.instance.MaxBabies);
                entry = Time.timeSinceLevelLoad;    
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BabyLauncher.instance.BabyLoadingProgress(0);
    }
}
