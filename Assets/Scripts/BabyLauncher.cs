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

    [SerializeField]
    Camera babyCam;

    public int babies = 10;

    [SerializeField, Range(0, 360)]
    float maxAngularBabyVelocity = 30f;

    Rigidbody2D body;

    private void Start()
    {
        body = GetComponentInParent<Rigidbody2D>();
        babyCam.enabled = false;
        babyCam.GetComponent<BabyCamera>().enabled = false;
        Altometer.instance.SetElevation(0);
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

            babyCam.transform.parent = child.transform;
            babyCam.transform.localPosition = Vector3.forward * -10;
            babyCam.enabled = true;
            babyCam.GetComponent<BabyCamera>().enabled = true;

            babies--;
        }
    }
}
