using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CollectBabyEvent();

public class BabyCollector : MonoBehaviour
{
    public static event CollectBabyEvent OnCollectBaby;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var baby = collision.GetComponent<Baby>();
        if (baby != null)
        {
            OnCollectBaby?.Invoke();
            baby.Catch();
            GetComponentInParent<Human>().Catch();
        }
    }
}
