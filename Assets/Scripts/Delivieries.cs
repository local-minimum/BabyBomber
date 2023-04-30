using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivieries : MonoBehaviour
{
    [SerializeField]
    PrefixedCounter counter;

    private void OnEnable()
    {
        BabyCollector.OnCollectBaby += BabyCollector_OnCollectBaby;
    }

    private void OnDisable()
    {
        BabyCollector.OnCollectBaby -= BabyCollector_OnCollectBaby;
    }

    private void BabyCollector_OnCollectBaby()
    {
        counter.Count ++;
    }
}
