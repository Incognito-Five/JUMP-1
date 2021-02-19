using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region Singleton:Shop
    public static Shop Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    [System.Serializable] public class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool isPurchased = false;
    }

    public List<ShopItem> ShopItemsList;

    [SerializeField] GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;
    Button buyBtn;

    public GameObject NoCoin;

    void Start()
    {
        int len = ShopItemsList.Count;

        for(int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            if(ShopItemsList[i].isPurchased)
            {
                DisableBuyButton();
            }
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
    }

    // Update is called once per frame
    void OnShopItemBtnClicked(int itemIndex)
    {
        if(Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);
            //purchase item
            ShopItemsList[itemIndex].isPurchased = true;

            //disable button
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            DisableBuyButton();

            Game.Instance.UpdateAllCoins();

            Profile.Instance.AddAvatar(ShopItemsList[itemIndex].Image);
        }
        else
        {
            NoCoin.SetActive(true);
            Debug.Log("You don't have enough coins!!");
        }
        
    }

    void DisableBuyButton()
    {
        buyBtn.interactable = false;
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }

    //open and close shop
    public void OpenShop()
    {
        ShopPanel.SetActive(true);
    }
    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }
}