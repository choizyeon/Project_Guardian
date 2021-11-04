using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text m_timerText;
    float m_timer;
    public float time { get { return m_timer; } set { m_timer = value; } }

    void Start()
    {
        m_timer = 0;
    }

    void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.playing)
        {
            m_timer += Time.deltaTime;

            string m, s;

            if ((int)m_timer< 10) m = "0" + ((int)m_timer).ToString();
            else m = ((int)m_timer).ToString();

            if ((int)(m_timer*100 % 100) < 10) s = "0" + ((int)(m_timer*100 % 100)).ToString();
            else s = ((int)(m_timer*100 % 100)).ToString();

            m_timerText.text = m + " : " + s;
        }
    }

}
