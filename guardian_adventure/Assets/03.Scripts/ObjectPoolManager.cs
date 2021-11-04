using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager _instance; //싱글톤 객체
    public GameObject obstacleManager;
    public GameObject ItemManager;
    
    public static ObjectPoolManager Instance //외부에서 접근
    {
        get
        {
            // 인스턴스 할당
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ObjectPoolManager)) as ObjectPoolManager;
                
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
            //DontDestroyOnLoad(Instance);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

       // _instance = this;
        //DontDestroyOnLoad(gameObject); //이게 없으면 해당 씬에서만 사용된다.

        obstacleManager = GameObject.Find("ObstacleManager");
        ItemManager = GameObject.Find("ItemManager");
    }

}
