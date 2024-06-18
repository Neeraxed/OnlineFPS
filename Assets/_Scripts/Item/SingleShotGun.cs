using Photon.Pun;
using UnityEngine;

public class SingleShotGun : Gun
{
    [SerializeField] private Camera cam;

    [SerializeField] private BulletCreator bulletCreator;

    private PhotonView PV;

    public override void Use()
    {
        Shoot();
    }

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Shoot()
    {
        PV.RPC("CreateBullets", RpcTarget.All);
    }

    [PunRPC]
    private void CreateBullets()
    {
        var parabolicbullet = bulletCreator.CreateParabolicBullet(((GunInfo)itemInfo).damage);
        bulletCreator.CreateVisualBullet(parabolicbullet);
    }
}
