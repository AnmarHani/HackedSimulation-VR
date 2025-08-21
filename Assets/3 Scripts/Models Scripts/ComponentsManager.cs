using TMPro;
using UnityEngine;


public class ComponentsManager : MonoBehaviour
{
    public static int internalCounter = 0;
    int maxTries = 2;
    static int phaseCounter = 0;

    public GameObject appView;

    public GameObject binaryData1;
    public GameObject binaryData2;
    public GameObject binaryData3;
    public AudioSource binarySound;

    public UnityEngine.UI.Text hackedText;

    private void Update()
    {

        if (internalCounter == maxTries) {
            appView.GetComponent<AppRunner>().increaseCount();
            internalCounter = 0;
        }
        if(phaseCounter == 1)
        {
            binaryData1.SetActive(true);
        }        
        if(phaseCounter == 2)
        {
            binaryData2.SetActive(true);
        }               
        if(phaseCounter == 3)
        {
            phaseCounter = 0;
        }        

        if(AppRunner.Counter == 7)
            binaryData3.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Data1")) {

            binarySound.Play();
            maxTries = 2;
            if (this.gameObject.CompareTag("Storage"))
            {
                internalCounter = 0;
            }            
            if (this.gameObject.CompareTag("RAM") && internalCounter == 0)
            {
                internalCounter = 1;
            }
            if (this.gameObject.CompareTag("CPU") && internalCounter == 1)
            {
                internalCounter = 2;
                // Delete 
                Destroy(other.gameObject);

                phaseCounter++;
            }
            

        }      
        
        if (other.CompareTag("Data2")) {
            binarySound.Play();
            maxTries = 1;
            if (this.gameObject.CompareTag("Storage"))
            {
                internalCounter = 1;
                Destroy(other.gameObject);
                phaseCounter = 3;
            }
        }        
        
        if (other.CompareTag("Data3")) {
            binarySound.Play();
            maxTries = 2;
            if (this.gameObject.CompareTag("Storage"))
            {
                internalCounter = 0;
            }
            if (this.gameObject.CompareTag("RAM") && internalCounter == 0)
            {
                internalCounter = 1;
            }
            if (this.gameObject.CompareTag("CPU") && internalCounter == 1)
            {
                internalCounter = 2;
                // Delete 
                if(BackupManager.DidBackup)
                {
                    Destroy(other.gameObject);
                    appView.GetComponent<AppRunner>().increaseCount();
                    hackedText.text = "You did Backup, you arent hacked";
                }
                else
                {
                    var tmp = other.gameObject.transform
                    .Find("Canvas/Text (TMP)")
                    .GetComponent<TMP_Text>();

                    hackedText.text = "You Did not backup, you are hacked.";

                    tmp.text = "00000000000000000000000000000";
                }
            }
        }
    }
    //[Header("Sockets in Order")]
    //public XRSocketInteractor[] sockets;
    //public GameObject appRunnerObject;

    //private int currentSocketIndex = 0;

    //void Start()
    //{
    //    // Disable all sockets except the first
    //    for (int i = 0; i < sockets.Length; i++)
    //    {
    //        sockets[i].enabled = (i == 0);
    //        sockets[i].selectEntered.AddListener(OnObjectPlaced);
    //    }
    //}

    //private void OnObjectPlaced(SelectEnterEventArgs args)
    //{
    //    XRSocketInteractor socket = args.interactorObject as XRSocketInteractor;

    //    // Make sure this is the current socket
    //    if (socket == sockets[currentSocketIndex])
    //    {
    //        if (currentSocketIndex < sockets.Length - 1)
    //        {
    //            // Enable next socket
    //            currentSocketIndex++;
    //            sockets[currentSocketIndex].enabled = true;
    //            //socket.interactionManager.SelectExit(socket, args.interactableObject);

    //        }
    //        else
    //        {
    //            // Last socket filled
    //            GameObject placedObject = args.interactableObject.transform.gameObject;
    //            if(placedObject.CompareTag("Data1"))
    //            {
    //                Debug.Log("Data1, but IDK");
    //            }
    //            if(placedObject.CompareTag("Data2"))
    //            {

    //            }
    //            if (placedObject.CompareTag("Data3"))
    //            {

    //            }

    //            appRunnerObject.GetComponent<AppRunner>().increaseCount();



    //            // Hide the object
    //            placedObject.SetActive(false);

    //            // Trigger your "final state" logic here
    //            Debug.Log("Final state reached!");

    //            // Reset sockets
    //            ResetSockets();
    //        }

    //    }
    //}

    //private void ResetSockets()
    //{
    //    // Clear all sockets and reset
    //    foreach (var socket in sockets)
    //    {
    //        if (socket.firstInteractableSelected != null)
    //        {
    //            socket.interactionManager.SelectExit(socket, socket.firstInteractableSelected);
    //        }
    //        socket.enabled = false;
    //    }

    //    // Reset index
    //    currentSocketIndex = 0;
    //    sockets[0].enabled = true;
    //}

}
