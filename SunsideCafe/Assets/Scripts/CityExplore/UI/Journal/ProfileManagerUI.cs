using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class ProfileManagerUI : MonoBehaviour
{
    public static ProfileManagerUI instance;

    public event EventHandler<ProfileSO> OnProfileChange;

    [SerializeField] private List<ProfileSO> profileSOList;

    [SerializeField] private Image profileImage;

    [Header("Text REFERENCE")]
    [SerializeField] private TextMeshProUGUI profileNameText;
    [SerializeField] private TextMeshProUGUI ageText;
    [SerializeField] private TextMeshProUGUI hobbiesText;
    [SerializeField] private TextMeshProUGUI favouriteOrderText;
    [SerializeField] private TextMeshProUGUI profiledescText;

    [Header("Button REFERENCE")]
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private Transform profileButtonPrefab;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        buttonContainer.RemoveAllChild();

        CreateButton();
        ChangeProfilePage(profileSOList[0]);
    }

    public void CreateButton()
    {
        int index = 0;

        foreach (ProfileSO a in profileSOList)
        {
            Transform profileButtonTransform = Instantiate(profileButtonPrefab, buttonContainer);

            ProfileButtonUI profileDayButton = profileButtonTransform.GetComponent<ProfileButtonUI>();

            profileDayButton.Setup(a);

            index++;
        }
    }

    public void ChangeProfilePage(ProfileSO profileSO)
    {
        profileNameText.text = profileSO.profileName;
        ageText.text = profileSO.age;
        hobbiesText.text = profileSO.hobbies;
        favouriteOrderText.text = profileSO.favouriteFood;
        profiledescText.text = profileSO.profileDesc;

        profileImage.sprite = profileSO.characterPotrait;


        OnProfileChange?.Invoke(this, profileSO);
    }




}
