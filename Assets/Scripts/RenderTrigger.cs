using UnityEngine;

public class RenderTrigger: MonoBehaviour
{
    [Tooltip("The GameObject to hide/show (can have a Renderer or a Canvas)")]
    public GameObject targetObject;

    private Renderer targetRenderer;
    private Canvas targetCanvas;

    void Start()
    {
        if (targetObject != null)
        {
            targetRenderer = targetObject.GetComponent<Renderer>();
            targetCanvas = targetObject.GetComponent<Canvas>();

            // start hidden
            if (targetRenderer != null) targetRenderer.enabled = false;
            if (targetCanvas != null) targetCanvas.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // adjust tag as needed
        {
            if (targetRenderer != null) targetRenderer.enabled = true;
            if (targetCanvas != null) targetCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetRenderer != null) targetRenderer.enabled = false;
            if (targetCanvas != null) targetCanvas.enabled = false;
        }
    }
}
