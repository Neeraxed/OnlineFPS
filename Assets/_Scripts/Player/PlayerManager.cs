using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Linq;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerManager : MonoBehaviour
{
    private PhotonView _PV;
    private GameObject _controller;
    private int _kills;
    private int _deaths;

    public static PlayerManager Find(Player player)
    {
        return FindObjectsOfType<PlayerManager>().SingleOrDefault(x => x._PV.Owner == player);
    }

    public void Die()
    {
        PhotonNetwork.Destroy(_controller);
        CreateController();

        _deaths++;

        Hashtable hash = new Hashtable();
        hash.Add("Deaths", _deaths);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public void GetKill()
    {
        _PV.RPC(nameof(RPC_GetKill), _PV.Owner);
    }

    private void Awake()
    {
        _PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (_PV.IsMine)
        {
            CreateController();
        }
    }

    private void CreateController()
    {
        Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        _controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { _PV.ViewID });
    }

    [PunRPC]
    private void RPC_GetKill()
    {
        _kills++;

        Hashtable hash = new Hashtable();
        hash.Add("Kills", _kills);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}