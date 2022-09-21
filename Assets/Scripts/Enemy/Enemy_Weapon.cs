using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    [SerializeField]
    private Battle_Character parent_character;

    public Enemy_Enum.Enemy_Attack_Logic my_Logic;

    void Start()
    {
        parent_character = GetComponentInParent<Battle_Character>();
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("플레이어 맞음");
            Vector3 pos = new Vector3();
            pos.z += 1f;

            switch (parent_character.attack_Type) // 공격 타입에 맞게 데미지를 입혀줌.
            {
                case Enemy_Enum.Enemy_Attack_Type.Normal_Attack:
                    collider.gameObject.GetComponent<PlayableCharacter>().BeAttacked(parent_character.mon_Info.P_mon_Atk, pos);
                    break;
                case Enemy_Enum.Enemy_Attack_Type.Skill_Attack:
                    // 캐릭터의 damaged 함수호출
                    collider.gameObject.GetComponent<PlayableCharacter>().BeAttacked(parent_character.now_Skill_Info.P_skill_dmg, pos);
                    break;
            }

            if (my_Logic == Enemy_Enum.Enemy_Attack_Logic.Long_Attack)
            {
                if (parent_character.real_AI.now_State.GetComponent<State_Attack>() != null)
                {
                    State_Attack attack = parent_character.real_AI.now_State.GetComponent<State_Attack>();

                    attack.Attack_Result = true;
                    attack.Result_return_Object = this.gameObject;
                }
            }
        }
    }

    void Update()
    {

    }
}
