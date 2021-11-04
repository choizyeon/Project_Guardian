using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingObstacle : MonoBehaviour
{
    Vector3[] m_posIdx = { new Vector3(19.5f, 1.0243f, -5.960103f), new Vector3(19.5f, 1.0243f, -10.0601f), new Vector3(19.5f, 1.0243f, -14.0601f) };
    Coroutine m_coroutine = null;


    void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.playing && m_coroutine == null)
            m_coroutine = StartCoroutine(SpawnRepeat());

    }

    
    private IEnumerator SpawnRepeat()
    {
        int randPos1 = (int)Random.Range(0, 3); //첫번째 장애물 위치
        int randPos2 = (int)Random.Range(0, 3); //두번째 장애물 위치

        //두번째 장애물의 위치는 첫번째랑 다르게
        while (randPos1 == randPos2) {
            randPos2 = (int)Random.Range(0, 3);
        }

        //장애물이 스폰되는 시간
        float randTime = Random.Range(1, 2);
        //두번째 장애물 랜덤확률
        int randSpawn = (int)Random.Range(0, 4);

        //일정 시간 지나면 스폰 시간을 줄여주고, 장애물 두개 나올 확률 늘어남
        if (GameObject.Find("MapManager").GetComponent<CreatingMap>().Speed >= 9)
        {
            randTime = Random.Range(0.3f, 1.5f);
            randSpawn = (int)Random.Range(0, 2);
        }


        yield return new WaitForSeconds(randTime);
        GameObject ObjPooling = ObjectPoolManager.Instance.obstacleManager;
        ObjPooling.GetComponent<ObjectPool>().Pop().transform.position = m_posIdx[randPos1];
        if(randSpawn == 1) ObjPooling.GetComponent<ObjectPool>().Pop().transform.position = m_posIdx[randPos2];
        m_coroutine = null;
    }
}
