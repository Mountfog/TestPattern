using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{
    public Image m_image = null;
    public Text m_text = null;
    public Button m_button = null;
    public delegate void DelegateFunc(TextItem kitem, bool bSelect); //��������Ʈ �����
    public DelegateFunc m_onClickFunc = null; //��������Ʈ �Էº�, �Լ����İ� �¾ƾ� ��

    private void Start()
    {
        m_button.onClick.AddListener(OnClickFunc);
    }
    public void Initialize(string city)
    {
        m_text.text = city;
    }

    public void AddListner(DelegateFunc onClickFunc)
    {
        m_onClickFunc = new DelegateFunc(onClickFunc);
    }
    public void OnClickFunc()
    {
        if(m_onClickFunc != null)
        {
            m_onClickFunc(this, true);
        }
    }
    public void SetColor(bool b)
    {
        m_image.color = b ? Color.green : Color.white;
    }

    public string NameOfItem()
    {
        return m_text.text;
    }
}
