using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    #region Singleton:Profile
    public static Profile Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    public class Avatar
    {
        public Sprite Image;
    }

    public List<Avatar> AvatarsList;

    GameObject g;
    int newSelectedIndex, previousSelectedIndex;

    [SerializeField] GameObject AvatarTemplate;
    [SerializeField] Transform AvatarsScrollView;
    [SerializeField] Image CurrentAvatar;

    void Start()
    {
        GetAvailableAvatars();
        newSelectedIndex = 0;
    }

    // Update is called once per frame
    void GetAvailableAvatars()
    {
        for (int i = 0; i < Shop.Instance.ShopItemsList.Count; i++)
        {
            if(Shop.Instance.ShopItemsList[i].isPurchased)
            {
                AddAvatar(Shop.Instance.ShopItemsList[i].Image);
            }
        }

        SelectAvatar(newSelectedIndex);
    }

    public void AddAvatar(Sprite img)
    {
        if(AvatarsList == null)
        {
            AvatarsList = new List<Avatar>();
        }
        Avatar av = new Avatar(){Image = img};
        AvatarsList.Add(av);

        g = Instantiate(AvatarTemplate, AvatarsScrollView);
        g.transform.GetChild(0).GetComponent<Image>().sprite = av.Image;

        g.transform.GetComponent<Button>().AddEventListener(AvatarsList.Count - 1, OnAvatarClick);
    }

    void OnAvatarClick(int AvatarIndex)
    {
        SelectAvatar(AvatarIndex);
    }

    void SelectAvatar(int AvatarIndex)
    {
        newSelectedIndex = AvatarIndex;
        CurrentAvatar.sprite = AvatarsList[newSelectedIndex].Image;
    }
}
