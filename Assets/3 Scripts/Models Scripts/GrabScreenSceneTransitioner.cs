using UnityEngine;

public class GrabScreenSceneTransitioner : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Transition to Scene "4.1 Ransomware Scenario Scene"
            UnityEngine.SceneManagement.SceneManager.LoadScene("4.1 Ransomware Scenario Scene");
        }
    }
}
