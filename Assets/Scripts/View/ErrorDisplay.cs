using TMPro;
using UnityEngine;

public class ErrorDisplay : MonoBehaviour
{
    public TMP_Text errorText;
    public float displayDuration = 3f;

    private float timer = 0f;

    void Start()
    {
        errorText.text = "";
    }

    public void ShowError(string message)
    {
        errorText.text = message;
        timer = displayDuration;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                errorText.text = "";
            }
        }
    }
}
