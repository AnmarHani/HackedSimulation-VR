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
            text.text = "Welcome to the Guide Panel!";
        }
        if (AppRunner.Counter == 1)
        {
            text.text = "1!";
        }
        if (AppRunner.Counter == 2)
        {
            text.text = "2!";
        }
        if (AppRunner.Counter == 3)
        {
            text.text = "3!";
        }
        if (AppRunner.Counter == 4)
        {
            text.text = "4!";
        }
        if (AppRunner.Counter == 5)
        {
            text.text = "5!";
        }
        if (AppRunner.Counter== 6)
        {
            text.text = "6!";
        }
        if (AppRunner.Counter == 7)
        {
            text.text = "7!";
        }
        // This script currently does not have any functionality.
        // It can be used to manage the guide panel UI or other related tasks in the future.
    }
}