using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 5;

    private int _currentWaypoint = 0;
    
    private void Update()
    {
        Vector3 target = _waypoints[_currentWaypoint].position;

        if (transform.position == target)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }

        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
