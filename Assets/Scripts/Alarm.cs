using System.Collections;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _step = 1f;
    private float _delay = 0.1f;
    private bool _enabled = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _enabled = true;
        StopCoroutine(SmoothVolumeDecrease());
        StartCoroutine(SmoothVolumeIncrease());
    }

    private void OnCollisionExit(Collision collision)
    {
        _enabled = false;
        StopCoroutine(SmoothVolumeIncrease());
        StartCoroutine(SmoothVolumeDecrease());
    }

    private IEnumerator SmoothVolumeIncrease()
    {
        var wait = new WaitForSeconds(_delay);

        while (_enabled)
        {
            _audioSource.volume += _step * Time.deltaTime;
            yield return wait;
        }
    }

    private IEnumerator SmoothVolumeDecrease()
    {
        var wait = new WaitForSeconds(_delay);

        while (_enabled == false)
        {
            _audioSource.volume -= _step * Time.deltaTime;
            yield return wait;
        }
    }
}
