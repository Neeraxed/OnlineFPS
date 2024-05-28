using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoints;
    [SerializeField] private float _minDist;
    [SerializeField] private float _speed;
    [SerializeField] private bool _rand = false;
    [SerializeField] private bool _go = true;

    private int _num = 0;

    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, _waypoints[_num].transform.position);
        if (_go)
        {
            if (dist > _minDist)
            {
                Move();
            }
            else
            {
                if (!_rand)
                {
                    if (_num + 1 == _waypoints.Length)
                    {
                        _num = 0;
                    }
                    else
                    {
                        _num++;
                    }
                }
                else
                {
                    _num = Random.Range(0, _waypoints.Length);
                }
            }
        }
    }

    public void Move()
    {
        gameObject.transform.LookAt(_waypoints[_num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * _speed * Time.deltaTime;
    }
}
