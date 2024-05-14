using BO;
using BO.Recipers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDL
    {
        void AddUser(User u);
        void UpdatePassword(User u, string newPassword);
        bool ExistUser(User u);
        //List<Watch> GetUserWatches(string userName, DateTime start, DateTime end);
        List<Calend> GetCalendWatches(DateTime dateClikcked);
        string RecordRecipeUsage(DateTime date);
        void UpdateRateRecipe(string recipeName, int starRating);
        void UpdateCommentRecipe(string recipeName, string comment);
        List<Recipe> GetAllRecipeDetails(string recipeId);
        List<Recipe> getRecipesDB();
        void AddRecipeToDB(Recipe recipe);
        List<Calend> getCalendDB();
        void AddCalendToDB(Calend calend);




        Dictionary<string, List<ReciperInfoPartial>> GetCurrentRecipers();
        List<RecipeInfoPartial> SearchByIngredients(List<string> listOfIngredients);
        List<RecipeKeyWord> SearchByKeyWord(string keyWord);
        string AnalyzedRecipeInstructions(string recipeId);
        List<RecipesSimilar> GetSimilarRecipes(string recipeId);
        ReciperDetail GetReciperData(string key);


        Dictionary<string, string> GetCurrentWeather(string lon, string lat);
        Dictionary<string, string> GetLonLatOrigin(ReciperDetail Reciper);
        Dictionary<string, string> GetLonLatDestination(ReciperDetail Reciper);
        double GetDistance(ReciperDetail Reciper);
        TimeSpan GetTimeBetween(ReciperDetail Reciper);

        double GetRemainingDst(ReciperDetail Reciper, ReciperInfoPartial fip);

        string GetReciperNumber(ReciperDetail Reciper);
        string GetRecipermCompany(ReciperDetail Reciper);
        string GetOrigin(ReciperInfoPartial fip);
        string GetDestination(ReciperInfoPartial fip);
        string GetOriginName(ReciperDetail Reciper);
        string GetDestName(ReciperDetail Reciper);
        string GetScheDest(ReciperDetail Reciper);
        string GetSSource(ReciperDetail Reciper);
        string GetActual(ReciperDetail Reciper);
        string GetEstimated(ReciperDetail Reciper);
        string GetStatusRecipero(ReciperDetail Reciper);
        string GetReciperStatus(ReciperDetail Reciper);
        string GetSTimezone(ReciperDetail Reciper);
        string GetDTimezone(ReciperDetail Reciper);




    }
}
