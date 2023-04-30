using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(CircularTransform))]
public class OrientDown : MonoBehaviour
{
    CircularTransform _ct;
    CircularTransform ct { 
        get { 
            if (_ct == null)
            {
                _ct = GetComponent<CircularTransform>();
            }
            return _ct;
        } 
    }


    void Update()
    {
        if (ct == null) Debug.Log($"{name} misses CT");
        transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sign(transform.position.x) * Vector3.Angle(Vector3.down, ct.Down));
    }
}
