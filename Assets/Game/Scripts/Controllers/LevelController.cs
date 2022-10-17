using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Controller
{
    [SerializeField] private LevelSerialization _levels;
    private Level _currentLevel;

    #region States
    public override void Initialize(GameManager gameManager)
    {
        LoadLevel();
    }
    public override void StartGame()
    {
    }
    public override void Reload()
    {
        UnloadLevel();
        LoadLevel();
    }
    public override void GameFail()
    {
    }

    public override void GameSuccess()
    {
    }
    #endregion

    private void LoadLevel()
    {
        _currentLevel.Initialize();
        _currentLevel.Build();
    }

    private void UnloadLevel()
    {
        _currentLevel.Remove();
    }
}
