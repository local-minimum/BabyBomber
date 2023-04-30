using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircularTransform))]
public class Human : MonoBehaviour
{
    CircularTransform ct;
    float elevation;
    float spawnAngle;

    [SerializeField]
    float minAngleOffset = -3f;

    [SerializeField]
    float maxAngleOffest = 3f;

    float angle;

    [SerializeField]
    float moveSpeed = 0.1f;

    [SerializeField]
    Transform collector;

    SpriteRenderer sr;

    [SerializeField]
    GameObject caughtVersion;

    [SerializeField]
    float cradleTime = 10f;

    float cradleStart;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        caughtVersion.SetActive(false);
        ct = GetComponent<CircularTransform>();
        elevation = ct.Elevation;
        spawnAngle = ct.Angle;
        angle = spawnAngle;
        LongForNext();
    }

    void Update()
    {
        if (caughtVersion.activeSelf)
        {
            if (Time.timeSinceLevelLoad - cradleStart > cradleTime)
            {
                LongForNext();
            }
            return;
        }

        angle = Mathf.Clamp(angle + (Random.value - 0.5f) * Time.deltaTime * moveSpeed, spawnAngle + minAngleOffset, spawnAngle + maxAngleOffest);
        ct.SetAnglePosition(angle, elevation);
    }

    public void Catch()
    {
        sr.enabled = false;
        caughtVersion.SetActive(true);
        cradleStart = Time.timeSinceLevelLoad;
    }

    public void LongForNext()
    {
        sr.enabled = true;
        caughtVersion.SetActive(false);
    }
}
