using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnums
{ 
    public enum GameState
    {
        Loading, 
        Main,
        Game,
        End
    }

    public enum LevelEditorTypes
    {
        Info,
        Create, 
    }
    public enum LevelObjects
    {
        Ball,
        Platform,
        CheckPoint,
        LevelEnd, 
        WingTrigger
    }  
    
}
