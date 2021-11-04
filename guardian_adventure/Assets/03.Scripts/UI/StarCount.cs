using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCount : MonoBehaviour
{
    [SerializeField] Text m_StarText;
    int m_starCount = 0;
    bool m_isEnd = false;

    public int GetSetStar { get { return m_starCount; } set { m_starCount = value; } }

    // Update is called once per frame
    void Update()
    {
        m_StarText.text = m_starCount.ToString();

        if (m_isEnd == false && GameManager.Instance.gameState == GameManager.GameState.gameOver)
        {
            GameManager.Instance.star += m_starCount;
            m_isEnd = true;
        }
    }

}
