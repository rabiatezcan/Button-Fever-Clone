using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MergeHandler 
{
    private static List<Button> _buttons = new List<Button>();

    private static bool AreButtonsSame => _buttons[0].CurrentType == _buttons[1].CurrentType;
    private static bool BothOnMergeArea => _buttons[0].OnMergeArea && _buttons[1].OnMergeArea;

    public static void AddMergeElement(Button button)
    {
        _buttons.Add(button);
        CheckMerge();
    }

    private static void ClearAll()
    {
        _buttons.Clear();
    }

    private static void CheckMerge()
    {
        if (_buttons.Count == 2)
            Merge();
    }
    private static void Merge()
    {
        if (AreButtonsSame && BothOnMergeArea)
        {
            _buttons[0].IncreaseBody();
            _buttons[1].Dismiss();
        }
        else
        {
            _buttons[0].ReturnDefaultPosition();
            _buttons[1].ReturnDefaultPosition();
        }

        ClearAll();
    }
}
