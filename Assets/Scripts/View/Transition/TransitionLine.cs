using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TransitionLine : MonoBehaviour
{
    [Header("References")]
    public Transform startToMidPipe;
    public Transform midToEndPipe;
    public GameObject midPoint;

    [Header("Visual Settings")]
    public MeshRenderer handleRenderer;
    private Color normalColor = Color.yellow;
    private Color hoverColor = Color.green;
    private Color activeColor = Color.blue;

    private float pipeRadius = 0.05f;

    private AnchorNode startAnchor;
    private AnchorNode endAnchor;

    private XRGrabInteractable midPointInteractable;
    private bool isDragging = false;

    public AutomatonNode automaton;
    public string key;

    [Header("UI")]
    public GameObject faEditPanelPrefab;
    public GameObject pdaEditPanelPrefab;
    public GameObject tmEditPanelPrefab2D;
    private GameObject spawnedPanel;
    private Vector3 panelOffset = new(0, 0.2f, 0);

    public void Initialize(AnchorNode start, AnchorNode end, AutomatonNode automatonRef, string key)
    {
        automaton = automatonRef;

        startAnchor = start;
        endAnchor = end;

        Vector3 midPos = (start.transform.position + end.transform.position) / 2f;
        midPoint.transform.position = midPos;

        StateNode startState = start.GetComponentInParent<StateNode>();
        StateNode endState = end.GetComponentInParent<StateNode>();

        startState?.RegisterOutgoing(this);
        this.key = key;
        UpdateCylinders();
        SpawnEditPanel();
    }

    private void Awake()
    {
        if (midPoint == null || startToMidPipe == null || midToEndPipe == null)
        {
            Debug.LogError("TransitionLine is missing references.");
            return;
        }

        midPointInteractable = midPoint.GetComponent<XRGrabInteractable>();
        if (midPointInteractable != null)
        {
            midPointInteractable.selectEntered.AddListener(StartDrag);
            midPointInteractable.selectExited.AddListener(EndDrag);
            midPointInteractable.hoverEntered.AddListener(OnHandleHoverEnter);
            midPointInteractable.hoverExited.AddListener(OnHandleHoverExit);
        }

        handleRenderer.material.color = normalColor;
    }

    private void Update()
    {
        if (startAnchor == null || endAnchor == null || midPoint == null)
            return;

        // Only update if not currently being dragged, or update with a small delay during drag
        if (!isDragging)
        {
            UpdateCylinders();
            UpdateArrowDirection();
        }
    }

    private void LateUpdate()
    {
        // Update cylinders and arrow in LateUpdate when dragging for smoother movement
        if (isDragging)
        {
            UpdateCylinders();
            UpdateArrowDirection();
        }
    }

    private void UpdateCylinders()
    {
        Vector3 startPos = startAnchor.transform.position;
        Vector3 endPos = endAnchor.transform.position;
        Vector3 midPos = midPoint.transform.position;

        PositionPipe(startToMidPipe, startPos, midPos);
        PositionPipe(midToEndPipe, midPos, endPos);

        if (spawnedPanel != null)
        {
            spawnedPanel.transform.position = midPos + panelOffset;
        }
    }

    private void UpdateArrowDirection()
    {
        if (midPoint == null || startAnchor == null || endAnchor == null)
            return;

        Vector3 startPos = startAnchor.transform.position;
        Vector3 endPos = endAnchor.transform.position;
        Vector3 direction = (endPos - startPos).normalized;

        // Calculate rotation to point from start to end
        // Assuming the arrow image originally points up (Vector3.up)
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, direction);

        // Apply the rotation to the arrow
        midPoint.transform.rotation = targetRotation;
    }

    private void PositionPipe(Transform pipe, Vector3 start, Vector3 end)
    {
        Vector3 direction = end - start;
        float fullLength = direction.magnitude;
        Vector3 directionNormalized = direction.normalized;

        float shrinkAmount = 0.1f;
        float visibleLength = Mathf.Max(fullLength - shrinkAmount, 0f);
        Vector3 adjustedStart = start + directionNormalized * (shrinkAmount / 2f);
        Vector3 adjustedEnd = end - directionNormalized * (shrinkAmount / 2f);
        Vector3 midPoint = (adjustedStart + adjustedEnd) / 2f;

        pipe.position = midPoint;
        pipe.rotation = Quaternion.FromToRotation(Vector3.up, directionNormalized); // Align cylinder Y to direction
        pipe.localScale = new Vector3(pipeRadius, visibleLength / 2f, pipeRadius);  // Scale along Y-axis
    }

    private void SpawnEditPanel()
    {
        switch (automaton.automataType)
        {
            case AutomataType.DFA:
            case AutomataType.NFA:
                SpawnFATransitionPanel();
                break;
            case AutomataType.DPDA:
            case AutomataType.NPDA:
                SpawnPDATransitionPanel();
                break;
            case AutomataType.DTM:
            case AutomataType.NTM:
                SpawnTMTransitionPanel();
                break;
            default:
                Debug.LogWarning("Unsupported automata type for edit panel.");
                return;
        }
    }

    private void SpawnFATransitionPanel()
    {
        spawnedPanel = Instantiate(faEditPanelPrefab, midPoint.transform.position + panelOffset, Quaternion.identity, this.transform);
        spawnedPanel.transform.localScale = Vector3.one * 0.005f;

        FATransitionEditPanel panelScript = spawnedPanel.GetComponent<FATransitionEditPanel>();
        panelScript.Setup(this);
    }

    public void SpawnPDATransitionPanel()
    {
        spawnedPanel = Instantiate(pdaEditPanelPrefab, midPoint.transform.position + panelOffset, Quaternion.identity, this.transform);
        spawnedPanel.transform.localScale = Vector3.one * 0.005f;

        PDATransitionEditPanel panelScript = spawnedPanel.GetComponent<PDATransitionEditPanel>();
        panelScript.Setup(this);
    }

    public void SpawnTMTransitionPanel()
    {
        spawnedPanel = Instantiate(tmEditPanelPrefab2D, midPoint.transform.position + panelOffset, Quaternion.identity, this.transform);
        spawnedPanel.transform.localScale = Vector3.one * 0.005f;

        TMTransitionEditPanel panelScript = spawnedPanel.GetComponent<TMTransitionEditPanel>();
        panelScript.Setup(this);
    }

    private void OnHandleHoverEnter(HoverEnterEventArgs args)
    {
        handleRenderer.material.color = hoverColor;
    }

    private void OnHandleHoverExit(HoverExitEventArgs args)
    {
        handleRenderer.material.color = normalColor;
    }

    private void StartDrag(SelectEnterEventArgs args)
    {
        handleRenderer.material.color = activeColor;
        isDragging = true;
    }

    private void EndDrag(SelectExitEventArgs args)
    {
        handleRenderer.material.color = normalColor;
        isDragging = false;
        // Force an immediate update when drag ends
        UpdateCylinders();
        UpdateArrowDirection();
    }

    private void OnDestroy()
    {
        StateNode startState = startAnchor?.GetComponentInParent<StateNode>();

        startState?.UnregisterOutgoing(this);

        Destroy(gameObject);
    }
}