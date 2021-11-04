using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Poolable m_poolObj;
    public int m_allocateCount;

    public int allocateCount { get { return m_allocateCount; } set { m_allocateCount = value; } }

    Stack<Poolable> m_poolStack = new Stack<Poolable>();

    void Start()
    {
        Allocate();
        m_poolObj = Resources.Load<GameObject>("Trap").GetComponent<Trap>();
    }

    public void Allocate()
    {
        for(int i = 0; i<m_allocateCount; i++)
        {
            Poolable allocateObj = Instantiate(m_poolObj, gameObject.transform);
            allocateObj.Create(this);
            m_poolStack.Push(allocateObj);
        }
    }

    public GameObject Pop()
    {
        Poolable obj = m_poolStack.Pop();
        obj.gameObject.SetActive(this);
        return obj.gameObject;
    }

    public void Push(Poolable obj)
    {
        obj.gameObject.SetActive(false);
        m_poolStack.Push(obj);
    }
}
