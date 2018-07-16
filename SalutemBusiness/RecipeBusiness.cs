using SalutemData;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalutemBusiness
{
    public class RecipeBusiness
    {
        //atributos
        private string connectionString;
        private RecipeData recipeData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public RecipeBusiness(string conn)
        {
            this.connectionString = conn;
            recipeData = new RecipeData(this.connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string insertRecipeBusiness(Recipe recipe, Userr user)
        {
            string message = "";

            message = recipeData.insertRecipeData(recipe, user);

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string deleteRecipeBusiness(Recipe recipe)
        {
            string message = "";

            message = recipeData.deleteRecipeData(recipe);

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string deleteRecipeWithoutDiagnosisIdBusiness(Recipe recipe, Userr user)
        {
            string message = "";

            message = recipeData.deleteRecipeWithoutRecipeIdData(recipe, user);

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string updateRecipeWithoutDiagnosisIdBusiness(Recipe recipe, Userr user, string oldDate, int oldHour)
        {
            string message = "";

            message = recipeData.updateRecipeWithoutRecipeIdData(recipe, user, oldDate, oldHour);


            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Recipe> getAllRecipesData()
        {
            List<Recipe> recipesList = recipeData.getAllRecipesData();

            return recipesList;
        }

        public List<Recipe> getRecipesDataByIdentityCardData(string identityCard)
        {
            List<Recipe> recipesList = recipeData.getRecipesDataByIdentityCardData(identityCard);

            return recipesList;
        }

        public string validateDateBusiness(string date, int hour)
        {
            string message = "";

            message = recipeData.validateDateData(date, hour);

            return message;
        }
    }
}
