using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ShopItem : MonoBehaviour
{
    public int id;
    public Text coinLabel;
    public Text countLabel;
    public ShopItemInfo info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitItem(){
        Dictionary<int, ShopItemInfo> shopItems = JsonConvert.DeserializeObject<Dictionary<int, ShopItemInfo>>(PlayerPrefs.GetString("shopItems"));
        info = shopItems[id];
        coinLabel.text = info.price.ToString();
        countLabel.text = "x " + info.count.ToString();
    }

    public void OnItemDetail(){
        ShopWindow.instance.itemWindow.gameObject.SetActive(true);
        ShopWindow.instance.itemWindow.id = id;
        ShopWindow.instance.itemWindow.InitialPanel();
    }
}
