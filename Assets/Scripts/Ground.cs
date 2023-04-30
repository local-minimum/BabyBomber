using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    BabyCamera cam;
    float camFirstTime;

    [SerializeField]
    float releaseCamAfter = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        var c = collision.gameObject.GetComponentInChildren<BabyCamera>();
        if (c != null)
        {
            cam = c;
            camFirstTime = Time.timeSinceLevelLoad;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var c = collision.gameObject.GetComponentInChildren<BabyCamera>();
        if (c != null && c == cam)
        {
            if (Time.timeSinceLevelLoad - camFirstTime > releaseCamAfter)
            {
                cam = null;
                c.ReleaseCamera();
            }
        }
    }
}
