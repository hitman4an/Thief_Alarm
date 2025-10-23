using System.Collections;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _step = 0.1f;
    private float _delay = 0.5f;
    private bool _volumeIncrease = false;
    private Coroutine _coroutine;

    public void SetVolumeIncrease(bool value)
    {
        _volumeIncrease = value;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _coroutine = StartCoroutine(SmoothVolumeChange());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator SmoothVolumeChange()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            if (_volumeIncrease)
            {
                if (_audioSource.volume == 0)
                {
                    _audioSource.Play();
                }

                _audioSource.volume += _step;

                yield return wait;
            }
            else
            {
                _audioSource.volume -= _step;

                if (_audioSource.volume == 0)
                {
                    _audioSource.Stop();
                }

                yield return wait;
            }
        }
    }
}
