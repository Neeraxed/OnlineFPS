using Photon.Pun;
using UnityEngine;

public class Enemy : MonoBehaviour, IShootable
{
    [SerializeField] private GameObject particlesPrefab;

    public GameObject Particles { get => particlesPrefab; set => particlesPrefab = value; }

    [PunRPC]
    public void OnHit(RaycastHit hitInfo)
    {
        GameObject pt = Instantiate(particlesPrefab, hitInfo.point + (hitInfo.normal * 0.05f), Quaternion.LookRotation(hitInfo.normal, Vector3.up) * particlesPrefab.transform.rotation, transform.root.parent);
        Destroy(pt, 2f);
    }
}