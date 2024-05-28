using Photon.Pun;
using UnityEngine;

public class SingleShotGun : Gun
{
    [SerializeField] Camera _camera;

    private PhotonView _PV;

    public override void Use()
    {
        Shoot();
    }

    private void Awake()
    {
        _PV = GetComponent<PhotonView>();
    }

    private void Shoot()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = _camera.transform.position;
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)ItemInfo).Damage);
            _PV.RPC("RPC_Shoot", RpcTarget.All, hit.point, hit.normal);
        }
    }

    [PunRPC]
    private void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        if (colliders.Length != 0)
        {
            GameObject bulletImpactObj = Instantiate(BulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * BulletImpactPrefab.transform.rotation);
            Destroy(bulletImpactObj, 10f);
            bulletImpactObj.transform.SetParent(colliders[0].transform);
        }
    }
}
