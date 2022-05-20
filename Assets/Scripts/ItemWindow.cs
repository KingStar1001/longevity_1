using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ItemWindow : MonoBehaviour
{
    public int id;
    public Image icon;
    public Text nameLabel;
    public Text priceLabel;
    public Text countLabel;

    public List<Sprite> icons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialPanel(){
        Dictionary<int, ShopItemInfo> shopItems = JsonConvert.DeserializeObject<Dictionary<int, ShopItemInfo>>(PlayerPrefs.GetString("shopItems"));
        ShopItemInfo info = shopItems[id];
        nameLabel.text = info.name;
        priceLabel.text = info.price.ToString();
        countLabel.text = "Count: x " + info.count.ToString();
        icon.sprite = icons[info.id - 1];
    }

    public void OnBuy(){
        Dictionary<int, ShopItemInfo> shopItems = JsonConvert.DeserializeObject<Dictionary<int, ShopItemInfo>>(PlayerPrefs.GetString("shopItems"));
        int coin = PlayerPrefs.GetInt("coins");
        ShopItemInfo info = shopItems[id];
        if(coin >= info.price){
            coin -= info.price;
            PlayerPrefs.SetInt("coins", coin);
            info.count ++;
            shopItems[id] = info;
            PlayerPrefs.SetString("shopItems", JsonConvert.SerializeObject(shopItems));
            InitialPanel();
            ShopWindow.instance.RefreshPanel();
        }
    }
    public void OnClose(){
        gameObject.SetActive(false);
    }
}
