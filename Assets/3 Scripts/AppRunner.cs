using UnityEngine;
using UnityEngine.UI;

public class AppRunner : MonoBehaviour
{
    public GameObject viewApp;
    public GameObject controls;
    public string currentApp; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void runApp(string appName)
    {
        RawImage rawImg = viewApp.GetComponent<RawImage>();

        Texture2D tex = Resources.Load<Texture2D>(appName);

        rawImg.texture = tex;

        Transform child = transform.Find("controls").transform.Find(appName.Split("_")[0] + "_controls");
        child.gameObject.SetActive(true);
        this.currentApp = appName.Split("_")[0];
        Debug.Log(appName);

        rawImg.enabled = true;

    }

    public void closeApp()
    {
        RawImage rawImg = viewApp.GetComponent<RawImage>();
        rawImg.enabled = false;
        Transform child = transform.Find("controls").transform.Find(currentApp + "_controls");
        child.gameObject.SetActive(false);
    }
}
