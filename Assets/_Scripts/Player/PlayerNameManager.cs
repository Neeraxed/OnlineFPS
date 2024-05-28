using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField _usernameInput;

    private string _usernameKey = "Username";

    public void OnUsernameInputValueChanged()
    {
        PhotonNetwork.NickName = _usernameInput.text;
        PlayerPrefs.SetString(_usernameKey, _usernameInput.text);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(_usernameKey))
        {
            _usernameInput.text = PlayerPrefs.GetString(_usernameKey);
            PhotonNetwork.NickName = PlayerPrefs.GetString(_usernameKey);
        }
        else
        {
            _usernameInput.text = "Player " + Random.Range(0, 10000).ToString("0000");
            OnUsernameInputValueChanged();
        }
    }
}
