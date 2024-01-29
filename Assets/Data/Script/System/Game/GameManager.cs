using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class GameManager : HuyMonoBehaviour
{
    public int fps = 60;

    protected override void Start()
    {
        base.Start();
        Application.targetFrameRate = fps;
    }
}
