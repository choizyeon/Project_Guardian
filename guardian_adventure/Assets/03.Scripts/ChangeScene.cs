using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeMainScene()
    {
        LoadingSceneManager.LoadScene("MainScene");
        GameManager.Instance.gameState = GameManager.GameState.menu;
    }
    public void ChangeGameScene()
    {
        LoadingSceneManager.LoadScene("GameScene");
    }
    public void CancelButton()
    {
        gameObject.SetActive(false);
    }
}
