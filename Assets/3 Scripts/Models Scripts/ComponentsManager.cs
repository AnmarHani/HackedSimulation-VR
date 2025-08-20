using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ComponentsManager : MonoBehaviour
{
    [Header("Sockets in Order")]
    public XRSocketInteractor[] sockets;

    private int currentSocketIndex = 0;

    void Start()
    {
        // Disable all sockets except the first
        for (int i = 0; i < sockets.Length; i++)
        {
            sockets[i].enabled = (i == 0);
            sockets[i].selectEntered.AddListener(OnObjectPlaced);
        }
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        XRSocketInteractor socket = args.interactorObject as XRSocketInteractor;

        // Make sure this is the current socket
        if (socket == sockets[currentSocketIndex])
        {
            if (currentSocketIndex < sockets.Length - 1)
            {
                // Enable next socket
                currentSocketIndex++;
                sockets[currentSocketIndex].enabled = true;
            }
            else
            {
                // Last socket filled
                GameObject placedObject = args.interactableObject.transform.gameObject;

                // Hide the object
                placedObject.SetActive(false);

                // Trigger your "final state" logic here
                Debug.Log("Final state reached!");

                // Reset sockets
                ResetSockets();
            }
        }
    }

    private void ResetSockets()
    {
        // Clear all sockets and reset
        foreach (var socket in sockets)
        {
            if (socket.firstInteractableSelected != null)
            {
                socket.interactionManager.SelectExit(socket, socket.firstInteractableSelected);
            }
            socket.enabled = false;
        }

        // Reset index
        currentSocketIndex = 0;
        sockets[0].enabled = true;
    }
}
