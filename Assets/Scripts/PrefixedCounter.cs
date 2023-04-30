using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefixedCounter : MonoBehaviour
{
    TMPro.TextMeshProUGUI gui;

    [SerializeField]
    string prefix;

    private int count;

    public int Count {
        get => count;
        set {
            count = value;
            gui.text = $"{prefix}{count}";
        }
    }

    private void Start()
    {
        gui = GetComponent<TMPro.TextMeshProUGUI>();
    }


}
