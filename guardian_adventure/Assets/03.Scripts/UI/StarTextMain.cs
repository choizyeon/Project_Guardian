using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarTextMain : MonoBehaviour
{
    [SerializeField] Text m_starText;

    private void Start()
    {
        SetStar();   
    }

    public void SetStar()
    {
        m_starText.text = GameManager.Instance.star.ToString();
    }
}
