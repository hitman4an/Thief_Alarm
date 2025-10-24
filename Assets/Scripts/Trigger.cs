using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action ThiefEntered;
    public event Action ThiefQuit;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Thief>())
            ThiefEntered?.Invoke();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Thief>())
            ThiefQuit?.Invoke();
    }
}
