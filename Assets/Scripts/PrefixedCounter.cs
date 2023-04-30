using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefixedCounter : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI gui;

    [SerializeField]
    string prefix;

    private int count;

    public int Count {
        get => count;
        set {
            count = value;
            if (gui == null)
            {
                gui = GetComponent<TMPro.TextMeshProUGUI>();
            }
            gui.text = $"{prefix}{count}";
        }
    }
}
