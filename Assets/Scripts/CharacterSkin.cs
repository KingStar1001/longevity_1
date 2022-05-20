using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CharacterSkin : MonoBehaviour
{
    public GameObject hair1;
    public GameObject hair2;

    public SkinnedMeshRenderer dressObj;
    public Material dress1Mat;
    public Material dress2Mat;
    public Material dress3Mat;

    public SkinnedMeshRenderer skinObj;
    public Material skin1Mat;
    public Material skin2Mat;
    public Material skin3Mat;
    CharacterInfo info;
    void Start(){
        this.InitUI();
    }
    public void InitUI(){
        info = JsonConvert.DeserializeObject<CharacterInfo>(PlayerPrefs.GetString("characterInfo"));

        if(info.hair == 1){
            hair1.SetActive(true);
            hair2.SetActive(false);
        }else if(info.hair == 2){
            hair1.SetActive(false);
            hair2.SetActive(true);
        }

        if(info.dress == 1){
            dressObj.material = dress1Mat;
        }else if(info.dress == 2){
            dressObj.material = dress2Mat;
        }else if(info.dress == 3){
            dressObj.material = dress3Mat;
        }

        if(info.skin == 1){
            skinObj.material = skin1Mat;
        }else if(info.skin == 2){
            skinObj.material = skin2Mat;
        }else if(info.skin == 3){
            skinObj.material = skin3Mat;
        }
    }
}
