using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr
{
    private static GameMgr _inst = null;
    public static GameMgr Instance { 
        get
        {
            if(_inst == null)
            {
                _inst = new GameMgr();
            }
            return _inst;
        }
    }
    private GameMgr() { }
    public void Initialize()
    {
        Debug.Log("GameMgr");
    }
}
