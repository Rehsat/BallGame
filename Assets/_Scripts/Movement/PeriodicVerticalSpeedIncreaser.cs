using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicVerticalSpeedIncreaser : MonoBehaviour
{
    [SerializeField] private VerticalMovable _verticalMovable;
    [SerializeField] private float _periodicTime;
    [SerializeField] private float _speedIncrease;

    private void OnEnable()
    {
        StartCoroutine(IncreasingSpeed());
    }
    private IEnumerator IncreasingSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(_periodicTime);
            _verticalMovable.Speed += _speedIncrease;
        }
    }
}
