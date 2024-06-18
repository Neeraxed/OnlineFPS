using Photon.Pun;
using UnityEngine;

public interface IShootable
{
    public GameObject Particles { get; set; }

    [PunRPC]
    public void OnHit(RaycastHit hitInfo);
}
