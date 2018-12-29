using System;
using System.Collections;
using UnityEngine;

public class UnityCoroutineService : MonoBehaviour, ICoroutineService
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    void ICoroutineService.StartCoroutine(IEnumerator func)
    {
        StartCoroutine(func);
    }

    public IEnumerator WaitForEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator WaitForSeconds(float second)
    {
        yield return new WaitForSeconds(second);
    }

    public IEnumerator WaitUntil(Func<bool> func)
    {
        yield return new WaitUntil(func);
    }

    public IEnumerator WaitWhile(Func<bool> func)
    {
        yield return new WaitWhile(func);
    }

    

    
}