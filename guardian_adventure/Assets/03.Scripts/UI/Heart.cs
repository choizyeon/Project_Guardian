using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    //delegate void UpdateHPUI();
    //UpdateHPUI del;

    int m_fullHP;
    int m_nowHP;
    [SerializeField] GameObject[] m_emptyHearts;
    [SerializeField] GameObject[] m_hpHearts;

    void Awake()
    {
        m_fullHP = GameManager.Instance.fullHP;
        m_nowHP = m_fullHP;
        m_emptyHearts = new GameObject[m_fullHP];
        m_hpHearts = new GameObject[m_fullHP];
        
        for (int i = 0; i<m_fullHP; i++)
        {
            string s = "Heart" + (i+1).ToString();
            //비활성화 돼있는 오브젝트들은 부모부터 접근해야함
            m_emptyHearts[i] = GameObject.Find("Hearts").transform.Find(s).gameObject;
            m_emptyHearts[i].SetActive(true);
            m_hpHearts[i] = GameObject.Find(s).transform.Find("hpHeart").gameObject;
        }
    }

    void Update()
    {
        
    }

    public void HPdecrease()
    {
        m_nowHP--;
        m_hpHearts[m_nowHP].SetActive(false);
    }
}
