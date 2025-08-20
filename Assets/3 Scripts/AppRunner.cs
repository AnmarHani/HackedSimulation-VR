using UnityEngine;
using UnityEngine.UI;

public class AppRunner : MonoBehaviour
{
    public GameObject viewApp;
    public GameObject controls;
    public GameObject Background;
    public GameObject apps;
    public GameObject close;
    public static string currentApp;
    public static int Counter = 0;
    public bool isLastTask = false;
    
    public void increaseCount()
    {
       
        runApp(currentApp); 
    }


    public void showWaiting()
    {

        controls.SetActive(false);
        apps.SetActive(false);
        close.SetActive(false);
        Debug.Log("lost");



        RawImage rawImg = Background.GetComponent<RawImage>();
        Texture2D tex = Resources.Load<Texture2D>("loading");

        rawImg.texture = tex;


        rawImg = viewApp.GetComponent<RawImage>();
        rawImg.enabled = false;

    }

   
  
    
    public void runApp(string appName)
    {

        if (isLastTask)
        {
            controls.SetActive(false);
            apps.SetActive(false);
            close.SetActive(false);
            Debug.Log("lost");



            RawImage rawImg = Background.GetComponent<RawImage>();
            Texture2D tex = Resources.Load<Texture2D>("bg");

            rawImg.texture = tex;


            rawImg = viewApp.GetComponent<RawImage>();
            rawImg.enabled = false;
        }
        else {


            Counter++;
            if (!string.IsNullOrEmpty(appName))
            {
                currentApp = appName;
            }
            currentApp = appName;

            if (Counter == 0)
            {

                return;
            }



            else if (Counter % 2 == 0)
            {

                Debug.Log(currentApp);
                controls.SetActive(true);

                RawImage rawImg = viewApp.GetComponent<RawImage>();

                Texture2D tex = Resources.Load<Texture2D>(appName);

                rawImg.texture = tex;

                Transform child = transform.Find("controls").transform.Find(appName.Split("_")[0] + "_controls");
                child.gameObject.SetActive(true);

                if (!appName.Equals("hacked_app"))
                {
                    close.SetActive(true);
                    
                }
                else
                {
                    isLastTask = true;
                    controls.SetActive(false);
                }





                rawImg.enabled = true;

            }

            else {

                // viewApp.SetActive(false);
                showWaiting();



            }

        }

    }

    public void closeApp()
    {
       // Counter++;
        RawImage rawImg = viewApp.GetComponent<RawImage>();
        rawImg.enabled = false;
        Transform child = transform.Find("controls").transform.Find(currentApp.Split("_")[0] + "_controls");
        child.gameObject.SetActive(false);
        currentApp = null;

         rawImg = Background.GetComponent<RawImage>();
        Texture2D tex = Resources.Load<Texture2D>("bg");

        rawImg.texture = tex;

        apps.SetActive(true);
       
        
    }
}
