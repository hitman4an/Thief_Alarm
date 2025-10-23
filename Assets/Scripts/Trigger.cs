using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private bool _isEnabled = false;

    private void OnTriggerEnter()
    {
        _isEnabled = !_isEnabled;
        _alarm.SetVolumeIncrease(_isEnabled);
    }
}
