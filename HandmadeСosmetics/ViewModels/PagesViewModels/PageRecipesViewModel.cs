﻿using HandmadeСosmetics.Command;
using HandmadeСosmetics.Models.DB;
using HandmadeСosmetics.Models.MaterialsAndProducts;
using HandmadeСosmetics.ViewModel;
using HandmadeСosmetics.Views.Windows;
using System.Windows.Input;

namespace HandmadeСosmetics.ViewModels.PagesViewModels
{
    internal class PageRecipesViewModel : ViewModelBase
    {
        private readonly QueryRecipeTable queryRecipeTable;
        private List<Recipe> recipes;
        private List<Ingredient> ingredients;
        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set => Set(ref selectedRecipe, value);
        }

        public List<Recipe> Recipes
        {
            get => recipes;
            set => Set(ref recipes, value);
        }

        public List<Ingredient> Ingredients
        {
            get => ingredients;
            set => Set(ref ingredients, value);
        }

        public PageRecipesViewModel()
        {
            queryRecipeTable = new QueryRecipeTable(new DataCotnext.DataDBContex());
            AddNewRecipeCommand = new LambdaCommand(OnAddNewRecipeCommandExecuted);
            DeleteRecipeCommand = new LambdaCommand(OnDeleteRecipeCommandExecuted, CanDeleteRecipeCommandExecute);
            GetRecipes();
        }

        private async Task GetRecipes()
        {
            Recipes = (await queryRecipeTable.Get()).ToList();
        }

        #region Создание рецепта.................................................................................................

        public ICommand AddNewRecipeCommand { get; }

        private void OnAddNewRecipeCommandExecuted(object p)
        {
            AddNewRecipeView addNewRecipeView = new AddNewRecipeView();
            addNewRecipeView.ShowDialog();
            GetRecipes();
        }

        #endregion Создание рецепта.................................................................................................

        #region Команда обновления рецепта.......................................................................................

        public ICommand EditRecipeCommand { get; }

        private bool CanEditRecipeCommandExecute(object p)
        {
            return p is Recipe;
        }

        private void OnEditRecipeCommandExecuted(object p)
        {
            UpdateRecipeView updateRecipeView = new UpdateRecipeView();
            updateRecipeView.ShowDialog();
            GetRecipes();
        }

        #endregion Команда обновления рецепта.......................................................................................

        #region Удаление рецепта..................................................................................................

        public ICommand DeleteRecipeCommand { get; }

        private bool CanDeleteRecipeCommandExecute(object p)
        {
            return p is Recipe;
        }

        private void OnDeleteRecipeCommandExecuted(object p)
        {
            queryRecipeTable.Delete(p as Recipe);
            GetRecipes();
        }

        #endregion Удаление рецепта..................................................................................................
    }
}