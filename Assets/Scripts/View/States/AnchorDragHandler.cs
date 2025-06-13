using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class AnchorDragHandler : MonoBehaviour
{
    public AnchorNode anchorNode;
    public Transform baseSphere;
    public Transform pipeObject;

    private XRGrabInteractable grab;
    private Vector3 originalLocalPos;

    private XRGrabInteractable grabInteractable;
    private bool isBeingGrabbed => grabInteractable.isSelected;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        originalLocalPos = transform.localPosition;

        grab.selectEntered.AddListener(OnGrabbed);
        grab.selectExited.AddListener(OnReleased);

        grab.hoverEntered.AddListener(anchorNode.OnHoverEnter);
        grab.hoverExited.AddListener(anchorNode.OnHoverExit);
        grab.selectEntered.AddListener(anchorNode.OnSelectEnter);
        grab.selectExited.AddListener(anchorNode.OnSelectExit);

        pipeObject.gameObject.SetActive(false);
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        pipeObject.gameObject.SetActive(true);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        pipeObject.gameObject.SetActive(false);

        Transform nearest = FindNearestAnchor();

        if (nearest != null && nearest != baseSphere)
        {
            var targetAnchorNode = nearest.GetComponent<AnchorDragHandler>().anchorNode;
            if (targetAnchorNode != null)
            {
                targetAnchorNode.ConnectTo(anchorNode);
            }
        }
        transform.localPosition = originalLocalPos;
    }

    private void Update()
    {
        if (grab.isSelected)
        {
            PositionPipe(pipeObject, baseSphere.position, transform.position);
        }
    }

    private void LateUpdate()
    {
        if (!isBeingGrabbed && baseSphere != null)
        {
            transform.position = baseSphere.position;
        }
    }

    private Transform FindNearestAnchor()
    {
        float threshold = 0.2f;
        Collider[] hits = Physics.OverlapSphere(transform.position, threshold);

        foreach (var hit in hits)
        {
            if (hit.transform != transform && hit.CompareTag("AnchorUI"))
            {
                return hit.transform;
            }
        }

        return null;
    }

    private void PositionPipe(Transform pipe, Vector3 start, Vector3 end)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;
        pipe.position = start; // Keep base at baseSphere
        pipe.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        pipe.localScale = new Vector3(0.1f, distance, 0.1f);
        pipe.Translate(Vector3.up * (distance / 2f), Space.Self); // Offset to stretch upwards
    }

}
