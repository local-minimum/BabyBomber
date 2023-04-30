using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CircularTransform))]
public class Gravity : MonoBehaviour
{
    static float gravitation = 10f;
    static float gravitationDecayAt = 140f;
    static float minGravityAt = 200f;
    static float minGravitation = 8f;

    [SerializeField]
    float magicPrivateGFactor = 1f;

    Rigidbody2D rb;
    CircularTransform ct;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ct = GetComponent<CircularTransform>();
    }

    private void Update()
    {        
        rb.AddForce(ct.Down * magicPrivateGFactor * Mathf.Lerp(gravitation, minGravitation, (ct.Elevation - gravitationDecayAt) / (minGravityAt - gravitationDecayAt)) * Time.deltaTime, ForceMode2D.Impulse);
    }
}
