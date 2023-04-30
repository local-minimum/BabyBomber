using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Catch()
    {
        var cam = GetComponentInChildren<BabyCamera>();
        cam.transform.parent = null;
        BabyLauncher.instance.readyToLaunch = true;
        Destroy(gameObject);
    }
}
