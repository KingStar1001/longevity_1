using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;


[Serializable]
public class CharacterInfo{
    public int hair;
    public int dress;
    public int skin; 
}

[Serializable]
public class ShopItemInfo{
    public int id;
    public int price;
    public int count;
    public string name;
}
public class MainManager : MonoBehaviour
{
    [Header("Widows")]
    public GameObject loadingWindow;
    public GameObject mainWindow;
    public CharacterManager characterSettingWindow;
    public UnityEngine.UI.Text loadingProgress;

    public ShopWindow shopWindow;
    // Start is called before the first frame update
    void Awake(){
        if(!PlayerPrefs.HasKey("characterInfo")){
            CharacterInfo info = new CharacterInfo();
            info.hair = 1;
            info.dress = 1;
            info.skin = 2;
            PlayerPrefs.SetString("characterInfo", JsonConvert.SerializeObject(info));
        }

        if(!PlayerPrefs.HasKey("shopItems")){
            Dictionary<int, ShopItemInfo> shopItems = new Dictionary<int, ShopItemInfo>();
            ShopItemInfo item = new ShopItemInfo();
            item.id = 1;
            item.price = 100;
            item.count = 0;
            item.name = "House";
            shopItems.Add(item.id, item);

            item = new ShopItemInfo();
            item.id = 2;
            item.price = 200;
            item.count = 0;
            item.name = "Life";
            shopItems.Add(item.id, item);

            item = new ShopItemInfo();
            item.id = 3;
            item.price = 300;
            item.count = 0;
            item.name = "GPS";
            shopItems.Add(item.id, item);

            PlayerPrefs.SetString("shopItems", JsonConvert.SerializeObject(shopItems));
        }

        if(!PlayerPrefs.HasKey("coins")){
            PlayerPrefs.SetInt("coins", 10000);
        }
    }
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCharacterSetting(){
        loadingWindow.SetActive(false);
        mainWindow.SetActive(false);
        shopWindow.gameObject.SetActive(false);
        characterSettingWindow.gameObject.SetActive(true);
        characterSettingWindow.InitUI();
    }

    public void OnShopWindow(){
        loadingWindow.SetActive(false);
        mainWindow.SetActive(false);
        shopWindow.gameObject.SetActive(true);
        characterSettingWindow.gameObject.SetActive(false);
        shopWindow.RefreshPanel();
    }

    public void GotoMain(){
        loadingWindow.SetActive(false);
        mainWindow.SetActive(true);
        shopWindow.gameObject.SetActive(false);
        characterSettingWindow.gameObject.SetActive(false);
    }

    public void OnPlay(){
        loadingWindow.SetActive(true);
        mainWindow.SetActive(false);
        shopWindow.gameObject.SetActive(false);
        characterSettingWindow.gameObject.SetActive(false);

    }

    public void OnQuit(){
        Application.Quit();
    }
    public void OnPlayGame(){
        StartCoroutine("LoadSceneAsync");
    }
    IEnumerator LoadSceneAsync()
    {
        this.loadingWindow.SetActive(true);
        AsyncOperation load = SceneManager.LoadSceneAsync("Game");
        while(!load.isDone){
            this.loadingProgress.text = load.progress + "%";
            yield return new WaitForSeconds(0.1f);
        }
    }
}
