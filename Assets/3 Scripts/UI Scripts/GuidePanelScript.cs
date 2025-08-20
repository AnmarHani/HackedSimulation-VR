using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GuidePanelScript : MonoBehaviour
{
    public Text text;
    void Start()
    {

    }

    void Update()
    {
        if (AppRunner.Counter == 0)
        {
            text.text = "In the Desktop Open Discord App";
        }
        if (AppRunner.Counter == 1)
        {
            text.text = "In the motherboard Move Data from storage, to RAM, lastly to the CPU for the discord app to work.";
        }
        if (AppRunner.Counter == 2)
        {
            text.text = "In the Desktop In the Discord App, click the URL";
        }
        if (AppRunner.Counter == 3)
        {
            text.text = "In the motherboard Move Data from storage, to RAM, lastly to the CPU for the Google chrome app to work.";
        }
        if (AppRunner.Counter == 4)
        {
            text.text = "In the Desktop, click the download button.";
        }
        if (AppRunner.Counter == 5)
        {
            text.text = "In the Motherboard, Move Data from the Network Adapter, to the Storage to save the downloaded file.";
        }
        if (AppRunner.Counter == 6)
        {
            text.text = "In the Desktop, open the downloaded file.";
        }
        if (AppRunner.Counter == 7)
        {
            text.text = "In the motherboard Move Data from storage, to RAM, lastly to the CPU for the downloaded app to work.";
        }
                if (AppRunner.Counter == 8)
        {
            text.text = "HACKED, if there is no backup";
        }
        // This script currently does not have any functionality.
        // It can be used to manage the guide panel UI or other related tasks in the future.
    }
}