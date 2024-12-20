using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : Colliders
{
    //string tagname;

    //public delegate void CollFunction(Collider other);
    //CollFunction _collFunction;

    //public void SetCollitionFunction(CollFunction _function)
    //{
    //    _collFunction = _function;
    //}


    //private void OnTriggerEnter(Collider other)
    //{
    //    _collFunction(other);
    //}
    public float HitAngle = 180.0f;

    public override void VirtualStart()
    {
        base.VirtualStart();
        colltype = CharEnumTypes.eCollType.SphereColl;
        Mycollider = GetComponent<SphereCollider>();
        targetTag = "Enemy";
    }

    public SphereCollider GetCollider()
    {
        return Mycollider as SphereCollider;
    }

    public override void SetRadious(float radius)
    {
        SphereCollider col = Mycollider as SphereCollider;
        col.radius = radius;

    }



    private void Awake()
    {
        VirtualStart();
    }

    private void Start()
    {
        VirtualStart();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(PlayableCharacter.Instance.curState == PlayableCharacter.States.Attack)
        {
            if (other.transform.gameObject.tag == (targetTag) || other.transform.gameObject.tag == "Box")
            {
                CMoveComponent movecom = PlayableCharacter.Instance.GetMyComponent(CharEnumTypes.eComponentTypes.MoveCom) as CMoveComponent;

                Vector3 front = movecom.com.FpRoot.forward;
                front.y = 0;
                front.Normalize();

                Vector3 hit = other.transform.position;
                hit.y = 0;
                hit.Normalize();

                float hitangle = /*180 - */Mathf.Acos(Vector3.Dot(front, hit)) * 180.0f / 3.14f;

                if (hitangle <= HitAngle)
                {
                    _EnterFunction?.Invoke(other);
                }
            }
        }
        
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (PlayableCharacter.Instance.curState == PlayableCharacter.States.Attack)
        {
            if (other.transform.gameObject.tag == (targetTag) || other.transform.gameObject.tag == "Box")
            {
                CMoveComponent movecom = PlayableCharacter.Instance.GetMyComponent(CharEnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
                Vector3 front = movecom.com.FpRoot.forward;
                front.y = 0;
                front.Normalize();

                Vector3 hit = other.transform.position;
                hit.y = 0;
                hit.Normalize();

                float hitangle = /*180 - */Mathf.Acos(Vector3.Dot(front, hit)) * 180.0f / 3.14f;

                if (hitangle <= HitAngle)
                {
                    _OuterFunction?.Invoke(other);
                }
            }

        }

    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log($"WeaponCol {other.gameObject.name} 탐지중");
        if (PlayableCharacter.Instance.curState == PlayableCharacter.States.Attack)
        {
            if (other.transform.gameObject.tag == (targetTag) || other.transform.gameObject.tag == "Box")
            {
                CMoveComponent movecom = PlayableCharacter.Instance.GetMyComponent(CharEnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
                Vector3 front = movecom.com.FpRoot.forward;
                front.y = 0;
                front.Normalize();

                Vector3 hit = other.transform.position;
                hit.y = 0;
                hit.Normalize();

                float hitangle = /*180 - */Mathf.Acos(Vector3.Dot(front, hit)) * 180.0f / 3.14f;
                Debug.Log($"공격 앵글 {hitangle}");

                if (hitangle <= HitAngle)
                {
                    _StayFunction?.Invoke(other);
                }
            }
        }
        

        //if (other.transform.gameObject.CompareTag(targetTag))
            
    }


    



}
