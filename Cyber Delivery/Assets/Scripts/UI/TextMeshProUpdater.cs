using UnityEngine;
using TMPro;

public class TextMeshProUpdater : MonoBehaviour
{
    public TMP_Text myText;

    void Start()
    {
        myText.text = "Hello, TextMeshPro!";
    }

    public void UpdateText(string newText)
    {
        myText.text = newText;
    }
}

