using UnityEngine;
using UnityEngine.UI;
#if TMP_PRESENT
using TMPro;
#endif

public class GuideCounterUI : MonoBehaviour
{
    [Header("References")]
    public AppRunner appRunner; // assign in inspector or auto-find

    // UI targets - assign one of these in inspector
    public Text uiText;
#if TMP_PRESENT
    public TextMeshProUGUI tmpText;
#endif

    [Header("Guide Messages")]
    [Tooltip("Messages shown for each counter index. If empty or missing index, the counter number is shown.")]
    public string[] guideMessages;

    private int lastCounter = int.MinValue;

    void Start()
    {
    if (appRunner == null)
    {
#if UNITY_2023_2_OR_NEWER
        appRunner = UnityEngine.Object.FindFirstObjectByType<AppRunner>();
#else
        appRunner = FindObjectOfType<AppRunner>();
#endif
    }

        // Example default messages if none provided
        if (guideMessages == null || guideMessages.Length == 0)
        {
            guideMessages = new string[] { "Welcome", "Step 1", "Step 2", "Step 3" };
        }

        // Initial update
        UpdateUiFromCounter(force: true);
    }

    void Update()
    {
        if (appRunner == null) return;

        if (appRunner.Counter != lastCounter)
        {
            UpdateUiFromCounter();
        }
    }

    private void UpdateUiFromCounter(bool force = false)
    {
        int counter = appRunner != null ? appRunner.Counter : 0;
        if (!force && counter == lastCounter) return;
        lastCounter = counter;

        string newText = counter >= 0 && counter < guideMessages.Length ? guideMessages[counter] : counter.ToString();

#if TMP_PRESENT
        if (tmpText != null)
        {
            tmpText.text = newText;
            return;
        }
#endif
        if (uiText != null)
        {
            uiText.text = newText;
        }
    }
}
