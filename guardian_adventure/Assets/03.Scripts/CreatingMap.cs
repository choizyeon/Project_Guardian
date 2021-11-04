using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingMap : MonoBehaviour
{
    [SerializeField] GameObject[] Grounds = new GameObject[2];
    [SerializeField] GameObject m_Player;
    [SerializeField] float speed = 5f;
    Player m_player;
    public float Speed { get { return speed; } set { speed = value; } }

    private void Start()
    {
        m_player = m_Player.GetComponent<Player>();
    }

    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.playing)
            MoveGround();
    }
    
    void MoveGround()
    {
        MapSpeed();

        Grounds[0].transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        Grounds[1].transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if (Grounds[0].transform.position.x <= -21)
        {
            Grounds[0].transform.position = new Vector3(Grounds[1].transform.position.x + 20f, 0, 0);
        }
        if (Grounds[1].transform.position.x <= -21)
        {
            Grounds[1].transform.position = new Vector3(Grounds[0].transform.position.x + 20f, 0, 0);
        }

    }

    void MapSpeed()
    {
        int playTime = (int)GameObject.Find("MainCanvas").GetComponent<Timer>().time;
        if (playTime > 15 && playTime <= 30) speed = 7f;
        else if (playTime > 30 && playTime <= 45) speed = 9f;
        else if (playTime > 60) speed = 10.5f;

    }
}
