using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircularTransform))]
public class Wind2D : MonoBehaviour
{   
    [Range(0, 100)]
    public float mainForce = 5f;


    [SerializeField, Range(0, 10)]
    float turbulence;

    CircularTransform ct;    

    Vector3 TurbulenceVector { get => new Vector3(Random.Range(-turbulence, turbulence), Random.Range(-turbulence, turbulence)); }

    List<Rigidbody2D> bodies = new List<Rigidbody2D>();

    private void Start()
    {
        ct = GetComponent<CircularTransform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            bodies.Add(rb);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            bodies.Remove(rb);
        }
    }

    private void Update()
    {
        var up = ct.Up;
        foreach (Rigidbody2D rb in bodies)
        {
            rb.AddForce((up * mainForce + TurbulenceVector) * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
