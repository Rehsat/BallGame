using UnityEngine.UI;
using UnityEngine;
using Zenject;

public class RetriesCountWidget : MonoBehaviour
{
    [SerializeField] private RetriesCounter _retriesCounter;
    [SerializeField] private Text _text;

    private void Awake()
    {
        _retriesCounter.OnRetriesCountValueChange += UpdateText;
    }
     private void UpdateText(int retriesCount)
    {
        _text.text = _retriesCounter.RetriesCount.ToString();
    }
    private void OnDestroy()
    {
        _retriesCounter.OnRetriesCountValueChange -= UpdateText;
    }

}
