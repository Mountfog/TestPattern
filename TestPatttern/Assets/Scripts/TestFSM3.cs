using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class TestFSM3 : MonoBehaviour
{
    [HideInInspector] public BattleFSM m_battleFSM = new BattleFSM();
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    public Text m_TxtHealth = null;
    public Text m_txtKey = null;
    public Text m_txtState = null;
    public Text m_txtTime = null;
    public Text m_txtScore = null;
    float time = 0;
    int currentKey = 0;
    float score = 0;
    float health = 3;
    private void Awake()
    {
        m_battleFSM.Initialize(CB_Ready, CB_Game, CB_Wave, CB_Result);
    }
    // Start is called before the first frame update
    void Start()
    {
        m_btnStart.onClick.AddListener(OnClick_Start);
    }

    void CB_Ready()
    {
        Debug.Log("ready");
        m_txtState.text = "Ready";
        time = 0; score = 0; health = 3;
        currentKey = Random.Range(0, 10);
        m_txtKey.text = string.Format("Key : {0}", currentKey);
        m_TxtHealth.text = string.Format("Health = 3");
        m_txtTime.text = string.Format("Time : 0");
        m_txtScore.text = string.Format("Score = 0");
        StartCoroutine(ReadyCor());
    }
    void CB_Wave()
    {
        Debug.Log("wave");
        m_txtState.text = "Wave";
        StartCoroutine(KeySet());
    }
    void CB_Game()
    {
        Debug.Log("game");
        m_txtState.text = "Game";
    }
    void CB_Result()
    {
        Debug.Log("result");
        m_txtState.text = (health > 0) ? "Result(½Â¸®)" : "Result(ÆÐ¹è)";
    }
    IEnumerator KeySet()
    {
        int randomkey = Random.Range(0, 10);
        while (currentKey == randomkey)
        {
            randomkey = Random.Range(0, 10);
        }
        currentKey = randomkey;
        yield return new WaitForSeconds(1f);
        m_txtKey.text = string.Format("Key : {0}", randomkey);
        m_battleFSM.SetGameState();
        yield return null;
    }
    IEnumerator ReadyCor()
    {
        yield return new WaitForSeconds(1);
        m_battleFSM.SetGameState();
        yield return null;
    }
    void OnClick_Start()
    {
        if (m_battleFSM != null)
            m_battleFSM.SetReadyState();
    }
    // Update is called once per frame
    void Update()
    {
        if (m_battleFSM == null) return;
        if (m_battleFSM.IsGameState())
        {
            for (int i = 0; i < 10; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + i))
                {
                    if (i == currentKey)
                    {
                        score += 10;
                        m_txtScore.text = string.Format("Score = {0}", score);
                    }
                    else
                    {
                        health -= 1;
                        m_TxtHealth.text = string.Format("Health = {0}", health);

                    }
                    if (health <= 0)
                        m_battleFSM.SetResultState();
                    else
                        m_battleFSM.SetWaveState();
                    break;
                }
            }
            time += Time.deltaTime;
            m_txtTime.text = string.Format("Time : {0:00.0}", 20f - time);
            if (time >= 20f)
            {
                m_battleFSM.SetResultState();
            }
        }
        m_battleFSM.OnUpdate();
    }
}
