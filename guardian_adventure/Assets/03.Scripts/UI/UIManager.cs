using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Text dialogText;
    public Text NPCName;
    public GameObject dialogPanel;
    public int dialogIdx = 0;
    public bool isDialogAction = true;
    public GameObject scanObject;

    public static UIManager instance = null;
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(UIManager)) as UIManager;

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
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void DialogueAction(GameObject scanObj)
    {
        scanObject = scanObj;
        NPCData npcData = scanObject.GetComponent<NPCData>();
        NPCName.text = npcData.ObjName;

        dialogText.text = "";
        Dialogue(npcData.id);

        dialogPanel.SetActive(isDialogAction);
    }

    void Dialogue(int id)
    {
        int questDialogIdx = QuestManager.Instance.GetQuestDialogIndex(id);
        string dialogData = DialogueManager.Instance.GetDialogue(id + questDialogIdx, dialogIdx);
        
        //대화 끝
        if (dialogData == null)
        {
            isDialogAction = false; 
            dialogIdx = 0;
            QuestManager.Instance.CheckQuest(id);
            return;
        }
        dialogText.text = "";
        dialogText.DOText(dialogData, dialogData.Length * 0.08f);
        //dialogText.text = dialogData;
        isDialogAction = true;
        dialogIdx++;
    }

    public void SetObject()
    {
        GameObject canvas = GameObject.Find("Canvas");
        dialogText = canvas.transform.Find("DialogueBoxImage").Find("DialogueText").GetComponent<Text>();
        NPCName = canvas.transform.Find("DialogueBoxImage").Find("NPCNameText").GetComponent<Text>();
        dialogPanel = canvas.transform.Find("DialogueBoxImage").gameObject;
    }
}
