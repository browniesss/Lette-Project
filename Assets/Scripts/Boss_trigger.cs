using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool boosclear = false;
  
    private void OnTriggerExit(Collider other)
    {
        if(boosclear)
        {
            this.gameObject.GetComponent<MeshCollider>().isTrigger = true;
        }
        if (!boosclear)
        {
            if (other.gameObject.tag == "Player")
            {
                if (other.gameObject.transform.position.z < this.gameObject.transform.position.z)
                {
                    this.gameObject.GetComponent<MeshCollider>().isTrigger = false;
                    UIManager.Instance.Show("Boss_HP");
                    CharacterCreate.Instance.obj_boss.GetComponent<Battle_Character>().Battle_Start();
                }
            }
        }
    }
}
