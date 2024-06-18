using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private Transform visualBulletStart;
    [SerializeField] private Transform parabolicBulletStart;
    [Space]
    [SerializeField] private GameObject visualBulletPref;
    [SerializeField] private GameObject parabolicBulletPref;
    [Space]
    [SerializeField] private float shootSpeed;
    [SerializeField] private float gravityForce;
    [SerializeField] private float bulletLifeTime;

    public GameObject CreateParabolicBullet(float damage)
    {
        GameObject bullet = Instantiate(parabolicBulletPref, parabolicBulletStart.position, parabolicBulletStart.rotation);
        ParabolicBullet bulletScript = bullet.GetComponent<ParabolicBullet>();
        if (bulletScript)
            bulletScript.Initialize(parabolicBulletStart, shootSpeed, gravityForce, damage);
        Destroy(bullet, bulletLifeTime);

        return bullet;
    }

    public void CreateVisualBullet(GameObject original)
    {
        GameObject bullet = Instantiate(visualBulletPref, visualBulletStart.position, visualBulletStart.rotation);
        VisualBullet bulletScript = bullet.GetComponent<VisualBullet>();
        if (bulletScript)
            bulletScript.Initialize(visualBulletStart, original.GetComponent<ParabolicBullet>());
        Destroy(bullet, bulletLifeTime);
    }
}
