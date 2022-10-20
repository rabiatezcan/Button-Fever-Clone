using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonData
{
    public int CurrentType { get; set; }
    public float[] Position { get; set; }

    public ButtonData(Button button)
    {
        CurrentType = ((int)button.CurrentType);

        Vector3 pos = button.transform.position;
        Position = new float[]
        {
            pos.x, pos.y, pos.z
        };
    }
}

