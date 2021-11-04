using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 m_offset;
    [SerializeField] GameObject player;
    private void Start()
    {
        m_offset = this.transform.position  - player.transform.position;   
    }

    void LateUpdate()
    {
        this.transform.position = player.transform.position + m_offset;
    }
}
