using UnityEngine;
using UnityEngine.UI;

public class BackupManager : MonoBehaviour
{

    public static bool DidBackup = false;
    public Text backupText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("StorageData"))
        {
            DidBackup = true;
            backupText.text = "DID BACKUP";
            backupText.color = Color.green;
        }
    }

}
