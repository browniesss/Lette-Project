using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = int.MaxValue)]
public class MonsterInformation : ScriptableObject
{
    [SerializeField]
    private int Number;
    public int P_Number { get { return Number; } set { Number = value; } }
    [SerializeField]
    private string mon_Index; //몬스터 번호
    public string P_mon_Index { get { return mon_Index; } }
    [SerializeField]
    private string mon_nameKor; //몬스터 한국명
    public string P_mon_nameKor { get { return mon_nameKor; } set { mon_nameKor = value; } }
    [SerializeField]

    private string mon_nameEng; //몬스터 영어명
    public string P_mon_nameeng { get { return mon_nameEng; } set { mon_nameEng = value; } }
    [SerializeField]
    

    private int mon_Default; //몬스터 등급
    public int P_mon_Default { get { return mon_Default; } }

    [SerializeField]
    private int mon_Type; //몬스터 타입
    public int P_mon_Type { get { return mon_Type; } }
    [SerializeField]
    private int mon_Position; //몬스터 위치
    public int P_mon_Position { get { return mon_Position; } }

    [SerializeField]
    private int mon_MaxHP; //몬스터 체력
    public int P_mon_MaxHP { get { return mon_MaxHP; } }

    [SerializeField]
    private int mon_Atk; //몬스터 공격력
    public int P_mon_Atk { get { return mon_Atk; } }

    [SerializeField]
    private int mon_Def; //몬스터 방어력
    public int P_mon_Def { get { return mon_Def; } }

    [SerializeField]
    private int mon_Balance; //몬스터 균형게이지
    public int P_mon_Balance { get { return mon_Balance; } }

    [SerializeField]
    private int mon_moveSpeed; //몬스터 스피드
    public int P_mon_moveSpeed { get { return mon_moveSpeed; } }

    [SerializeField]
    private int mon_MaxMp; //몬스터 최대마나
    public int P_mon_MaxMp { get { return mon_MaxMp; } }

    [SerializeField]
    private int mon_regenMP; //몬스터 마나 회복량
    public int P_mon_regenMP { get { return mon_regenMP; } }

    [SerializeField]
    private int dieDelay; //몬스터 사망딜레이
    public int P_dieDelay { get { return dieDelay; } }
    [SerializeField]
    private int drop_Reward; //몬스터 보상
    public int P_drop_Reward{ get { return drop_Reward; } }

    public void Set(int num, string mon_index, string mon_namekor, string mon_nameeng, int mon_default, int mon_type, int mon_position, int mon_hp, int mon_atk, int mon_def, int mon_balance, int mon_movespeed, int mon_maxmp , int mon_regenmP ,int diedelay)
    {
        Number = num;
        mon_Index = mon_index;
        mon_nameKor = mon_namekor;
        mon_nameEng = mon_nameeng;
        mon_Default = mon_default;
        mon_Type = mon_type;
        mon_Position = mon_position;
        mon_MaxHP = mon_hp;
        mon_Atk = mon_atk;
        mon_Def = mon_def;
        mon_Balance = mon_balance;
        mon_moveSpeed = mon_movespeed;

        mon_MaxMp = mon_maxmp;
        mon_regenMP = mon_regenmP;

        dieDelay = diedelay;
        
    }

   
}
