using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameStartText : MonoBehaviour
{
    public GameObject m_start;
    public GameObject m_ready;
    
    void OnEnable()
    {
       // m_ready = GameObject.Find("UI").transform.Find("readyText").gameObject;
       // m_start = GameObject.Find("UI").transform.Find("startText").gameObject;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {/*
        StartCoroutine(ObjectScaleAnimation.Instance.Scale_up(m_ready));
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(ObjectScaleAnimation.Instance.Scale_down(m_ready));

        yield return new WaitForSeconds(0.8f);

        StartCoroutine(ObjectScaleAnimation.Instance.Scale_up(m_start));
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(ObjectScaleAnimation.Instance.Scale_down(m_start));

        yield return new WaitForSeconds(0.6f);
        GameManager.Instance.gameState = GameManager.GameState.playing;*/

        m_ready.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        m_ready.SetActive(false);

        yield return new WaitForSeconds(0.8f);

        m_start.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        m_start.SetActive(false);

        yield return new WaitForSeconds(0.6f);
        GameManager.Instance.gameState = GameManager.GameState.playing;
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
}
