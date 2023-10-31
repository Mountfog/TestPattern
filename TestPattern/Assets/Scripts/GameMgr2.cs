using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr2 : MonoBehaviour
{
    private static GameMgr2 _inst = null;
    public static GameMgr2 Inst
    {
        get
        {
            if( _inst == null)
            {
                GameObject go = new GameObject("GameMgr2");
                _inst = go.AddComponent<GameMgr2>();
                DontDestroyOnLoad(go);
            }
            return _inst;
        }
    }
    public void Initialize()
    {
        Debug.Log("GameMgr2");
    }
}
public class SingleTon<T> where T : class, new()
{
    static T _inst = null;
    public static T Inst
    {
        get
        {
            if( _inst == null)
            {
                _inst = new T();
            }
            return _inst;
        }
    }
}
