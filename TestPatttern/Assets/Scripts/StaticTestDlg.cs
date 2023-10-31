using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StaticTestDlg : MonoBehaviour
{
    public Text m_txtResult = null;
    public Button m_btnStart;
    public Button m_BtnClear = null;

    private void Start()
    {
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_BtnClear.onClick.AddListener(OnClick_Clear);
    }
    public void OnClick_Start()
    {
        m_txtResult.text = string.Empty;
        TestStatic kim = new TestStatic(90);
        m_txtResult.text += kim.Print();
        TestStatic park = new TestStatic(80);
        m_txtResult.text += park.Print();
        TestStatic moon = new TestStatic(95);
        m_txtResult.text += moon.Print();

    }
    public void OnClick_Clear()
    {
        m_txtResult.text = string.Empty;
        TestStatic.total = 0;
    }
}
public class TestStatic
{
    public int score = 0;
    public static int total = 0;
    public TestStatic(int value)
    {
        score = value;
        total += value;
    }
    public string Print()
    {
        return string.Format("Score = {0}, Total = {1}\n",score,total);
    }
    
}
