using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrab : BaseInteractive
{
    public Collider TrabCollider = null;
    public bool IsInteractive = false;
    public GameObject Spear = null;
    public GameObject Floor = null;
    public IEnumerator coroutine = null;
    public float MoveSpeed = 0f;


    public override void Init()
    {
        InteractiveObjManager.Instance.SetInteractiveObj(EnumScp.InteractiveIndex.Trab, this);
        TrabCollider = GetComponentInChildren<BoxCollider>();
        Debug.Log(TrabCollider.name);
        coroutine = StartTrab();
        MoveSpeed = 10f;
    }

    public IEnumerator StartTrab()
    {
        IsInteractive = true;
        Vector3 temppos = Spear.transform.position;
        Vector3 dir = (Floor.transform.position - Spear.transform.position).normalized;
        while (true)
        {
            if(Spear.transform.position.y >= Floor.transform.position.y)
            {
                break;
            }
            //temppos.y = MoveSpeed * Time.deltaTime;
            Spear.transform.position += dir * MoveSpeed * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("부안아미ㅗㅜ지ㅗ리ㅗ지롬지옴지ㅏㅇ닝");
        IsInteractive = false;
        yield return null;
    }

    public override void Oninteractive()
    {
        StartCoroutine(coroutine);
    }


    public void OnTriggerEnter(Collider other)
    {
        Oninteractive();
    }

    public override void Awake()
    {
        base.Awake();
    }

    
    void Start()
    {
        
    }

    
    void Update()
    {

    }
}
