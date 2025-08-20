using UnityEngine;
using UnityEngine.UI;

public class bg_app : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject viewApp;
    public GameObject controls;
    public GameObject Background;
    public GameObject apps;
    public GameObject close;

    private void FixedUpdate()
    {
        
        if (this.isActiveAndEnabled && viewApp.GetComponent<RawImage>().texture.name.Equals("bg_app"))
        {
            closeApp();
        }
    }

    public void closeApp()
    {
        // Counter++;
        RawImage rawImg = viewApp.GetComponent<RawImage>();
        rawImg.enabled = false;
        gameObject.SetActive(false);



        rawImg = Background.GetComponent<RawImage>();
        Texture2D tex = Resources.Load<Texture2D>("bg");

        rawImg.texture = tex;
        rawImg.enabled = true;

        close.SetActive(false);
        controls.SetActive(false);
        apps.SetActive(true);


    }
}
