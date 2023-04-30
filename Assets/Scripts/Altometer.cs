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
    TMPro.TextMeshProUGUI text;

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
        if (text)
        {
            var value = Mathf.FloorToInt(Mathf.Max(elevation - minElevation, 0)).ToString("000");
            text.text = value;
        }
    }
}
