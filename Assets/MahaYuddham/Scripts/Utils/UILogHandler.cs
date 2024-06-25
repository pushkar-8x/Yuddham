using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogHandler : MonoBehaviour
{
    [SerializeField] TMP_Text logTextUI;
    [SerializeField] Button clearButton;
    private string logMessages = "";

    void Awake()
    {
        clearButton.onClick.AddListener(() => { logMessages = ""; logTextUI.text = ""; });
        Application.logMessageReceived += HandleLog;
    }

    private void Start()
    {
        Debug.Log("Logger Started");
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        logMessages += $"{System.DateTime.Now}: {type} - {logString}\n";
        logTextUI.text = logMessages;
    }

    private void ClearLogs()
    {
        logMessages = "";
        logTextUI.text = "";
    }
}

