using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ScoreboardItem : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text _usernameText;
    [SerializeField] private TMP_Text _killsText;
    [SerializeField] private TMP_Text _deathsText;

    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;

        _usernameText.text = player.NickName;
        UpdateStats();
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer == _player)
        {
            if (changedProps.ContainsKey("kills") || changedProps.ContainsKey("deaths"))
            {
                UpdateStats();
            }
        }
    }

    private void UpdateStats()
    {
        if (_player.CustomProperties.TryGetValue("kills", out object kills))
        {
            _killsText.text = kills.ToString();
        }
        if (_player.CustomProperties.TryGetValue("deaths", out object deaths))
        {
            _deathsText.text = deaths.ToString();
        }
    }
}
