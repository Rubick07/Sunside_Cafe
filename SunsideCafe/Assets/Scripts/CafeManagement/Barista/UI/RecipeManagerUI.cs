using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeManagerUI : MonoBehaviour
{
    public static RecipeManagerUI instance;

    [SerializeField] private Button closeButton;

    [Header("RecipeButton SetUp")]
    [SerializeField] private RecipeUI recipeUIPrefab;
    [SerializeField] private Transform recipeUIContainer;
    [Header("RecipeDesc SetUp")]
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private TextMeshProUGUI recipeDescText;


    private List<RecipeUI> recipeUIList = new List<RecipeUI>();

    private void Awake()
    {
        recipeUIContainer.RemoveAllChild();

        instance = this;
    }

    private void Start()
    {
        closeButton.onClick.AddListener(Hide);

        CreateRecipeUI();
        Hide();
    }

    public void CreateRecipeUI()
    {
        foreach(RecipeData recipeData in RecipeManager.instance.GetRecipeDataList())
        {
/*            if (recipeData.name.EndsWith("_Unfinished"))
                continue;*/


            RecipeUI recipeUI = Helpers.CreateUI<RecipeUI, RecipeData>(recipeUIPrefab, recipeUIContainer, recipeData);

            recipeUIList.Add(recipeUI);
        }

        ChangeRecipeUI(RecipeManager.instance.GetRecipeDataList()[0]);
    }

    public void ChangeRecipeUI(RecipeData recipeData)
    {
        recipeNameText.text = recipeData.recipeName;
        recipeDescText.text = recipeData.recipeDesc;
    }


    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public void Toggle()
    {
        if (gameObject.activeSelf)
            Hide();
        else Show();
    }

}
