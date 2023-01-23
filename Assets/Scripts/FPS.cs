using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    public int srednia;
    public TextMeshProUGUI text;
    void Update()
    {
        srednia = (int)(1f / Time.unscaledDeltaTime);
        text.text = srednia.ToString();
    }
}
