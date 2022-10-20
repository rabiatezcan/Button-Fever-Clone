using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : Controller
{
    [SerializeField] private SpawnHandler _spawnHandler;
    [SerializeField] private CheckBoardAreaHandler  _checkBoardAreaHandler;
    #region Core
    public override void Initialize(GameManager gameManager)
    {
        _spawnHandler.Initialize(gameManager.LevelController);
        _checkBoardAreaHandler.Initialize(gameManager.LevelController);
        ScoreSystem.Initialize();
    }
    public override void StartGame()
    {
    }

    public override void Reload()
    {
    }

    public override void GameOver()
    {
    }
    #endregion







}
