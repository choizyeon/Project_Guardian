using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    protected ObjectPool m_pool;

    public virtual void Create(ObjectPool pool)
    {
        m_pool = pool;
        gameObject.SetActive(false);
    }

    public virtual void Push()
    {
        m_pool.Push(this);
    }
}
