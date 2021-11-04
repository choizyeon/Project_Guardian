using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Poolable
{
    [SerializeField] float speed = 5f;
    
    void Update()
    {
        speed = GameObject.Find("MapManager").GetComponent<CreatingMap>().Speed;
        if (GameManager.Instance.gameState == GameManager.GameState.playing)
            this.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if (this.transform.position.x <= -2.5f)
            Push();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (other.GetComponent<Player>().state == Player.PlayerState.move)
            {
                other.GetComponent<Player>().state = Player.PlayerState.hit;
                //플레이어 변화
                other.GetComponent<Player>().hp -= 1;
                //ui 변화
                GameObject.Find("Hearts").GetComponent<Heart>().HPdecrease();
            }
        }
    }

}
