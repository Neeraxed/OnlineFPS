using Photon.Pun;
using TMPro;
using UnityEngine;

public class UsernameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView _playerPV;
    [SerializeField] TMP_Text _text;

    private void Start()
    {
        if (_playerPV.IsMine)
        {
            gameObject.SetActive(false);
        }

        _text.text = _playerPV.Owner.NickName;
    }
}
