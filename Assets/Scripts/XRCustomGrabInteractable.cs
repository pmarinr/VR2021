using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCustomGrabInteractable : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        Storelnteractor(args.interactor);
        MatchAttachmentPoints(args.interactor);
    }

    private void Storelnteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }

    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        ResetAttachmentPoint(args.interactor);
        Clearinteractor(args.interactor);
    }

    private void ResetAttachmentPoint(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }

    private void Clearinteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}