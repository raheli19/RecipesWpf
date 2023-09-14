using BO;
using BO.Flights;
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
        List<Watch> GetUserWatches(string userName, DateTime start, DateTime end);
        RecipeDateUsage RecordRecipeUsage();
        //string RateAndCommentRecipe(string recipeName, int starRating, string comment);
        //string UpdateCommentRecipe(string recipeName, int starRating, string comment);
        List<Recipe> GetAllRecipeDetails(string recipeId);
        List<Recipe> getRecipesDB();
        void AddRecipeToDB(Recipe recipe);



        Dictionary<string, List<FlightInfoPartial>> GetCurrentFlights();
        List<RecipeInfoPartial> SearchByIngredients(List<string> listOfIngredients);
        List<RecipeKeyWord> SearchByKeyWord(string keyWord);
        string AnalyzedRecipeInstructions(string recipeId);
        List<RecipesSimilar> GetSimilarRecipes(string recipeId);
        FlightDetail GetFlightData(string key);


        Dictionary<string, string> GetCurrentWeather(string lon, string lat);
        Dictionary<string, string> GetLonLatOrigin(FlightDetail flight);
        Dictionary<string, string> GetLonLatDestination(FlightDetail flight);
        double GetDistance(FlightDetail flight);
        TimeSpan GetTimeBetween(FlightDetail flight);

        double GetRemainingDst(FlightDetail flight, FlightInfoPartial fip);

        string GetFlightNumber(FlightDetail flight);
        string GetAirlineCompany(FlightDetail flight);
        string GetOrigin(FlightInfoPartial fip);
        string GetDestination(FlightInfoPartial fip);
        string GetOriginName(FlightDetail flight);
        string GetDestName(FlightDetail flight);
        string GetScheDest(FlightDetail flight);
        string GetSSource(FlightDetail flight);
        string GetActual(FlightDetail flight);
        string GetEstimated(FlightDetail flight);
        string GetStatusAirplane(FlightDetail flight);
        string GetFlightStatus(FlightDetail flight);
        string GetSTimezone(FlightDetail flight);
        string GetDTimezone(FlightDetail flight);




    }
}
