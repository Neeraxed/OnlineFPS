﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform _container;
    [SerializeField] GameObject _scoreboardItemPrefab;
    [SerializeField] CanvasGroup _canvasGroup;

    Dictionary<Player, ScoreboardItem> scoreboardItems = new Dictionary<Player, ScoreboardItem>();

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreboardItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreboardItem(otherPlayer);
    }

    private void Start()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddScoreboardItem(player);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _canvasGroup.alpha = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            _canvasGroup.alpha = 0;
        }
    }

    private void AddScoreboardItem(Player player)
    {
        ScoreboardItem item = Instantiate(_scoreboardItemPrefab, _container).GetComponent<ScoreboardItem>();
        item.Initialize(player);
        scoreboardItems[player] = item;
    }

    private void RemoveScoreboardItem(Player player)
    {
        Destroy(scoreboardItems[player].gameObject);
        scoreboardItems.Remove(player);
    }
}