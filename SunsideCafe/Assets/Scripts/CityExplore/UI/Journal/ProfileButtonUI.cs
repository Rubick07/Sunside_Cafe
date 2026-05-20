using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileButtonUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image buttonImage;
    [SerializeField] private GameObject highlight;
    [SerializeField] private TextMeshProUGUI profileNameText;

    private ProfileSO profileSO;
    private void Start()
    {
        button.onClick.AddListener(() => 
        {
            ProfileManagerUI.instance.ChangeProfilePage(profileSO);
        });

        ProfileManagerUI.instance.OnProfileChange += ProfileManagerUI_OnProfileChange;

    }

    private void ProfileManagerUI_OnProfileChange(object sender, ProfileSO e)
    {
        if(e == profileSO)
        {
            highlight.SetActive(true);
        }
        else
        {
            highlight.SetActive(false);
        }
    }

    public void Setup(ProfileSO profileSO)
    {
        this.profileSO = profileSO;

        buttonImage.sprite = profileSO.characterPotrait;
        profileNameText.text = profileSO.profileName;

    }
}
