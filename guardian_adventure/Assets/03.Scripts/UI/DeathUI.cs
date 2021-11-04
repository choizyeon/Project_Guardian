using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    [SerializeField] GameObject m_DeathUI;
    bool isActive = false;
    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.gameOver && !isActive)
        {
            isActive = true;
            m_DeathUI.SetActive(true);
        }
    }
}
