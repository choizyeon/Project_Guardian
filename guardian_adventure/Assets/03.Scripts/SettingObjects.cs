using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingObjects : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.SetObject();
        QuestManager.Instance.SetObject();
    }
}
