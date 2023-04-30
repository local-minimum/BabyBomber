using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyCamOffHud : MonoBehaviour
{
    [SerializeField]
    Image img;

    public static Image Image;

    public static bool Active {
        get => Image.enabled;
        set {
            if (Image)
            {
                Image.enabled = value;
            }
        }
    }
    
    int texSize = 200;
    Texture2D tex;

    private void Start()
    {
        if (Image == null)
        {
            Image = img;
        }
        else if (Image != img)
        {
            Destroy(gameObject);
            return;
        }

        img.type = Image.Type.Tiled;
        img.preserveAspect = true;

        tex = new Texture2D(texSize, texSize);        
        img.sprite = Sprite.Create(tex, new Rect(0, 0, texSize, texSize), Vector2.zero);
    }

    void Noise()
    {
        for (int x = 0; x < texSize; x++)
        {
            for (int y = 0; y < texSize; y++)
            {
                var v = Mathf.Clamp01((Random.value - 0.5f) * 2 + 0.5f);
                tex.SetPixel(x, y, new Color(v, v, v, 1));
            }
        }
        tex.Apply();
    }

    private void OnDestroy()
    {
        if (Image == img)
        {
            Image = null;
        }
    }

    float lastUpdate;

    [SerializeField]
    float updateFreq = 0.1f;

    private void Update()
    {
        if (Time.timeSinceLevelLoad - lastUpdate > updateFreq)
        {
            Noise();
            lastUpdate = Time.timeSinceLevelLoad;
        }
    }
}
