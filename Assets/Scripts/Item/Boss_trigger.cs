using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool boosclear = false;

    private void Update()
    {
        if (CharacterCreate.Instance.obj_boss.GetComponent<Battle_Character>().cur_HP <= 0)
        {
            boosclear = true;
            this.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            SoundManager.Instance.bgmSource.GetComponent<AudioSource>().Stop();
        }
        else
            return;
    }
    private void OnTriggerExit(Collider other)
    {
     
        if (!boosclear)
        {
            if (other.gameObject.tag == "Player")
            {
                if (other.gameObject.transform.position.z < this.gameObject.transform.position.z)
                {
                    this.gameObject.GetComponent<MeshCollider>().isTrigger = false;
                    UIManager.Instance.Show("Boss_HP");
                    CharacterCreate.Instance.obj_boss.GetComponent<Battle_Character>().Battle_Start();
                    SoundManager.Instance.bgmSource.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.Bgm[1]);
                    SoundManager.Instance.bgmSource.GetComponent<AudioSource>().loop = true;
                    // Cinema_Cam.Instance.CamStart();
                }
            }
        }
    }
}
