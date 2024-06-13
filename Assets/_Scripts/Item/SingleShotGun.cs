using Photon.Pun;
using UnityEngine;

public class SingleShotGun : Gun
{
    [SerializeField] private Camera cam;

    [SerializeField] private BulletCreator bulletCreator;

    //private PhotonView PV;

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


        var parabolicbullet = bulletCreator.CreateParabolicBullet();
        bulletCreator.CreateVisualBullet(parabolicbullet);
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
