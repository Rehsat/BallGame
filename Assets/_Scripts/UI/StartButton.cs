using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    [Inject]private SessionData _sessionData;

    private Button _button;
    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(StartGame);
    }
    private void StartGame()
    {
        _sessionData.GameState = GameState.Active;
        _sessionData.PlayerFactory.CreateBall();
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartGame);
    }
}
