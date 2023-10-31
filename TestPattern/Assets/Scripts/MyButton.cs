using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : EventTrigger
{
    public delegate void DelegateFunc();
    public DelegateFunc onSelectItem = null;
    
    private Color m_OriColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        m_OriColor = GetComponent<Image>().color;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (onSelectItem != null)
            onSelectItem();
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        SetColor(m_OriColor);
    }
    public void AddListner(DelegateFunc func)
    {
        onSelectItem = new DelegateFunc(func);
    }
    public void SetColor(Color color)
    {
        GetComponent<Image>().color = color;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
