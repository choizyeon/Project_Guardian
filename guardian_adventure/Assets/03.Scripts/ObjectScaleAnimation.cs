using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectScaleAnimation : MonoBehaviour
{/*
    public static ObjectScaleAnimation instance = null;
    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static ObjectScaleAnimation _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static ObjectScaleAnimation Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ObjectScaleAnimation)) as ObjectScaleAnimation;

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
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator Scale_up(GameObject obj) //UI 나타날때
    {
    
        obj.transform.DOScale(new Vector3(0f, 0f, 0f), 0f);
        //yield return new WaitForSeconds(0.5f); //0.5초 뒤에
        obj.SetActive(true); //활성화 시킴
    
        yield return new WaitForSeconds(0.1f); //0.1초 뒤에
        obj.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        obj.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        obj.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.Linear);
    
        yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator Scale_down(GameObject obj)
    {
        obj.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        obj.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        obj.transform.DOScale(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        obj.SetActive(false);
    }
    */
}
