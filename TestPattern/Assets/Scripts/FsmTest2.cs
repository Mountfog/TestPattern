using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FsmTest2 : MonoBehaviour
{
    [HideInInspector] public BattleFSM m_battleFSM = new BattleFSM();
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    public Button m_btnAttack = null;
    public Text m_txtMonsterHp = null;
    public Text m_txtState = null;
    public Text m_txtTime = null;
    float time = 0;
    float monsterHp = 0;
    private void Awake()
    {
        m_battleFSM.Initialize(CB_Ready, CB_Wave, CB_Game, CB_Result);
    }

    void Start()
    {
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnAttack.onClick.AddListener(OnClick_Attack);
    }
    void CB_Ready()
    {
        m_txtState.text = "Ready";
        time = 0;
        m_txtTime.text = string.Format("Time : 0");
        monsterHp = 100;
        m_txtMonsterHp.text = string.Format("MonsterHp = 100");
        StartCoroutine(ReadyCor());
    }
    void CB_Wave()
    {

    }
    void CB_Game()
    {
        m_txtState.text = "Game";
    }
    void CB_Result()
    {
        m_txtState.text = (monsterHp <= 0) ? "Result(½Â¸®)" : "Result(ÆÐ¹è)";
    }
    IEnumerator ReadyCor()
    {
        yield return new WaitForSeconds(1);
        m_battleFSM.SetGameState();
        yield return null;
    }
    void OnClick_Start()
    {
        if(m_battleFSM != null) 
        m_battleFSM.SetReadyState();
    }
    void OnClick_Attack()
    {
        if (m_battleFSM.IsGameState())
        {
            monsterHp -= 1;
            m_txtMonsterHp.text = string.Format("MonsterHp = {0}", monsterHp);
            if(monsterHp <= 0)
            {
                m_battleFSM.SetResultState();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_battleFSM.IsGameState())
        {
            time += Time.deltaTime;
            m_txtTime.text = string.Format("Time : {0:00.0}",20f - time);
            if(time >= 20f)
            {
                m_battleFSM.SetResultState();
            }
        }
        if (m_battleFSM != null)
            m_battleFSM.OnUpdate();
    }
}
