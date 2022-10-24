using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Canvas_Enum;
public class UIInfo
{
    public GameObject obj;
    public int index;
    public string path;
    public bool active = false;
    public bool Instance = false;
}
public class UIManager : Singleton<UIManager>
{

    public List<UIInfo> info = new List<UIInfo>();
    public List<GameObject> canvas;


    //public enum CANVAS_NUM
    //{
    //    player_cavas = 0,
    //    enemy_canvas,
    //    start_canvas
    //}
      
    public List<GameObject> Findobj_List(string path)
    {
        List<GameObject> test = new List<GameObject>();
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].path == path && info[i].active)
            {
                test.Add( info[i].obj);
            }
        }
        
        return test;
    }
    public GameObject Findobj(string path)
    {
    
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].path == path && info[i].active)
            {
                return info[i].obj;
            }
        }

        return null;
    }
    public GameObject Findobj(GameObject obj)
    {
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].obj == obj && info[i].active)
            {
                Debug.Log("삭제할게요");
                return info[i].obj;
            }
        }
        return null;
    }
    public bool Findobjbool(string path)   //있으면 true 없으면 false 를 리턴 
    {

        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].path == path )
            {
                return true;
            }
        }

        return false;
    }


    public GameObject Prefabsload(string name, CANVAS_NUM x , Transform a = null)
    {
        bool same = false;
        for (int i = 0; i < info.Count; i++)
        {
         
            if (info[i].path == name && info[i].path != "Hpbar")
            {
                same = true;
            }
        }
        if (same)
        {
            Debug.Log("이미있습니다");
        }
        else
        {
            UIInfo tmp = new UIInfo();
            GameObject obj = AddressablesLoadManager.Instance.FindLoadAsset<GameObject>(name);
            //  AddressablesLoadManager.Instance.Load_Name<GameObject>(name);
            Debug.Log(obj);
            tmp.obj = Instantiate(obj, canvas[(int)x].transform);
            tmp.obj.transform.SetParent(canvas[(int)x].transform);
            tmp.path = name;
            tmp.obj.name = name;
            tmp.active = true;
            info.Add(tmp);
            info[info.Count - 1].index = info.Count - 1;
            return info[info.Count-1].obj;
        }
            return null;
    }
    // (예 아니오 팝업 ) 쇼메세지 .
    // 쇼메세지에서 인수를 받아서 콜백을한다 . 
    // 마우스커서 컨트롤 
    public void Show(string path)
    {
        bool check = false;
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].path == path)
            {
                Debug.Log(info[i].path);
                info[i].obj.SetActive(true);
                info[i].active = true;

                check = true;
            }
        }

        if (!check)
            Debug.Log("실패");
    }
    public void Hide(string path)
    {
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].path == path)
            {
                Debug.Log(info[i].path);
                info[i].obj.SetActive(false);
                info[i].active = false;
            }
        }
    }
    public void Remove(string path)
    {
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].path == path && info[i].active == true)
            {
                Debug.Log(info.Count);
                Destroy(info[i].obj);
                info.Remove(info[i]);
                i = 0;
                continue;
            }
        }
    }
    public void Remove(GameObject obj)
    {
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].obj == obj && info[i].active == true)
            {
                Debug.Log(info.Count);
                Destroy(info[i].obj);
                info.Remove(info[i]);
                i = 0;
                continue;
            }
        }
    }

    public void RemoveAll( )
    {
        for (int i = 0; i < info.Count; i++)
        {
                    Destroy(info[i].obj);
                    info.Remove(info[i]);
                    i = 0;
            Debug.Log(info[i].obj.name);
            continue;
        }
    }
    public void Canvasoff(CANVAS_NUM num)
    {
        canvas[(int)num].SetActive(false);
    }
    public void Canvason(CANVAS_NUM num)
    {
        canvas[(int)num].SetActive(true);
    }

    public GameObject Canvasreturn(CANVAS_NUM num)
    {
        return canvas[(int)num];
    }
    // Start is called before the first frame update
  
    private void Awake()
    {
        StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("IngameOption"));
        StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("MainOption"));
        StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("StartUI"));
        StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("OptionSetting"));
        StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("Boss_HP"));
        StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("FriendPanel"));
        StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("Hpbar"));
        StartCoroutine(AddressablesLoadManager.Instance.AsyncLoad_single<GameObject>("PlayerUIPanel"));
        

    }

    // Update is called once per frame

}
