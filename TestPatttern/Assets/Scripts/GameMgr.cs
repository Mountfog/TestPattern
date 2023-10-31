using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameMgr
{
    static GameMgr _inst = null;
    public static GameMgr Inst
    {
        get{
            if (_inst == null)
                _inst = new GameMgr();
            return _inst;
        }
    }
    public int m_Score = 0;
}
public class GameMgr2
{
    static GameMgr2 _inst = null;
    public static GameMgr2 Inst()
    {
        if (_inst == null)
            _inst = new GameMgr2();
        return _inst;
    }
    public int m_Score = 0;
}
public class GameMgr3 : MonoBehaviour
{
    static GameMgr3 _inst = null;
    public static GameMgr3 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject go = new GameObject("Singleton GameMgr");
                _inst = go.AddComponent<GameMgr3>();
                DontDestroyOnLoad(go);
            }
            return _inst;
        }
    }
    float Lerp(float start, float end, float t)
    {
        return start + (end - start) * t;
    }
}
