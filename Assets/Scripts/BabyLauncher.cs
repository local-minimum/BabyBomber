using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyLauncher : MonoBehaviour
{
    [SerializeField]
    GameObject babyPrefab;

    [SerializeField]
    Transform launchSite;

    [SerializeField]
    float launchForce = 40f;

    public int babies = 10;

    [SerializeField, Range(0, 360)]
    float maxAngularBabyVelocity = 30f;

    Rigidbody2D body;

    private void Start()
    {
        body = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        if (babies <= 0) return;

        if (Input.GetButtonDown("Jump"))
        {
            var direction = transform.right;

            var child = Instantiate(babyPrefab);

            child.transform.position = launchSite.position;
            child.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

            var rb = child.GetComponent<Rigidbody2D>();
            rb.velocity = body.velocity;
            rb.AddForce(direction * launchForce, ForceMode2D.Impulse);

            rb.angularVelocity = Random.Range(-maxAngularBabyVelocity, maxAngularBabyVelocity);

            babies--;
        }
    }
}
