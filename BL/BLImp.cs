﻿using DAL;
using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BO.Flights;

namespace BL
{
    public class BLImp : IBL
    {
        DLImp dl = new DLImp();

        public List<Recipe> RecipesDataBase
        {
            get { return dl.RecipesDataBase; }
        }
        public List<Recipe> getRecipesDB()
        {
            return dl.getRecipesDB();
        }
        public void AddRecipeToDB(Recipe recipe)
        {
            dl.AddRecipeToDB(recipe);
        }
        public void AddUser(User u)
        {
            dl.AddUser(u);
        }

        public void AddWatch(Watch w)
        {
            dl.AddWatch(w);
        }

        public bool ExistUser(User u)
        {
            return dl.ExistUser(u);
        }

        public List<Watch> GetAllWatches()
        {
            throw new NotImplementedException();
            
        }

        

        public RecipeDateUsage RecordRecipeUsage()
        {
            return dl.RecordRecipeUsage();
        }

        public List<Watch> GetUserWatches(string userName,DateTime start,DateTime end)
        {

            return dl.GetUserWatches(userName, start, end);
              //  return new List<Watch> { new Watch { Destination = "Fdc", Origin = "rcd", Date = new DateTime(2022, 10, 21) } };
        }

        #region flights
        public Dictionary<string, List<FlightInfoPartial>> GetCurrentFlights()
        {
           return dl.GetCurrentFlights();
        }
        public  List<RecipeInfoPartial> SearchByIngredients(List<string> listOfIngredients)
        {
            return dl.SearchByIngredients(listOfIngredients);
        }

        public List<RecipeKeyWord> SearchByKeyWord(string keyWord)
        {
            return dl.SearchByKeyWord(keyWord);
        }

        public string AnalyzedRecipeInstructions(string recipeId)
        {
            return dl.AnalyzedRecipeInstructions(recipeId);
        }
        public List<RecipesSimilar> GetSimilarRecipes(string recipeId)
        {
            return dl.GetSimilarRecipes(recipeId);
        }
        public FlightDetail GetFlightDetail(string partialFlightID)
        {
            return dl.GetFlightData(partialFlightID);
        }

        public Dictionary<string, Dictionary<string, string>> GetWeather(FlightDetail flight ,FlightInfoPartial fip)
        {
           
            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();

            Dictionary<string, string> currentW = dl.GetCurrentWeather(fip.Long.ToString(), fip.Lat.ToString());
            Dictionary<string, string> originW = dl.GetCurrentWeather(dl.GetLonLatOrigin(flight)["lon"], dl.GetLonLatOrigin(flight)["lat"]);
            Dictionary<string, string> destinationW = dl.GetCurrentWeather(dl.GetLonLatDestination(flight)["lon"], dl.GetLonLatDestination(flight)["lat"]);

            result.Add("current", currentW);
            result.Add("origin", originW);
            result.Add("destination", destinationW);

            return result;
        }

        public double GetDistance(FlightDetail flight)
        {
            return dl.GetDistance(flight);
        }

        public double GetRemainingDistance(FlightDetail flight, FlightInfoPartial fip)
        {
            return dl.GetRemainingDst(flight, fip);
        }

        public int GetProp(FlightDetail flight, FlightInfoPartial fip)
        {
            double remainingProp = GetRemainingDistance(flight, fip) / GetDistance(flight);
            int tmp = (int)(( 1 - remainingProp) * 100);
            return tmp;
        }
        #endregion

        public string GetStringRemainingTime(FlightDetail flight)
        {
            TimeSpan time= dl.GetTimeBetween(flight);
            string strtime= time.ToString(@"hh\:mm");
            return strtime;
        }

        public string GetFlightNumber(FlightDetail flight)
        {
            return dl.GetFlightNumber(flight);

        }

        public string GetAirlineCompany(FlightDetail flight)
        {
            return dl.GetAirlineCompany(flight);
        }

        public string GetOrigin(FlightInfoPartial fip)
        {
            return dl.GetOrigin(fip);
        }

        public string GetDestination(FlightInfoPartial fip)
        {
            return dl.GetDestination(fip);
        }

        public string GetOriginName(FlightDetail flight)
        {
            return dl.GetOriginName(flight);
        }

        public string GetDestName(FlightDetail flight)
        {
            return dl.GetDestName(flight);
        }

        public string GetScheDest(FlightDetail flight)
        {
            return dl.GetScheDest(flight);
        }

        public string GetSSource(FlightDetail flight)
        {
            return dl.GetSSource(flight);
        }

        public string GetActual(FlightDetail flight)
        {
            return dl.GetActual(flight);
        }

        public string GetEstimated(FlightDetail flight)
        {
            return dl.GetEstimated(flight);
        }

        public string GetStatusAirplane(FlightDetail flight)
        {
            return dl.GetStatusAirplane(flight);
        }

        public string GetFlightStatus(FlightDetail flight)
        {
            return dl.GetFlightStatus(flight);
        }

        public string GetSTimezone(FlightDetail flight)
        {
            return dl.GetSTimezone(flight);
        }

        public string GetDTimezone(FlightDetail flight)
        {
            return dl.GetDTimezone(flight);
        }

        public List<Recipe> GetAllRecipeDetails(string Id)
        {
            return dl.GetAllRecipeDetails(Id);
        }

        
        /*   public string RateAndCommentRecipe(string recipeName, int starRating, string comment)
           {
               return dl.RateAndCommentRecipe(recipeName, starRating, comment);
           }

           public string UpdateCommentRecipe(string recipeName, int starRating, string comment)
           {
               return dl.UpdateCommentRecipe(recipeName, starRating, comment);
           }
        */
    }
}
