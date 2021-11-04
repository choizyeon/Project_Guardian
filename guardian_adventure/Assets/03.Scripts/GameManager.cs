using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        start,
        playing,
        pause,
        gameOver,
        menu,
    };

    public GameState gameState;
    public int fullHP = 2;
    public int bestScore = 0;
    public int star = 0;

    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static GameManager _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스 할당
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(Instance);
        }
        // 인스턴스가 존재하면 새로 생기는 인스턴스를 삭제
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 씬 전환돼도 인스턴트 삭제안함
        DontDestroyOnLoad(gameObject);
    }

}
