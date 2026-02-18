using System.Collections.Generic;
using UnityEngine;

public class RecipeManagerUI : MonoBehaviour
{
    public static RecipeManagerUI instance;

    [SerializeField] private RecipeUI recipeUIPrefab;
    [SerializeField] private Transform recipeUIContainer;

    private List<RecipeUI> recipeUIList = new List<RecipeUI>();

    private void Awake()
    {
        recipeUIContainer.RemoveAllChild();

        instance = this;
    }

    private void Start()
    {
        CreateRecipeUI();

        Hide();
    }

    public void CreateRecipeUI()
    {
        Debug.Log("Hai");
        foreach(RecipeData recipeData in RecipeManager.instance.GetRecipeDataList())
        {
            Debug.Log("Hai sad");

            RecipeUI recipeUI = Helpers.CreateUI<RecipeUI, RecipeData>(recipeUIPrefab, recipeUIContainer, recipeData);

            recipeUIList.Add(recipeUI);
        }


    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
