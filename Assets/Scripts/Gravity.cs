using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour
{
    static float gravitation = 10f;
    static float gravitationDecayAt = 140f;
    static float minGravityAt = 200f;
    static float minGravitation = 8f;

    [SerializeField]
    float magicPrivateGFactor = 1f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var d = transform.position.magnitude;
        var v = transform.position.normalized * -1f;        
        rb.AddForce(v * magicPrivateGFactor * Mathf.Lerp(gravitation, minGravitation, (d - gravitationDecayAt) / (minGravityAt - gravitationDecayAt)) * Time.deltaTime, ForceMode2D.Impulse);
    }
}
