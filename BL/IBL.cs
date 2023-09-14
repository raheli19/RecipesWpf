﻿using BO;
using BO.Flights;
using System;
using System.Collections.Generic;

namespace BL
{
    interface IBL
    {
        List<Recipe> getRecipesDB();
        void AddRecipeToDB(Recipe recipe);
        void AddUser(User u);
        bool ExistUser(User u);
        void AddWatch(Watch w);
        List<Watch> GetAllWatches();
        List<Watch> GetUserWatches(string userName, DateTime start, DateTime end);
        RecipeDateUsage RecordRecipeUsage();
        List<Recipe> GetAllRecipeDetails(string Id);

        //string RateAndCommentRecipe(string recipeName, int starRating, string comment);
        //string UpdateCommentRecipe(string recipeName, int starRating, string comment);

        Dictionary<string, List<FlightInfoPartial>> GetCurrentFlights();
        List<RecipeInfoPartial> SearchByIngredients(List<string> listOfIngredients);
        List<RecipeKeyWord> SearchByKeyWord(string keyWord);
        string AnalyzedRecipeInstructions(string recipeId);
        List<RecipesSimilar> GetSimilarRecipes(string recipeId);
        FlightDetail GetFlightDetail(string partialFlightID);

        Dictionary<string, Dictionary<string, string>> GetWeather(FlightDetail flight, FlightInfoPartial fip);
   
        double GetDistance(FlightDetail flight);
        int GetProp(FlightDetail flight, FlightInfoPartial fip);
        double GetRemainingDistance(FlightDetail flight, FlightInfoPartial fip);

        string GetStringRemainingTime(FlightDetail flight);

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
