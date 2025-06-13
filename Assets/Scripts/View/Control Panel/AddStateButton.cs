using UnityEngine;
using UnityEngine.UI;

public class AddStateButton : MonoBehaviour
{
    public Button button;
    public AutomatonNode automaton;

    public void Setup(AutomatonNode automaton)
    {
        this.automaton = automaton;

        button.onClick.AddListener(HandleClick);
        automaton.OnSimulateModeChange += OnSimulateModeChange;
    }

    void HandleClick()
    {
        AutomatonError error;
        automaton.AddState(out error);
    }

    void OnSimulateModeChange()
    {
        button.interactable = automaton.simulateMode;
    }
}
