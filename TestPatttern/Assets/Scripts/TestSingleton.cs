using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSingleton : MonoBehaviour
{
    public Text m_txtResult = null;
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    // Start is called before the first frame update
    void Start()
    {
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnStop.onClick.AddListener(OnClick_Stop);
    }

    public void OnClick_Start()
    {
        m_txtResult.text = string.Empty;
        GameMgr.Inst.m_Score += 100;
        GameMgr2.Inst().m_Score += 96;
        m_txtResult.text += string.Format("(GameMgr)Score = {0}\n",GameMgr.Inst.m_Score);
        m_txtResult.text += string.Format("(GameMgr2)Score = {0}\n", GameMgr2.Inst().m_Score);
    }
    public void OnClick_Stop()
    {
        m_txtResult.text = string.Empty;
        GameMgr.Inst.m_Score = 0;
        GameMgr2.Inst().m_Score = 0;
    }
}
