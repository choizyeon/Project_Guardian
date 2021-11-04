using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 방향
    enum PlayerLook
    {
        front,
        back,
        left,
        right,
        climb,
    };
    PlayerLook m_playerLook = PlayerLook.right; // 기본은 오른쪽을 보고있음
    Vector3 m_dirVec;
    GameObject m_playerImage;
    GameObject m_scanObject = null;

    Animator m_playerAni;

    Rigidbody m_rigidbody;

    float m_speed = 7f;
    float h, v;
    float m_prevY;

    [SerializeField] GameObject m_dialogueStartBtn;

    void Start()
    {
        m_playerImage = transform.Find("Knight").gameObject;
        m_playerAni = this.GetComponent<Animator>();
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
        GameObject.Find("PanelJoyStick").GetComponent<PanelJoyStick>().EventStickMove += OnEventStickMove;
    }

    void OnEventStickMove(Vector3 dir)
    {
        Vector3 worldDir = new Vector3();
        worldDir.x = dir.x;
        worldDir.y = 0f;
        worldDir.z = dir.y;

        h = UIManager.Instance.isDialogAction ? 0 : dir.x;
        v = UIManager.Instance.isDialogAction ? 0 : dir.y;

    }

    void Update()
    {
        if (!GameObject.Find("PanelJoyStick").GetComponent<PanelJoyStick>().isStickDown)
        {
          h = UIManager.Instance.isDialogAction ? 0 : Input.GetAxis("Horizontal");
          v = UIManager.Instance.isDialogAction ? 0 : Input.GetAxis("Vertical");
        }

        if ( m_playerLook != PlayerLook.climb)
        {
            Move();
            ChangeImage();
            ChangeAni();
            NPCAction();
        }
        else
        {
            Climbimg();
        }
    }

    private void FixedUpdate()
    {
        ScanObjecct();
    }

    // 플레이어 이동
    void Move()
    {
        m_rigidbody.MovePosition(this.transform.position + new Vector3(h * m_speed, 0, v * m_speed) * Time.deltaTime);

        if (h < 0 && Mathf.Abs(v) < 0.7f) m_playerLook = PlayerLook.left;
        else if (h > 0 && Mathf.Abs(v) < 0.7f) m_playerLook = PlayerLook.right;
        else if (v < 0) m_playerLook = PlayerLook.front;
        else if (v > 0) m_playerLook = PlayerLook.back;
    }

    // 플레이어 상/하/좌/우 이미지 변경
    void ChangeImage()
    {
        switch (m_playerLook)
        {
            case PlayerLook.front:
                m_dirVec = Vector3.back;
                SetImage("Knight_front", 40, 0, 0);
                break;
            case PlayerLook.back:
                m_dirVec = Vector3.forward;
                SetImage("Knight_back", 40, 0, 0);
                break;
            case PlayerLook.left:
                m_dirVec = Vector3.left;
                SetImage("Knight", -40, 180, 0);
                break;
            case PlayerLook.right:
                m_dirVec = Vector3.right;
                SetImage("Knight", 40, 0, 0);
                m_playerAni.SetInteger("look", 1);
                break;
        }
    }

    // 플레이어 상/하/좌/우 이미지 셋팅
    void SetImage(string s, float a, float b, float c)
    {
        m_playerImage.SetActive(false);
        m_playerImage = transform.Find(s).gameObject;
        m_playerImage.SetActive(true);
        m_playerImage.transform.rotation = Quaternion.Euler(a, b, c);
    }

    // 플레이어 애니메이션 변경
    void ChangeAni()
    {
        //idle 애니메이션
        if (h == 0 && v == 0)
        {
            m_playerAni.SetInteger("state", 0);
        }
        //run 애니메이션
        else
        {
            m_playerAni.SetInteger("state", 1);
        }
    }

    //사다리 오르기
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ladder")
        {
            m_playerLook = PlayerLook.climb;
            m_prevY = this.transform.position.y;
        }

    }

    void Climbimg()
    {
        m_rigidbody.useGravity = false;
        m_rigidbody.MovePosition(this.transform.position + new Vector3(0, m_speed, 0) * Time.deltaTime);
        if (transform.position.y >= m_prevY + 1.5f)
        {
            m_rigidbody.useGravity = true;
            m_playerLook = PlayerLook.back;
        }

    }

    //레이캐스트로 NPC 오브젝트 스캔
    void ScanObjecct()
    {
        Debug.DrawRay(m_rigidbody.position, m_dirVec * 1.5f, new Color(1, 0, 0));
        RaycastHit rayHit;

        if (Physics.Raycast(transform.position, m_dirVec, out rayHit, 1.5f))
        {
            if (rayHit.collider.tag == "NPC")
            {
                m_scanObject = rayHit.collider.gameObject;
                m_dialogueStartBtn.SetActive(true);
            }
        }
        else
        {
            m_scanObject = null;
            m_dialogueStartBtn.SetActive(false);
        }
    }

    void NPCAction()
    {
        if(Input.GetKeyDown(KeyCode.Space) && m_scanObject != null)
        {
            UIManager.Instance.DialogueAction(m_scanObject);
        }
    }

    public void DialogueButton()
    {
        if (m_scanObject != null)
        {
            UIManager.Instance.DialogueAction(m_scanObject);
        }
    }
}
