using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartGate : MonoBehaviour
{
    [SerializeField] GameObject m_GameStartMenu;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            m_GameStartMenu.SetActive(true);
    }
}
