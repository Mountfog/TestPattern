using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{
    public delegate void DelegateFunc(TextItem kitem, bool select);
    public DelegateFunc onDelegateFunc = null;
    public Text m_text = null;
    public Image m_image = null;
    public Button m_btnSelect = null;

    public void Initialize()
    {
        m_btnSelect.onClick.AddListener(()=>OnClick_Select());
    }
    public string GetText()
    {
        return m_text.text;
    }
    public void AddListner(DelegateFunc onFunc)
    {
        onDelegateFunc = new DelegateFunc(onFunc);
    }
    public void OnClick_Select()
    {
        if (onDelegateFunc != null) 
        {
            onDelegateFunc(this, true);
        }
    }
    public void ColorSelect(bool kSelect)
    {
        if(kSelect)
        {
            m_image.color = Color.green;
        }
        else
        {
            m_image.color = Color.white;  
        }
    }
}
