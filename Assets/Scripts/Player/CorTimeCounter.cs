using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*StartCoroutine() 으로 해당 클래스의 함수를 실행 시켜주면 지정한 시간이 지나면 같이 설정해준 invoker를 실행 시켜준다.
  ex) StartCoroutine(CorTimeCounter객체.Cor_TimeCounter<GameObject>(1.5f,함수,인자))
      StartCoroutine(CorTimeCounter객체.Cor_TimeCounter(1.5f,함수))*/
public class CorTimeCounter
{
    public delegate void Invoker();
    public delegate void SInvoker(string s);
    public delegate void ObjInvoker(Object o);

    public delegate void TInvoker<T>(T val);
    public delegate void TInvoker<T1, T2>(T1 val1, T2 val2);
    public delegate void TInvoker<T1, T2, T3>(T1 val1, T2 val2, T3 val3);
    public IEnumerator Cor_TimeCounter(float time, Invoker invoker)
    {
        float starttime = Time.time;

        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                invoker.Invoke();
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public IEnumerator Cor_TimeCounter(float time, SInvoker invoker,string str ="")
    {
        float starttime = Time.time;

        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                invoker.Invoke(str);
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public IEnumerator Cor_TimeCounter(float time, ObjInvoker invoker, Object o)
    {
        float starttime = Time.time;
        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                invoker.Invoke(o);
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    
    public IEnumerator Cor_TimeCounter<T>(float time, TInvoker<T> invoker, T val)
    {
        float starttime = Time.time;
        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                invoker.Invoke(val);
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public IEnumerator Cor_TimeCounter<T1, T2>(float time, TInvoker<T1, T2> invoker, T1 val1, T2 val2)
    {
        float starttime = Time.time;
        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                invoker.Invoke(val1, val2);
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public IEnumerator Cor_TimeCounter<T1, T2, T3>(float time, TInvoker<T1, T2, T3> invoker, T1 val1, T2 val2, T3 val3)
    {
        float starttime = Time.time;
        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                invoker.Invoke(val1, val2, val3);
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

}
