using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour {

    public TextMeshProUGUI textElement;
    public float TextBlinkingSpeed = 1.0f;
    // Use this for initialization
    void Start () {
        StartCoroutine(Blink());
	}

    IEnumerator Blink()
    {
        List<string> texts = new List<string>
        {
            "Scanning MR.Roboto.",
            "Scanning MR.Roboto..",
            "Scanning MR.Roboto...",
            "Scanning MR.Roboto....",
            "Scanning MR.Roboto.....",
        };
        int index = 0;
        while (true)
        {
            if (index == texts.Count) index = 0;
            textElement.SetText(texts[index]);
            yield return new WaitForSeconds(TextBlinkingSpeed);
            index++;
        }
    }
}
