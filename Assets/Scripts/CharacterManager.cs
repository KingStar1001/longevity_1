using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class CharacterManager : MonoBehaviour
{
    CharacterInfo info;

    [Header("UI")]
    public Toggle hairToggle1;
    public Toggle hairToggle2;
    public Toggle dressToggle1;
    public Toggle dressToggle2;
    public Toggle dressToggle3;
    public Toggle skinToggle1;
    public Toggle skinToggle2;
    public Toggle skinToggle3;
    [Header("Object")]
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHairToggleChange(){
        if(hairToggle1.isOn){
            hair1.SetActive(true);
            hair2.SetActive(false);
            info.hair = 1;
        }else{
            hair1.SetActive(false);
            hair2.SetActive(true);
            info.hair = 2;
        }
        
        SaveData();
    }

    public void OnDressToggleChange(){
        if(dressToggle1.isOn){
            dressObj.material = dress1Mat;
            info.dress = 1;
        }else if(dressToggle2.isOn){
            dressObj.material = dress2Mat;
            info.dress = 2;
        }else if(dressToggle3.isOn){
            dressObj.material = dress3Mat;
            info.dress = 3;
        }
        
        SaveData();
    }

    public void OnSkinToggleChange(){
        if(skinToggle1.isOn){
            skinObj.material = skin1Mat;
            info.skin = 1;
        }else if(skinToggle2.isOn){
            skinObj.material = skin2Mat;
            info.skin = 2;
        }else if(skinToggle3.isOn){
            skinObj.material = skin3Mat;
            info.skin = 3;
        }

        SaveData();
    }

    public void InitUI(){
        info = JsonConvert.DeserializeObject<CharacterInfo>(PlayerPrefs.GetString("characterInfo"));

        if(info.hair == 1){
            hairToggle1.isOn = true;
            hair1.SetActive(true);
            hair2.SetActive(false);
        }else if(info.hair == 2){
            hairToggle2.isOn = true;
            hair1.SetActive(false);
            hair2.SetActive(true);
        }

        if(info.dress == 1){
            dressToggle1.isOn = true;
            dressObj.material = dress1Mat;
        }else if(info.dress == 2){
            dressToggle2.isOn = true;
            dressObj.material = dress2Mat;
        }else if(info.dress == 3){
            dressToggle3.isOn = true;
            dressObj.material = dress3Mat;
        }

        if(info.skin == 1){
            skinToggle1.isOn = true;
            skinObj.material = skin1Mat;
        }else if(info.skin == 2){
            skinToggle2.isOn = true;
            skinObj.material = skin2Mat;
        }else if(info.skin == 3){
            skinToggle3.isOn = true;
            skinObj.material = skin3Mat;
        }
    }

    public void SaveData(){
        PlayerPrefs.SetString("characterInfo", JsonConvert.SerializeObject(info));
    }
}
