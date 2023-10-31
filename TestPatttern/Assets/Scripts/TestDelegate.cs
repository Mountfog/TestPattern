using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDelegate : MonoBehaviour
{
    public Text m_txtResult = null;
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public List<TextItem> m_listItems = new List<TextItem>();
    public List<string> m_cities = new List<string>();
    public TextItem m_curTextItem = null;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<m_listItems.Count;i++)
        {
            TextItem item = m_listItems[i];
            item.Initialize(m_cities[i]);
            item.AddListner(OnClickButton);
        }
        m_btnResult.onClick.AddListener(OnClick_Start);
        m_btnClear.onClick.AddListener(OnClick_Clear);
    }
    public void OnClickButton(TextItem txt, bool bSelect)
    {
        foreach(var item in m_listItems)
        {
            item.SetColor(false);
        }
        txt.SetColor(true);
        m_curTextItem = txt;
    }

    public void OnClick_Start()
    {
        if (m_curTextItem == null) return;
        m_txtResult.text = string.Format("선택된 도시는 {0}입니다",m_curTextItem.NameOfItem());
    }
    public void OnClick_Clear()
    {
        m_curTextItem = null;
        foreach (var item in m_listItems)
        {
            item.SetColor(false);
        }
    }
}
