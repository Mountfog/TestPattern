using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    [HideInInspector] public BattleFSM m_battleFSM = new BattleFSM();
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    public Button m_BtnAttack = null;

    public Text m_txtState = null;
    public Text m_txtTime = null;
    public Text m_txtMonsterHp = null;

    bool isWin = false;
    float time = 0;
    float monsterHp = 100;
    private void Awake()
    {
        m_battleFSM.Initialize(CB_Ready, CB_Wave, CB_Game, CB_Result);
    }
    private void Start()
    {
        monsterHp = 100;
        isWin = false;
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnStop.onClick.AddListener(OnClick_Stop);
        m_BtnAttack.onClick.AddListener(OnClick_Attack);
    }
    void CB_Ready()
    {
        monsterHp = 100;
        isWin = false;
        m_txtState.text = "Ready";
        StartCoroutine("ReadyCoroutine");
    }
    void CB_Wave()
    {
        m_txtState.text = "Wave";
    }
    void CB_Game()
    {
        m_txtState.text = "Game";
        StartCoroutine(GameCoroutine());
    }
    void CB_Result()
    {
        m_txtState.text = isWin ? "Result(½Â¸®)" : "Result(ÆÐ¹è)";
    }
    public void OnClick_Start()
    {
        m_battleFSM.SetReadyState();
    }
    public void OnClick_Stop()
    {

    }
    public void OnClick_Attack()
    {
        if (m_battleFSM.IsGameState())
        {
            monsterHp -= 1;
            m_txtMonsterHp.text = string.Format("MonsterHP = {0}", monsterHp);
            if(monsterHp <= 0)
            {
                isWin = true;
                m_battleFSM.SetResultState();
            }
        }
    }
    IEnumerator ReadyCoroutine()
    {
        yield return new WaitForSeconds(1f);
        m_battleFSM.SetGameState();
    }
    IEnumerator GameCoroutine()
    {
        while (m_battleFSM.IsGameState())
        {
            time += Time.deltaTime;
            m_txtTime.text = string.Format("Time : {0:00.0}",20f - time);
            yield return null;
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        if(m_battleFSM != null)
            m_battleFSM.OnUpdate();
        
    }
}
