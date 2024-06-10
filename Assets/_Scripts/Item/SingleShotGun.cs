using Photon.Pun;
using UnityEngine;

public class SingleShotGun : Gun
{
    [SerializeField] private Camera cam;

    //private PhotonView PV;

    [Space]
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float gravityForce;
    [SerializeField] private float bulletLifeTime;

    public override void Use()
    {
        Shoot();
    }

    private void Awake()
    {
        //PV = GetComponent<PhotonView>();
    }
    private void Shoot()
    {
        //Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        //ray.origin = cam.transform.position;

        //if (Physics.Raycast(ray, out RaycastHit hit))
        //{
        //    hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
        //    PV.RPC("RPC_Shoot", RpcTarget.All, hit.point, hit.normal);
        //}


        GameObject bullet = Instantiate(bulletPref, shootPoint.position, shootPoint.rotation);
        ParabolicBullet bulletScript = bullet.GetComponent<ParabolicBullet>();
        if(bulletScript)
            bulletScript.Initialize(shootPoint, shootSpeed, gravityForce);
        Destroy(bullet, bulletLifeTime);
    }

    //[PunRPC]
    //private void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    //{
    //    Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
    //    if (colliders.Length != 0)
    //    {
    //        GameObject bulletImpactObj = Instantiate(bulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * bulletImpactPrefab.transform.rotation);
    //        Destroy(bulletImpactObj, 10f);
    //        bulletImpactObj.transform.SetParent(colliders[0].transform);
    //    }
    //}
}
