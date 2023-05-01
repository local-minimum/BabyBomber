using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Altometer : MonoBehaviour
{
    public static Altometer instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    [SerializeField]
    TMPro.TextMeshProUGUI letter1;

    [SerializeField]
    TMPro.TextMeshProUGUI letter2;

    [SerializeField]
    TMPro.TextMeshProUGUI letter3;

    [SerializeField]
    Image image;

    [SerializeField]
    float minElevation = 100f;

    [SerializeField]
    float maxElevation = 400f;

    public void SetElevation(float elevation)
    {
        if (image != null)
        {
            image.fillAmount = Mathf.Clamp01((elevation - minElevation) / (maxElevation - minElevation));
        }
        if (letter1 && letter2 && letter3)
        {
            var value = Mathf.FloorToInt(Mathf.Clamp(elevation - minElevation, 0, 999)).ToString("000");
            letter1.text = value.Substring(0, 1);
            letter2.text = value.Substring(1, 1);
            letter3.text = value.Substring(2, 1);
        }
    }
}
