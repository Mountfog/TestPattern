using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cscore
{
    public static int score = 0;


    public void Clear()
    {
        score = 0;
    }
    public Cscore(int z)
    {
        score += z;
    }
    public int Score
    {
        get { return score; }
    }
}
public class staticTestDlg : MonoBehaviour
{
    public Button m_btnStart = null;
    public Button m_btnClear = null; 
    void Start()
    {
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnClear.onClick.AddListener(OnClick_Clear);
        GameMgr.Instance.Initialize();
        GameMgr2.Inst.Initialize();
    }

    public void OnClick_Start()
    {
        Cscore cscore = new Cscore(90);
        Cscore kscore = new Cscore(90);
        Cscore lscore = new Cscore(95);
        Debug.Log(cscore.Score);
    }
    public void OnClick_Clear()
    {
        Cscore score = new Cscore(0);
        score.Clear();
    }
}
