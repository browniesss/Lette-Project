using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy_Enum;

public class State_Attack : State
{
    [SerializeField]
    private Enemy_Attack_Logic judge_logic; // 리턴받는 공격방식

    public override bool Judge(out State _State, Battle_Character b_c)
    {
        if (b_c.isAttack_Run)
        {
            if (b_c.isStop)
            {
                if (b_c.attack_Info[b_c.ani_Index].off_Mesh_Pos[0])
                    b_c.attack_Info[b_c.ani_Index].off_Mesh_Pos[0].position = b_c.begin_Pos;
                b_c.isAttack_Run = false;
                b_c.real_AI.pre_State = this;
                b_c.attack_Collider.SetActive(false);
                _State = Trans_List[0];
                return false;
            }

            judge_logic = Enemy_Attack_Logic.Skill_Wait;
            _State = this;
            return true;
        }

        if (b_c.isDelay)
        {
            judge_logic = Enemy_Attack_Logic.Skill_Wait;
            _State = this;
            return true;
        }

        // 사거리가 있는 스킬
        if ((Vector3.Distance(b_c.transform.position,
            b_c.cur_Target.transform.position) <= b_c.now_Skill_Info.P_skill_Range)
            && b_c.mon_Info.P_mon_haveMP >= b_c.now_Skill_Info.P_skill_MP)
        {
            judge_logic = Enemy_Attack_Logic.Skill_Using;
            _State = this;
            return true;
        }

        // 제자리에서 사용가능한 스킬 ( ex . 소환 )
        if (b_c.now_Skill_Info.P_skill_Range == 0
            && b_c.mon_Info.P_mon_haveMP >= b_c.now_Skill_Info.P_skill_MP)
        {
            judge_logic = Enemy_Attack_Logic.Skill_Using;
            _State = this;
            return true;
        }

        // 근접 공격 사거리 체크
        if ((Vector3.Distance(b_c.transform.position,
                b_c.cur_Target.transform.position) <= b_c.mon_Info.P_mon_ShortRange) && !b_c.isAttack_Run) 
        {
            judge_logic = Enemy_Attack_Logic.Melee_Attack;
            _State = this;
            return true;
        }

        if (b_c.attack_Logic[(int)Enemy_Attack_Logic.Long_Attack] == true && (Vector3.Distance(b_c.transform.position,
            b_c.cur_Target.transform.position) <= b_c.mon_Info.P_mon_LongRange)) // 원거리 공격방식이 존재
        {
            judge_logic = Enemy_Attack_Logic.Long_Attack;
            _State = this;
            return true;
        }

        b_c.real_AI.pre_State = this;
        _State = Trans_List[0];
        return false;
    }

    public override void Run(Battle_Character b_c)
    {
        switch (judge_logic)
        {
            case Enemy_Attack_Logic.Skill_Wait:
                // 기다리기
                break;
            case Enemy_Attack_Logic.Melee_Attack:
                // 근접 공격이라면 배틀캐릭터 스크립트 내 공격 판정범위 활성화
                b_c.attack_Type = Enemy_Attack_Type.Normal_Attack;
                b_c.checkTime = 0f;
                b_c.isStop = false;
                b_c.gameObject.transform.LookAt(b_c.cur_Target.transform);
                b_c.attack_Collider.SetActive(true);
                Debug.Log("밀리");
                b_c.isAttack_Run = true;
                b_c.animator.Play("Melee Attack");
                break;
            case Enemy_Attack_Logic.Long_Attack:
                // 원거리라면 원거리 발사체 발사
                b_c.attack_Type = Enemy_Attack_Type.Normal_Attack;
                break;
            case Enemy_Attack_Logic.Skill_Using:
                // 이번에 사용할 순서의 스킬을 사용.
                b_c.attack_Type = Enemy_Attack_Type.Skill_Attack;
                b_c.skill_handler.Skill_Run(b_c, b_c.now_Skill_Info);
                b_c.Skill_Rand();
                break;
        }
    }


}
