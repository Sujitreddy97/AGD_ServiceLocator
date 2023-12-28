using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;

public class GameService: GenericMonoSingleton<GameService>
{
    public PlayerService PlayerService { get; private set; }

    [SerializeField] public PlayerScriptableObject playerScriptableObject;

    private void Start()
    {
        PlayerService = new PlayerService(playerScriptableObject);
    }

    private void Update()
    {
        PlayerService.Update();
    }
}
