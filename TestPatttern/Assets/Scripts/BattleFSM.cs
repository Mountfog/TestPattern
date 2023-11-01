using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFSM
{
    public delegate void DelegateFunc();

    public class CState
    {
        public DelegateFunc m_onEnterFunc = null;
        public DelegateFunc m_onExitFunc = null; 
        public virtual void Initialize(DelegateFunc func)
        {
            m_onEnterFunc = new DelegateFunc(func);
        }
        public virtual void OnEnter()
        {
            if(m_onEnterFunc != null)
            {
                m_onEnterFunc();
            }
        }
        public virtual void OnUpdate() { }
        public virtual void OnExit() { }
    }
    public class CReadyState : CState { }
    public class CGameState : CState { }
    public class CWaveState : CState { }
    public class CResultState : CState { }

    public CState m_kReady = new CReadyState();
    public CState m_kGame = new CGameState();
    public CState m_kWave = new CWaveState();
    public CState m_kResult = new CResultState();

    private CState m_curState = null;
    private CState m_newState = null;

    public void Initialize(DelegateFunc kready, DelegateFunc kgame, DelegateFunc kwave, DelegateFunc kresult)
    {
        m_kReady.Initialize(kready);
        m_kGame.Initialize(kgame);
        m_kWave.Initialize(kwave);
        m_kResult.Initialize(kresult);
    }

    public void SetState(CState kstate)
    {
        m_newState = kstate;
    }

    public void OnUpdate()
    {
        if(m_newState != null)
        {
            if (m_curState != null)
                m_curState.OnExit();
            m_curState = m_newState;
            m_newState = null;
            m_curState.OnEnter();
        }
        if(m_curState != null)
        {
            m_curState.OnUpdate();
        }
    }
    public void SetReadyState() { SetState(m_kReady); }
    public void SetGameState() { SetState(m_kGame); }
    public void SetWaveState() { SetState(m_kWave); }
    public void SetResultState() { SetState(m_kResult); }
    public bool IsNullState() { return m_curState == null; }
    public bool IsReadyState() { return m_curState == m_kReady; }
    public bool IsGameState() { return m_curState == m_kGame; }
    public bool IsWaveState() { return m_curState == m_kWave; }
    public bool IsResultState() { return m_curState == m_kResult; }
}
