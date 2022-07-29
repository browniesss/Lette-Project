using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTestScript : MonoBehaviour
{
    GameObject MapPos;
    GameObject PlayerInitPos;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {

       
        MapPos = new GameObject();
        PlayerInitPos = new GameObject();
        MapPos.transform.position = new Vector3(15, 0, 0);
        PlayerInitPos.transform.position = new Vector3(10, 0, 0);

        //생성 -어드레서블X 실행잘됌
        GameMG.Instance.Resource.Instantiate("Terrain", MapPos.transform);
         GameMG.Instance.Resource.Instantiate("PlayerCharacter", PlayerInitPos.transform);

        //생성 - 어드레서블 오류뜸
        // GameMG.Instance.Resource.Instantiate("Terrain", MapPos.transform);

        //코루틴 아닌거
        //GameMG.Instance.Resource.Instantiate("susu", PlayerInitPos.transform);

        //코루틴 생성
        StaticCoroutine.DoCoroutine(GameMG.Instance.Resource.Instantiate_("susu", PlayerInitPos.transform));

        //처음 호출에서 오류 남...(?)
        CharacterCreate.Instance.CreateMonster(EnumScp.MonsterIndex.mon_01_01, MapPos.transform);
        //카메라 오류인거같아서 해봤는데 정상적으로 작동됌.
        // Canvas canvas = gameObject.GetComponent<Canvas>();
        //canvas.renderMode = RenderMode.ScreenSpaceCamera;
        //canvas.worldCamera = Camera.main;
        //Debug.Log(Camera.main.name);

        //HP바 안보이는 오류. ->null 오류 뜨는데 카메라 오류인줄알았는데 위에서 잘 작동되는거로 봐서 그건 또 아닌듯함..

        //두 줄에서 오류
        //ui카메라 캔버스...

        //아마 이 부분에서 못가져오는듯 싶음 (null)
        // canvas = GetComponentInParent<Canvas>(); //부모가 가지고있는 canvas 가져오기, Enemy HpBar canvas임
        // uiCamera = canvas.worldCamera;

        // var screenPos = Camera.main.WorldToScreenPoint(enemyTr.position + offset); //월드좌표(3D)를 스크린좌표(2D)로 변경, offset은 오브젝트 머리 위치


    }

    //1. uiHP바 오류 ->메인 카메라 오류같음, 캐릭터 찾아야댐
    //2. 어드레서블 연결
    //3. Create호출함수 name호출? 찾기 만들기

    // Update is called once per frame
    void Update()
    {
        
    }
}
