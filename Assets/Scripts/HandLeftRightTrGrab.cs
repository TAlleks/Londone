using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class HandLeftRightTrGrab : XRGrabInteractable
{
    public Transform leftHandAttach;
    public Transform rightHandAttach;
    private XRGrabInteractable grabInteractable;

    protected override void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        base.Awake();
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        string interactorName = args.interactorObject.transform.name.ToLower();
        if (interactorName.Contains("left interaction"))
        {
            grabInteractable.attachTransform = leftHandAttach;
        }
        else if (interactorName.Contains("right interaction"))
        {
            grabInteractable.attachTransform = rightHandAttach;
        }
        base.OnSelectEntering(args);
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        grabInteractable.attachTransform = rightHandAttach;
        base.OnSelectExited(args);
        args.interactableObject.transform.SetParent(null);
    }
}
