using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action<float, float> Changed;

    private float _starValue = 10f;
    private float _currentValue;

    private MonoBehaviour _owner;
    private Coroutine _coroutine;

    public float CurrentValue => _currentValue;
    public float StartValue => _starValue;

    public Timer(MonoBehaviour owner)
    {
        _owner = owner;
        _currentValue = _starValue;
    }

    public void StartTimer()
    {
        if (_coroutine == null)
            _coroutine = _owner.StartCoroutine(TimerRoutine());
    }

    public void PauseTimer()
    {
        _owner.StopCoroutine(_coroutine);
        Changed?.Invoke(_currentValue, _starValue);
        _coroutine = null;
    }

    public void ResetTimer()
    {
        _currentValue = _starValue;
        Changed?.Invoke(_currentValue, _starValue);
    }

    private IEnumerator TimerRoutine()
    {
        while (_currentValue > 0)
        {
            _currentValue -= Time.deltaTime;
            Changed?.Invoke(_currentValue, _starValue);
            //Debug.Log(_currentValue);
            yield return null;
        }

        _coroutine = null;
    }
}
