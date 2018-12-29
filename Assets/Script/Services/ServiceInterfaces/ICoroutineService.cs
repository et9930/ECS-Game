using System;
using System.Collections;

public interface ICoroutineService
{
    void StartCoroutine(IEnumerator func);
    IEnumerator WaitForSeconds(float second);
    IEnumerator WaitForEndOfFrame();
    IEnumerator WaitUntil(Func<bool> func);
    IEnumerator WaitWhile(Func<bool> func);
}