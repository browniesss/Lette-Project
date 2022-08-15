using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    [SerializeField]
    private Battle_Character parent_BC;

    void Start()
    {
        parent_BC = GetComponentInParent<Battle_Character>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (parent_BC.isAttack_Effect)
        //{
        //    parent_BC.Attack_Effect(collision.gameObject);
        //    parent_BC.isAttack_Effect = false;
        //}

        // 맞은 대상의 damaged 함수를 호출해서 데미지를 입혀줌.
        //switch (parent_BC.attack_Type) // 공격 타입에 맞게 데미지를 입혀줌.
        //{
        //    case Enemy_Enum.Enemy_Attack_Type.Normal_Attack:
        //        collision.gameObject.GetComponent<PlayableCharacter>().BeAttacked(parent_BC.mon_Info.P_mon_Atk, collision.contacts[0].point);
        //        break;
        //    case Enemy_Enum.Enemy_Attack_Type.Skill_Attack:
        //        // 캐릭터의 damaged 함수호출
        //        collision.gameObject.GetComponent<PlayableCharacter>().BeAttacked(parent_BC.now_Skill_Info.P_skill_dmg, collision.contacts[0].point);
        //        break;
        //}
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Vector3 pos = new Vector3();
            pos.z += 1f;

            switch (parent_BC.attack_Type) // 공격 타입에 맞게 데미지를 입혀줌.
            {
                case Enemy_Enum.Enemy_Attack_Type.Normal_Attack:
                    collider.gameObject.GetComponent<PlayableCharacter>().BeAttacked(parent_BC.mon_Info.P_mon_Atk, pos);
                    break;
                case Enemy_Enum.Enemy_Attack_Type.Skill_Attack:
                    // 캐릭터의 damaged 함수호출
                    collider.gameObject.GetComponent<PlayableCharacter>().BeAttacked(parent_BC.now_Skill_Info.P_skill_dmg, pos);
                    break;
            }
        }
    }

    void Update()
    {

    }
}
