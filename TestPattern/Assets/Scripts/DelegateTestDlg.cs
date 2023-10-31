using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTestDlg : MonoBehaviour
{


    public TextItem[] m_textItems = new TextItem[3];
    public Text m_txtResult = null;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    





    public void Initialize()
    {
        foreach(var item in m_textItems)
        {
            item.Initialize();
            item.ColorSelect(false);
            item.AddListner(OnClick_Select);
        }
    }
    public void OnClick_Select(TextItem kitem, bool kSelect)
    {
        ClearSelections();
        kitem.ColorSelect(true);
        m_txtResult.text = kitem.GetText();
    }
    public void ClearSelections()
    {
        foreach(var item in m_textItems)
        {
            item.ColorSelect(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
