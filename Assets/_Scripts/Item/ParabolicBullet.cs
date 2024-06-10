using UnityEngine;

public class ParabolicBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float gravity;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 startForward;

    private bool isInitialized = false;
    private float startTime = -1;
    private float currentTime;

    public void Initialize(Transform startPoint, float speed, float gravity)
    {
        startPosition = startPoint.position;
        startForward = startPoint.forward;
        this.speed = speed;
        this.gravity = gravity;
        isInitialized = true;
        transform.position = startPosition;
    }

    private Vector3 FindPointOnParabola(float time)
    {
        Vector3 point = startPosition + (startForward * speed * time);
        Vector3 gravityVector = Vector3.down * gravity * time * time;
        return point + gravityVector;
    }

    private bool CastRayBetweenPoints(Vector3 startPoint, Vector3 endPoint, out RaycastHit hit)
    {
        return Physics.Raycast(startPoint, endPoint - startPoint, out hit, (endPoint - startPoint).magnitude);
    }

    private void FixedUpdate()
    {
        if (!isInitialized) return;
        if (startTime < 0) startTime = Time.time;

        currentTime = Time.time - startTime;
        float nextTime = currentTime + Time.fixedDeltaTime;

        Vector3 currentPoint = FindPointOnParabola(currentTime);
        Vector3 nextPoint = FindPointOnParabola(nextTime);

        RaycastHit hit;

        if (CastRayBetweenPoints(currentPoint, nextPoint, out hit))
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (!isInitialized) return;

        Vector3 currentPoint = FindPointOnParabola(currentTime);
        transform.position = currentPoint;
    }
}
