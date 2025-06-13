using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControls : MonoBehaviour
{
    [SerializeField] private Button toggleModeButton;
    [SerializeField] private TextMeshProUGUI toggleModeButtonText;

    [SerializeField] private Button stepButton;

    private AutomatonNode automaton;
    private bool inSimulateMode = false;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;

        toggleModeButton.onClick.AddListener(ToggleMode);
        stepButton.onClick.AddListener(StepSimulation);

        UpdateToggleModeText();
    }

    private void ToggleMode()
    {
        inSimulateMode = !inSimulateMode;
        automaton.SetSimulateMode(inSimulateMode);
        UpdateToggleModeText();
    }

    private void StepSimulation()
    {
        if (!inSimulateMode) return;

        AutomatonError error;
        automaton.ProcessInput(out error);

        if (error.code != AutomatonErrorCode.OK)
        {
            Debug.LogWarning($"ProcessInput failed: {error.message}");
        }
    }

    private void UpdateToggleModeText()
    {
        toggleModeButtonText.text = inSimulateMode ? "Enter Build Mode" : "Enter Simulate Mode";
    }
}
