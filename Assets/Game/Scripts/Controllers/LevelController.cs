using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Controller
{
    [SerializeField] private LevelSerialization _levels;
    private Level _currentLevel;

    public Level CurrentLevel => _currentLevel;

    #region States
    public override void Initialize(GameManager gameManager)
    {
        LoadLevel();
    }
    public override void StartGame()
    {
        _currentLevel.StartGame();
    }
    public override void Reload()
    {
        UnloadLevel();
        LoadLevel();
    }
    public override void GameOver()
    {
    }

    #endregion

    private void LoadLevel()
    {
        int currentLevelCount = PlayerHelper.Instance.PlayerLevel - 1;

        if (currentLevelCount >= _levels.Count)
        {
            currentLevelCount = Random.Range(0, _levels.Count);
        }
        _currentLevel = Instantiate(_levels[currentLevelCount]);
        _currentLevel.Build();
    }

    private void UnloadLevel()
    {
        _currentLevel.Remove();
    }
}
