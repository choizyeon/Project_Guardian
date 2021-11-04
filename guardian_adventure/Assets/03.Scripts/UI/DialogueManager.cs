using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    Dictionary<int, string[]> m_dialogData;

    public static DialogueManager instance = null;
    private static DialogueManager _instance;

    public static DialogueManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(DialogueManager)) as DialogueManager;

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

        GenerateData();
    }

    public string GetDialogue(int id, int dialogIdx)
    {
        if (!m_dialogData.ContainsKey(id))
        {
            if (!m_dialogData.ContainsKey(id - id % 10))
                return GetDialogue(id - id % 100, dialogIdx);
            
            else
                return GetDialogue(id - id % 10, dialogIdx);
        }

        if (dialogIdx == m_dialogData[id].Length) return null;
        return m_dialogData[id][dialogIdx];
    }

    void GenerateData()
    {
        m_dialogData = new Dictionary<int, string[]>();

        //대화 data
        m_dialogData.Add(1000, new string[] { "안녕, 가디언!" });
        m_dialogData.Add(2000, new string[] { "신입, 검술 연습은 잘 하고있어?" });
        m_dialogData.Add(3000, new string[] { "숲으로 가는 길, 가지말라는 안내판이 있다. " });
        m_dialogData.Add(10000, new string[] { "" });

        //퀘스트 data
        m_dialogData.Add(1000 + 10, new string[] { "...어떻게 하면 좋지..."});
        m_dialogData.Add(1000 + 11, new string[] { "...아! 가디언! 잘지냈어?",
        "저기, 있잖아.... 사실 곧 언니의 생일이라 \n반짝반짝 이쁜 별을 주고싶은데...",
        "반짝반짝 이쁜 별이 많은 숲속은 \n어른들이 위험하다고 가지 말라고 해서...",
        "혹시 가디언이 대신 모아줄 수 있어? \n가디언은 강하잖아!",
        "다섯개 정도만 모으면 될거 같은데..."});

        m_dialogData.Add(1000 + 20, new string[] { "별 다섯 개만 갖다 줘!" });
        m_dialogData.Add(3000 + 20, new string[] { "그러고보니 공주님이 숲속은 위험하다했지...",
            "뭐가 위험한거지? \n주변에 숲에대해 물어보고 출발해야겠다." });

        m_dialogData.Add(2000 + 21, new string[] { "신입, 숲에 간다고?", 
            "요즘 숲에 몬스터가 출몰한단 소리가 있어서...\n함정이 엄청 많으니까 조심해야해!", 
            "함정이 없는 곳으로 잘 피해서 가라고!" });
        m_dialogData.Add(1000 + 22, new string[] { "별 다섯 개만 갖다 줘!" });

        m_dialogData.Add(1000 + 30, new string[] { "우와아...! 고마워!\n고생했으니까 이거 줄게!", "[체력이 올랐습니다!]"});
    }

    public void ChangeDialogueText(int id, string[] str)
    {
        if (m_dialogData.ContainsKey(id))
            m_dialogData.Remove(id);
        m_dialogData.Add(id, str);
    }
}
