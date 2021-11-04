using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingStar : MonoBehaviour
{
    Vector3[] m_posIdx = { new Vector3(19.5f, 1.4f, -5.960103f), new Vector3(19.5f, 1.4f, -10.0601f), new Vector3(19.5f, 1.4f, -14.0601f) };
    Coroutine m_coroutine = null;


    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.playing && m_coroutine == null)
            m_coroutine = StartCoroutine(SpawnRepeat());

    }


    private IEnumerator SpawnRepeat()
    {
        int randPos1 = (int)Random.Range(0, 3); //아이템 위치

        //장애물이 스폰되는 시간
        float randTime = Random.Range(7, 10);

        yield return new WaitForSeconds(randTime);
        GameObject ObjPooling = ObjectPoolManager.Instance.ItemManager;
        ObjPooling.GetComponent<ObjectPool>().Pop().transform.position = m_posIdx[randPos1];
        m_coroutine = null;
    }
}
