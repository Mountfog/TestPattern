using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFSM2 : MonoBehaviour
{
    [HideInInspector] private BattleFSM m_BattleFSM = new BattleFSM();

    public Button m_btnStart = null;
    public Button m_btnStop = null;
    public Button m_btnAttack = null;
    public Text m_txtMonster = null;
    public Text m_txtTime = null;
    public Text m_txtState = null;
    public int m_monsterHp = 0;
    public float m_time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        m_BattleFSM.Initialize(CB_Ready, CB_Game, CB_Wave, CB_Result);
        m_btnAttack.onClick.AddListener(OnClick_Attack);
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnStop.onClick.AddListener(OnClick_Stop);
    }
    public void OnClick_Start()
    {
        if (!m_BattleFSM.IsReadyState())
        {
            m_BattleFSM.SetReadyState();
        }
    }
    public void Initialize()
    {
        m_monsterHp = 100;
        m_time = 10f;
        MonsterUpdate();
        TimeUpdate();
    }
    public void SetGameState()
    {
        m_BattleFSM.SetGameState();
    }

    public void OnClick_Stop()
    {
        if (m_BattleFSM.IsGameState())
        {
            m_BattleFSM.SetWaveState();
        }
        else if (m_BattleFSM.IsWaveState())
        {
            m_BattleFSM.SetGameState();
        }
    }
    public void OnClick_Attack()
    {
        if (!m_BattleFSM.IsGameState()) return;
        m_monsterHp -= 2;
        MonsterUpdate();
        if (m_monsterHp <= 0)
        {
            m_BattleFSM.SetResultState();
        }
    }
    public void CB_Ready()
    {
        m_txtState.text = "Ready";
        Initialize();
        Invoke(nameof(SetGameState), 1f);
    }
    public void CB_Game()
    {
        m_txtState.text = "Game";
    }
    public void CB_Wave()
    {
        m_txtState.text = "Wave";
    }
    public void CB_Result()
    {

        if (m_time <= 0f)
        {
            m_txtState.text = "Result(ÆÐ¹è)";
        }
        else
        {
            m_txtState.text = "Result(½Â¸®)";
        }
    }
    void Update()
    {
        if (m_BattleFSM == null) return;
        m_BattleFSM.OnUpdate();
        if (m_BattleFSM.IsGameState())
        {
            m_time -= Time.deltaTime;
            TimeUpdate();
            if (m_time <= 0f)
            {
                m_BattleFSM.SetResultState();
            }
        }
    }
    public void MonsterUpdate()
    {
        m_txtMonster.text = string.Format("Monster Hp = {0}", m_monsterHp);
    }
    public void TimeUpdate()
    {
        m_txtTime.text = string.Format("time : {0:0}", m_time);
    }
    // Update is called once per frame

}
