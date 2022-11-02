using UnityEngine;
using Zenject;
public class DifficultChanger : MonoBehaviour
{
    [Inject] private SessionData _sessionData;

    public void ChangeDifficulty(int difficulty)
    {
        _sessionData.GameDifficulty = difficulty;
    }
}
