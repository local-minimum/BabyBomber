using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{    
    public void Catch()
    {
        var cam = GetComponentInChildren<BabyCamera>();
        if (cam)
        {
            cam.ReleaseCamera();
            Destroy(gameObject);
        }
    } 
}
