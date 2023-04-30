using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways, RequireComponent(typeof(CircularTransform))]
public class OrientDown : MonoBehaviour
{
    [SerializeField]
    bool isStatic = false;

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

    private void Start()
    {
        if (isStatic)
        {
            enabled = false;
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sign(transform.position.x) * Vector3.Angle(Vector3.down, ct.Down));
    }
}
