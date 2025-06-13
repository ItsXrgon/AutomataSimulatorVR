using TMPro;
using UnityEngine;

public class StackSymbol : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    public void SetSymbol(string symbol)
    {
        textMesh.text = symbol;
    }

    public string GetSymbol()
    {
        return textMesh.text;
    }
}
