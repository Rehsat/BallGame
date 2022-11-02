using UnityEngine.UI;
using UnityEngine;
using System.Text;

public class TimeCounterWidgetController : MonoBehaviour
{
    [SerializeField] private TimeCounter _timeCounter;
    [SerializeField] private Text _text;

    private const int SECONDS_IN_MINUTE = 60;
    private void OnEnable()
    {
        UpdateTextValue();
    }
    private void UpdateTextValue()
    {
        var newText = new StringBuilder();

        var seconds = _timeCounter.Seconds % SECONDS_IN_MINUTE;
        var minutes = _timeCounter.Seconds / SECONDS_IN_MINUTE;

        newText.Append(minutes.ToString()).Append(":").Append(seconds.ToString());
        _text.text = newText.ToString();
    }
}
