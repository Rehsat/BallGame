using UnityEngine;
using Zenject;

public class WindowVisibilityChangerByGameState : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private bool _inverse;
    [Inject] private SessionData _sessionData;

    private void Start()
    {
        _sessionData.OnGameStateChange += ChangeWindowState;
        ChangeWindowState(_sessionData.GameState);
    }
    private void ChangeWindowState(GameState state)
    {
        bool activationState;

        if (state == GameState.Active)
            activationState = true;
        else
            activationState = false;

        if (_inverse)
            activationState = !activationState;

        _window.SetActive(activationState);
    }
    private void OnDisable()
    {
        _sessionData.OnGameStateChange -= ChangeWindowState;
    }
}
