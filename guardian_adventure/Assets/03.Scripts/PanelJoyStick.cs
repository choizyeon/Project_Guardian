using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //터치 등 이벤트 받기

//c#은 다중상속 언어적으로 금지(인터페이스 제외)
public class PanelJoyStick : MonoBehaviour, IPointerDownHandler,
    IDragHandler, IPointerUpHandler
{
    public System.Action<Vector3> EventStickMove;


    //유니티는 기본적으로 직렬화된 객체 또는 데이터만 에디터에 노출시킴
    //유니티는 기본적으로 public으로 선언된 변수를 직렬화함
    [SerializeField] float m_maxDistance = 30;

    Image m_stick;
    Image m_origin;

    bool m_isStickDown = false;
    public bool isStickDown { get{ return m_isStickDown; } }

    private void Start()
    {
        m_stick = transform.Find("Stick").GetComponent<Image>();
        m_origin = transform.Find("Origin").GetComponent<Image>();
    }
    private void Update()
    {
        if (m_isStickDown) //조이스틱 움직이고 있음
        {
            Vector3 stickDir = m_stick.rectTransform.position
                - m_origin.rectTransform.position;

            //EventStickMove에 바인딩된 함수가 하나라도 존재한다면 실행
            if (EventStickMove != null)
            {
                EventStickMove(stickDir.normalized);
            }
        }
    }
    //하위객체중에 터치 Down된 객체가 존재하면 자동으로 호출됨
    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateStick(eventData);
        m_isStickDown = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateStick(eventData);
        m_isStickDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_stick.rectTransform.position = m_origin.rectTransform.position;
        m_isStickDown = false;
    }

    void UpdateStick(PointerEventData eventData)
    {
        Vector3 touchPoint = eventData.position;
        Vector3 toStick = touchPoint - m_origin.rectTransform.position;

        //magnitude : 벡터의 크기를 불러오는 프러퍼티
        float distance = toStick.magnitude;

        Vector3 finalPos;
        if(distance > m_maxDistance)
        {
            finalPos = m_origin.rectTransform.position
                + toStick.normalized * m_maxDistance;
        }
        else
        {
            finalPos = eventData.position;
        }

        m_stick.rectTransform.position = finalPos;
    }
}
