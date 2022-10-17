using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : Screen
{
    private bool _isLoadingDurationCompleted;
    public bool IsLoadingDurationCompleted => _isLoadingDurationCompleted;
    public override void Show()
    {
        base.Show();
        StartCoroutine(LoadingScreenCoroutine());
    }
    public override void Hide()
    {
        base.Hide();
        _isLoadingDurationCompleted = false;
    }
    public IEnumerator LoadingScreenCoroutine()
    {
        yield return new WaitForSeconds(CONSTANTS.LOADING_DURATION);
        _isLoadingDurationCompleted = true;
    }

}
