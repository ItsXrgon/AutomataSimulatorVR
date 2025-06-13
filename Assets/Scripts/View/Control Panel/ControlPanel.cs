using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] private AddStateButton addStateButton;
    [SerializeField] private ClearButton clearAutomatonButton;
    [SerializeField] private StartStateDropdown startStateDropdown;
    [SerializeField] private ChangeTypeDropdown automatonTypeDropdown;
    [SerializeField] private InputAlphabetDropdowns inputAlphabetDropdown;
    [SerializeField] private StackAlphabetDropdowns stackAlphabetDropdown;
    [SerializeField] private TapeAlphabetDropdowns tapeAlphabetDropdown;
    [SerializeField] private InputStringBuilder inputStringBuilder;
    [SerializeField] private CanvasControls canvasControls;

    public void Setup(AutomatonNode automaton)
    {
        if (addStateButton != null)
            addStateButton.Setup(automaton);

        if (clearAutomatonButton != null)
            clearAutomatonButton.Setup(automaton);

        if (startStateDropdown != null)
            startStateDropdown.Setup(automaton);

        if (automatonTypeDropdown != null)
            automatonTypeDropdown.Setup(automaton);

        if (inputAlphabetDropdown != null)
            inputAlphabetDropdown.Setup(automaton);

        if (stackAlphabetDropdown != null)
            stackAlphabetDropdown.Setup(automaton);

        if (tapeAlphabetDropdown != null)
            tapeAlphabetDropdown.Setup(automaton);

        if (inputStringBuilder != null)
            inputStringBuilder.Setup(automaton);

        if (canvasControls != null) 
            canvasControls.Setup(automaton);
    }


}
