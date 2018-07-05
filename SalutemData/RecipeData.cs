using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SalutemData
{
    public class RecipeData
    {
    
        private string connectionString;

        public RecipeData(string conn)
        {
            this.connectionString = conn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string insertRecipeData(Recipe recipe, Userr user)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_insertRecipe";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));
                cmd.Parameters.Add(new SqlParameter("@description", recipe.description));
                cmd.Parameters.Add(new SqlParameter("@date", recipe.date));
                cmd.Parameters.Add(new SqlParameter("@hour", recipe.hour));

                SqlParameter parameterId = new SqlParameter("@getRecipeId", SqlDbType.Int);
                parameterId.Direction = ParameterDirection.Output;

                //Se asignan los parametros
                cmd.Parameters.Add(parameterId);

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                string recipeId = cmd.Parameters["@getRecipeId"].Value.ToString();

                connection.Close();

                message = recipeId;

            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string deleteRecipeData(int id)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_deleteRecipe";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                connection.Close();
            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string deleteRecipeWithoutRecipeIdData(Recipe recipe, Userr user)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_deleteRecipeWithoutRecipeId";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));
                cmd.Parameters.Add(new SqlParameter("@description", recipe.description));
                cmd.Parameters.Add(new SqlParameter("@date", recipe.date));
                cmd.Parameters.Add(new SqlParameter("@hour", recipe.hour));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                connection.Close();
            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string updateRecipeWithoutRecipeIdData(Recipe recipe, Userr user)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "updateRecipeWithoutRecipeIdData";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));
                cmd.Parameters.Add(new SqlParameter("@description", recipe.description));
                cmd.Parameters.Add(new SqlParameter("@date", recipe.date));
                cmd.Parameters.Add(new SqlParameter("@hour", recipe.hour));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                connection.Close();
            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }


        public List<Recipe> getAllRecipesData()
        {
            List<Recipe> recipesList = new List<Recipe>();
            string finalDate = "", date = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_getAllRecipes";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Recipe recipe = new Recipe();

                    date = reader["date"].ToString();

                    string[] dateArray = date.Split(' ');
                    string[] formatDate = dateArray[0].Split('/');

                    finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

                    recipe.id = Convert.ToInt32(reader["id"].ToString());
                    recipe.date = finalDate;
                    recipe.hour = Convert.ToInt32(reader["hour"].ToString());
                    recipe.status = reader["status"].ToString();
                    recipe.description = reader["description"].ToString();
                    recipe.user = new Userr(reader["identityCard"].ToString(), reader["name"].ToString());

                    recipesList.Add(recipe);
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                return recipesList;
            }

            return recipesList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns></returns>
        public List<Recipe> getRecipesDataByIdentityCardData(string identityCard)
        {
            List<Recipe> appointmentList = new List<Recipe>();
            string finalDate = "", date = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_getRecipesByIdentityCard";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", identityCard));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Recipe recipe = new Recipe();

                    date = reader["date"].ToString();

                    string[] dateArray = date.Split(' ');
                    string[] formatDate = dateArray[0].Split('/');

                    finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

                    recipe.id = Convert.ToInt32(reader["id"].ToString());
                    recipe.date = finalDate;
                    recipe.hour = Convert.ToInt32(reader["hour"].ToString());
                    recipe.status = reader["status"].ToString();
                    recipe.description = reader["description"].ToString();
                    recipe.user = new Userr(reader["identityCard"].ToString(), reader["name"].ToString());

                    appointmentList.Add(recipe);
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                return null;
            }

            return appointmentList;
        }
    }
}
