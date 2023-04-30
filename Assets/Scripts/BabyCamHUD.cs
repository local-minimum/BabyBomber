using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyCamHUD : MonoBehaviour
{
    [SerializeField]
    RenderTexture rt;    

    [SerializeField]
    Image img;

    [SerializeField]
    Camera rtCam;

    Texture2D tex;

    public void CloneRT()
    {
        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = rt;
        rtCam.Render();
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        tex.Apply();
        RenderTexture.active = currentActiveRT;        
    }

    private void Start()
    {
        tex = new Texture2D(rt.width, rt.height);
        var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);
        sprite.name = "Render texture copy";
        img.sprite = sprite;
    }

    private void Update()
    {
        CloneRT();
    }
}
