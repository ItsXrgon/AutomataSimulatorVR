public enum AutomatonErrorCode
{
    OK = 0,
    StateNotFound,
    InputSymbolNotFound,
    StackSymbolNotFound,
    TapeSymbolNotFound,
    TransitionNotFound,
    InvalidAlphabet,
    InvalidStartState,
    InvalidTransition,
    InvalidDefinition,
    Unknown
}
