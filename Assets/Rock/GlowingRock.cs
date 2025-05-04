using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class GlowingRock : MonoBehaviour
{

    public Material normalMaterial;
    public Material purpleGlowMaterial;
    public Material redFlashMaterial;
    public XRGrabInteractable knifeInteractable;
    public Renderer rockRenderer;
    public float flashDuration = 0.2f;

    private Material originalMaterial;
    private bool isHoldingKnife = false;

    void Start()
    {
        originalMaterial = rockRenderer.material;

        knifeInteractable.selectEntered.AddListener(OnKnifePickedUp);
        knifeInteractable.selectExited.AddListener(OnKnifeDropped);
    }

    // Fixed the typo in this method name
    private void OnKnifePickedUp(SelectEnterEventArgs args)
    {
        isHoldingKnife = true;
        rockRenderer.material = purpleGlowMaterial;
    }

    private void OnKnifeDropped(SelectExitEventArgs args)
    {
        isHoldingKnife = false;
        rockRenderer.material = originalMaterial;
    }

    // Changed from OnCollisionEnter to OnTriggerEnter if using trigger colliders
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Debug log to verify collisions are detected
    //    Debug.Log("Collided with: " + collision.gameObject.name);

    //    if (isHoldingKnife && collision.gameObject == knifeInteractable.gameObject)
    //    {
    //        Debug.Log("Knife poked the rock!");
    //        StartCoroutine(FlashRed());
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        // Debug log to verify collisions are detected
        //Debug.Log("Collided with: " + collision.gameObject.name);

        if (isHoldingKnife && other.CompareTag("Knife")) 
        {
            Debug.Log("Knife poked the rock!");
            StartCoroutine(FlashRed()); 
        }
    }

    private IEnumerator FlashRed()
    {
        // Store original emission color if we want to restore it
        Color originalEmission = rockRenderer.material.GetColor("_EmissionColor");

        // Set to red flash material
        rockRenderer.material = redFlashMaterial;

        // Make sure emission is enabled
        rockRenderer.material.EnableKeyword("_EMISSION");
        rockRenderer.material.SetColor("_EmissionColor", Color.red * 5f); // Bright red

        yield return new WaitForSeconds(flashDuration);

        // Return to appropriate material
        if (isHoldingKnife)
        {
            rockRenderer.material = purpleGlowMaterial;
            rockRenderer.material.SetColor("_EmissionColor", originalEmission);
        }
        else
        {
            rockRenderer.material = originalMaterial;
        }
    }
}