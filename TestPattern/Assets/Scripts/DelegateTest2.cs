using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTest2 : MonoBehaviour
{
    public Text m_txtResult = null;
    public MyButton m_button = null;
    public Button m_btnClear = null;
    // Start is called before the first frame update
    void Start()
    {
        m_button.AddListner(OnClick_Button);
        m_btnClear.onClick.AddListener(OnClick_Clear);
    }
    void OnClick_Button()
    {
        m_button.SetColor(Color.green);
        m_txtResult.text = "버튼을 클릭했어요";
    }
    void OnClick_Clear()
    {
        m_txtResult.text = string.Empty;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
