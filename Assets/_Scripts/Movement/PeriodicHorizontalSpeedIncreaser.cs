using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicHorizontalSpeedIncreaser : MonoBehaviour
{
    [SerializeField] private HorizontalMovable _horizontalMovable;
    [SerializeField] private float _periodicTime;
    [SerializeField] private float _speedIncrease;

    private void OnEnable()
    {
        
    }
    private IEnumerator IncreasingSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(_periodicTime);
            _horizontalMovable.Speed += _speedIncrease;
        }
    }
}
