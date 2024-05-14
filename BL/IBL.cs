using BO;
using BO.Recipers;
using System;
using System.Collections.Generic;

namespace BL
{
    interface IBL
    {
        List<Recipe> getRecipesDB();
        void AddRecipeToDB(Recipe recipe);
        List<Calend> getCalendDB();
        void AddCalendToDB(Calend calend);
        void AddUser(User u);
        bool ExistUser(User u);
        void AddWatch(Watch w);
        List<Watch> GetAllWatches();
        //List<Watch> GetUserWatches(string userName, DateTime start, DateTime end);
        List<Calend> GetCalendWatches(DateTime dateClikcked);
        string RecordRecipeUsage(DateTime date);
        List<Recipe> GetAllRecipeDetails(string Id);

        void UpdateRateRecipe(string recipeName, int starRating);
        void UpdateCommentRecipe(string recipeName, string comment);

        Dictionary<string, List<ReciperInfoPartial>> GetCurrentRecipers();
        List<RecipeInfoPartial> SearchByIngredients(List<string> listOfIngredients);
        List<RecipeKeyWord> SearchByKeyWord(string keyWord);
        string AnalyzedRecipeInstructions(string recipeId);
        List<RecipesSimilar> GetSimilarRecipes(string recipeId);
        ReciperDetail GetReciperDetail(string partialReciperID);

        Dictionary<string, Dictionary<string, string>> GetWeather(ReciperDetail Reciper, ReciperInfoPartial fip);
   
        double GetDistance(ReciperDetail Reciper);
        int GetProp(ReciperDetail Reciper, ReciperInfoPartial fip);
        double GetRemainingDistance(ReciperDetail Reciper, ReciperInfoPartial fip);

        string GetStringRemainingTime(ReciperDetail Reciper);

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
