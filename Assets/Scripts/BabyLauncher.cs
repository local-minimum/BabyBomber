using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyLauncher : MonoBehaviour
{
    public static BabyLauncher instance { get; private set; }

    [SerializeField]
    GameObject babyPrefab;

    [SerializeField]
    Transform launchSite;

    [SerializeField]
    Transform rocketBase;

    [SerializeField]
    float launchForce = 40f;

    [SerializeField]
    Camera babyCam;

    [SerializeField]
    Image[] babyImages;

    public int MaxBabies
    {
        get => babyImages.Length;
    }

    public void BabyLoadingProgress(float value)
    {
        if (babies >= MaxBabies) return;
        babyImages[babies].fillAmount = value;
    }

    int _babies = 0;
    public int babies
    {
        get => _babies;
        set
        {
            _babies = Mathf.Min(value, MaxBabies);
            for (int i=0; i<MaxBabies; i++)
            {
                babyImages[i].fillAmount = i < _babies ? 1 : 0;
            }
        }
    }

    [SerializeField, Range(0, 360)]
    float maxAngularBabyVelocity = 30f;

    Rigidbody2D body;

    [HideInInspector]
    public bool readyToLaunch = true;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        body = GetComponentInParent<Rigidbody2D>();
        babyCam.enabled = false;
        babyCam.GetComponent<BabyCamera>().enabled = false;
        Altometer.instance.SetElevation(0);
        babies = 0;
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void Update()
    {
        if (babies <= 0 || !readyToLaunch) return;

        if (Input.GetButtonDown("Jump"))
        {
            var direction = (launchSite.position - rocketBase.position).normalized;

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
            readyToLaunch = false;
        }
    }
}
