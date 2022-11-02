using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TravelledDistanceEventer : MonoBehaviour
{
    [SerializeField] private float _tilesToEvent;
    [SerializeField] private UnityEvent _onDistanceTravelled;

    private Vector2 _goalPoint;
    private Vector2 _lastEventCoordinates;

    private const float SECONDS_TO_CHECK_DISTANCE = 1;
    public Vector2 LastEventCoordinates 
    {
        get => _lastEventCoordinates;
        private set
        {
            _lastEventCoordinates = value;
            _goalPoint = new Vector2(_lastEventCoordinates.x + _tilesToEvent,0);
        }
    }
     

    private void OnEnable()
    {
        LastEventCoordinates = transform.position;
        StartCoroutine(CheckingDistanceToGoal());
    }
    private IEnumerator CheckingDistanceToGoal()
    {
        while (true)
        {
            yield return new WaitForSeconds(SECONDS_TO_CHECK_DISTANCE);
            var distance = _goalPoint.x - transform.position.x;
            Debug.Log(distance);
            if (distance <= 0)
            {
                _onDistanceTravelled?.Invoke();
                LastEventCoordinates = transform.position;
            }
        }
           
    }
    private void OnDisable()
    {
        StopCoroutine(CheckingDistanceToGoal());
    }
}
