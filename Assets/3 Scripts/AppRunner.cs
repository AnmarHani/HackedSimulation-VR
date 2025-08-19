using UnityEngine;
using UnityEngine.UI;

public class AppRunner : MonoBehaviour
{
    public GameObject viewApp;
    public GameObject controls;
    public GameObject Background;
    public string currentApp;
    public static int Counter = 0;
    public GameObject apps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

 

    public void runApp(string appName)
    {
        Counter++;
        bool isLoading = Counter % 2 != 0;

        if (!isLoading)
        {
            RawImage rawImg = Background.GetComponent<RawImage>();
            Texture2D tex = Resources.Load<Texture2D>("loading");

            viewApp.SetActive(true);
            controls.SetActive(true);
            apps.SetActive(true);

             rawImg = viewApp.GetComponent<RawImage>();

             tex = Resources.Load<Texture2D>(appName);

            rawImg.texture = tex;

            Transform child = transform.Find("controls").transform.Find(appName.Split("_")[0] + "_controls");
            child.gameObject.SetActive(true);
            this.currentApp = appName.Split("_")[0];
            Debug.Log(appName);

            rawImg.enabled = true;

            isLoading = !isLoading;
            
        }

        else
        {
            viewApp.SetActive(false);
            controls.SetActive(false);
            apps.SetActive(false);

            RawImage rawImg = Background.GetComponent<RawImage>();
            Texture2D tex = Resources.Load<Texture2D>("loading");
            rawImg.texture = tex;


        }

        //RawImage rawImg = viewApp.GetComponent<RawImage>();

        //Texture2D tex = Resources.Load<Texture2D>(appName);

        //rawImg.texture = tex;

        //Transform child = transform.Find("controls").transform.Find(appName.Split("_")[0] + "_controls");
        //child.gameObject.SetActive(true);
        //this.currentApp = appName.Split("_")[0];
        //Debug.Log(appName);

        //rawImg.enabled = true;

    }

    public void closeApp()
    {
        RawImage rawImg = viewApp.GetComponent<RawImage>();
        rawImg.enabled = false;
        Transform child = transform.Find("controls").transform.Find(currentApp + "_controls");
        child.gameObject.SetActive(false);
    }
}
