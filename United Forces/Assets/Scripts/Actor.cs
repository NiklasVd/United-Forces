using UnityEngine;
using System.Collections;
using System;

public abstract class Actor : MonoBehaviour
{
    public string permanentId = Guid.NewGuid().ToString(), actorName;

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {

    }
    protected virtual void FixedUpdate()
    {

    }
    protected virtual void OnDestroy()
    {

    }
}
