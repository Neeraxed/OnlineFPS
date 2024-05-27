using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float minDist;
    [SerializeField] private float speed;
    [SerializeField] private bool rand = false;
    [SerializeField] private bool go = true;

    private int num = 0;

    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);
        if (go)
        {
            if (dist > minDist)
            {
                Move();
            }
            else
            {
                if (!rand)
                {
                    if (num + 1 == waypoints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    num = Random.Range(0, waypoints.Length);
                }
            }
        }
    }

    public void Move()
    {
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }
}
