using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delivieries : MonoBehaviour
{
    [SerializeField]
    int requiredDeliveries = 6;

    [SerializeField]
    PrefixedCounter counter;

    private void Start()
    {
        counter.Count = requiredDeliveries;
    }

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
        counter.Count --;
        if (counter.Count == 0)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
