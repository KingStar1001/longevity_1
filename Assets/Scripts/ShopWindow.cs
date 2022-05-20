using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    public static ShopWindow instance;
    public List<ShopItem> shopItems;
    public Text coinLabel; 

    public ItemWindow itemWindow;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshPanel(){
        foreach(ShopItem item in shopItems){
            item.InitItem();
        }

        coinLabel.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
