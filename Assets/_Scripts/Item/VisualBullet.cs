using UnityEngine;

public class VisualBullet : MonoBehaviour
{
    private Vector3 startPosition;
    private ParabolicBullet original;
    private float timer;
    private Vector3 position;
    private bool isInitialized = false;

    public void Initialize(Transform startPoint, ParabolicBullet original)
    {
        startPosition = startPoint.position;
        this.original = original;
        timer = 0;
        isInitialized = true;
    }

    private void Start()
    {
        transform.position = position = startPosition;
    }

    private void FixedUpdate()
    {
        if (!isInitialized) return;
        timer += Time.fixedDeltaTime;
        if (original != null)
            position = Vector3.Lerp(transform.position, original.transform.position, timer);
        else
            Destroy(gameObject);        
    }

    private void LateUpdate()
    {
        if (!isInitialized) return;
        transform.position = position;
    }
}
