using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMiniGame : MonoBehaviour
{
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    public Button m_btnAttack = null;
    public Text m_txtState = null;
    public Text m_txtMonster = null;
    public Text m_txtTime = null;
    bool m_isGame = false;
    int m_monsterHp = 100;
    float m_time = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnStop.onClick.AddListener(OnClick_Stop);
        m_btnAttack.onClick.AddListener(OnClick_Attack);

        Initialize();
    }
    public void Initialize()
    {
        m_monsterHp = 100;
        m_isGame = false;
        m_time = 10f;
        MonsterUpdate();
        TimeUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGame)
        {
            m_txtState.text = "Game";
            m_time -= Time.deltaTime;
            if (m_time < 0 || m_monsterHp <= 0)
            {
                if(m_monsterHp > 0)
                    m_txtState.text = "Result : ÆÐ¹è";
                else
                    m_txtState.text = "Result : ½Â¸®";
                
                m_isGame = false;
            }
            TimeUpdate();
        }
    }
    public void OnClick_Start()
    {
        m_txtState.text = "Ready";
        Initialize();
        Invoke(nameof(SetGame), 3f);
    }
    public void SetGame()
    {
        m_isGame = true;
    }
    public void OnClick_Stop()
    {
        m_isGame = false;
    }
    public void OnClick_Attack()
    {
        if (m_isGame)
        {
            m_monsterHp -= 4;
            MonsterUpdate();
        }

    }
    public void MonsterUpdate()
    {
        m_txtMonster.text = string.Format("Monster Hp = {0}", m_monsterHp);
    }
    public void TimeUpdate()
    {
        int time = Mathf.CeilToInt(m_time);
        m_txtTime.text = string.Format("time : {0}", time);
    }
}
