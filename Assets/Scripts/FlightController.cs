using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField]
    AnimationCurve forwardForceByVelocity;

    [SerializeField]
    AnimationCurve liftByForwardSpeed;

    Rigidbody2D rb;

    [SerializeField]
    float upForce = 5f;

    [SerializeField]
    float downForce = 20f;

    [SerializeField]
    float anglePerSecond = 30f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    Vector3 Down
    {
        get => transform.position.normalized * -1f;        
    }

    Vector3 AngularDirection
    {
        get
        {            
            var down = Down;
            return new Vector3(-down.y, down.x);
        }
    }

    private void Update()
    {
        var angular = AngularDirection;
        var forwardMagnitude = Vector3.Project(rb.velocity, angular).magnitude;

        if (Input.GetButton("Horizontal"))
        {
            var forward = Input.GetAxis("Horizontal");
            rb.AddForce(angular * forward * forwardForceByVelocity.Evaluate(forwardMagnitude) * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (Input.GetButton("Vertical"))
        {
            var down = Down;
            var up = Input.GetAxis("Vertical");
            if (up > 0)
            {
                rb.AddForce(-1f * down * up * upForce * Time.deltaTime, ForceMode2D.Impulse);
                rb.velocity = Vector3.RotateTowards(rb.velocity, -down, anglePerSecond * Mathf.Deg2Rad * Time.deltaTime, 0);
            } else
            {
                rb.AddForce(-1f * down * up * downForce * Time.deltaTime, ForceMode2D.Impulse);
                rb.velocity = Vector3.RotateTowards(rb.velocity, down, anglePerSecond * Mathf.Deg2Rad * Time.deltaTime, 0);
            }
        }

        rb.AddForce(-1f * Down * liftByForwardSpeed.Evaluate(forwardMagnitude) * Time.deltaTime, ForceMode2D.Impulse);
    }
}
