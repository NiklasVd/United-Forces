using UnityEngine;
using System.Collections;

public class ThrowableItem : Item
{
    public int throwables, maxThrowables;
    public float maxThrowStrength, throwTime;

    private float throwDeltaTime;

    public bool canThrow
    {
        get
        {
            if (throwDeltaTime != 0 || throwables == 0)
                return false;
            else return true;
        }
    }

    public void OnThrow()
    {
        throwables -= 1;
        throwDeltaTime = throwTime;
    }
    public void OnFillThrowables(int count)
    {
        if (throwables + count > maxThrowables)
            throwables = maxThrowables;
        else
            throwables += count;
    }
    public void Update()
    {

    }
}
