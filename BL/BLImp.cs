using DAL;
using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BO.Recipers;

namespace BL
{
    public class BLImp : IBL
    {
        DLImp dl = new DLImp();

        
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

        

        public string RecordRecipeUsage(DateTime date)
        {
           return dl.RecordRecipeUsage(date);
        }

        //public List<Watch> GetUserWatches(string userName,DateTime start,DateTime end)
        //{

        //    return dl.GetUserWatches(userName, start, end);
        //      //  return new List<Watch> { new Watch { Destination = "Fdc", Origin = "rcd", Date = new DateTime(2022, 10, 21) } };
        //}


        public List<Calend> GetCalendWatches(DateTime date)
        {

            return dl.GetCalendWatches(date);
            //  return new List<Watch> { new Watch { Destination = "Fdc", Origin = "rcd", Date = new DateTime(2022, 10, 21) } };
        }

        #region Recipers
        public Dictionary<string, List<ReciperInfoPartial>> GetCurrentRecipers()
        {
           return dl.GetCurrentRecipers();
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
        public ReciperDetail GetReciperDetail(string partialReciperID)
        {
            return dl.GetReciperData(partialReciperID);
        }

        public Dictionary<string, Dictionary<string, string>> GetWeather(ReciperDetail Reciper ,ReciperInfoPartial fip)
        {
           
            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();

            Dictionary<string, string> currentW = dl.GetCurrentWeather(fip.Long.ToString(), fip.Lat.ToString());
            Dictionary<string, string> originW = dl.GetCurrentWeather(dl.GetLonLatOrigin(Reciper)["lon"], dl.GetLonLatOrigin(Reciper)["lat"]);
            Dictionary<string, string> destinationW = dl.GetCurrentWeather(dl.GetLonLatDestination(Reciper)["lon"], dl.GetLonLatDestination(Reciper)["lat"]);

            result.Add("current", currentW);
            result.Add("origin", originW);
            result.Add("destination", destinationW);

            return result;
        }

        public double GetDistance(ReciperDetail Reciper)
        {
            return dl.GetDistance(Reciper);
        }

        public double GetRemainingDistance(ReciperDetail Reciper, ReciperInfoPartial fip)
        {
            return dl.GetRemainingDst(Reciper, fip);
        }

        public int GetProp(ReciperDetail Reciper, ReciperInfoPartial fip)
        {
            double remainingProp = GetRemainingDistance(Reciper, fip) / GetDistance(Reciper);
            int tmp = (int)(( 1 - remainingProp) * 100);
            return tmp;
        }
        #endregion

        public string GetStringRemainingTime(ReciperDetail Reciper)
        {
            TimeSpan time= dl.GetTimeBetween(Reciper);
            string strtime= time.ToString(@"hh\:mm");
            return strtime;
        }

        public string GetReciperNumber(ReciperDetail Reciper)
        {
            return dl.GetReciperNumber(Reciper);

        }

        public string GetAirlineCompany(ReciperDetail Reciper)
        {
            return dl.GetAirlineCompany(Reciper);
        }

        public string GetOrigin(ReciperInfoPartial fip)
        {
            return dl.GetOrigin(fip);
        }

        public string GetDestination(ReciperInfoPartial fip)
        {
            return dl.GetDestination(fip);
        }

        public string GetOriginName(ReciperDetail Reciper)
        {
            return dl.GetOriginName(Reciper);
        }

        public string GetDestName(ReciperDetail Reciper)
        {
            return dl.GetDestName(Reciper);
        }

        public string GetScheDest(ReciperDetail Reciper)
        {
            return dl.GetScheDest(Reciper);
        }

        public string GetSSource(ReciperDetail Reciper)
        {
            return dl.GetSSource(Reciper);
        }

        public string GetActual(ReciperDetail Reciper)
        {
            return dl.GetActual(Reciper);
        }

        public string GetEstimated(ReciperDetail Reciper)
        {
            return dl.GetEstimated(Reciper);
        }

        public string GetStatusAirplane(ReciperDetail Reciper)
        {
            return dl.GetStatusAirplane(Reciper);
        }

        public string GetReciperStatus(ReciperDetail Reciper)
        {
            return dl.GetReciperStatus(Reciper);
        }

        public string GetSTimezone(ReciperDetail Reciper)
        {
            return dl.GetSTimezone(Reciper);
        }

        public string GetDTimezone(ReciperDetail Reciper)
        {
            return dl.GetDTimezone(Reciper);
        }

        public List<Recipe> GetAllRecipeDetails(string Id)
        {
            return dl.GetAllRecipeDetails(Id);
        }

        public void UpdateRateRecipe(string recipeName, int starRating)
        {
            dl.UpdateRateRecipe(recipeName, starRating);
        }

        public void UpdateCommentRecipe(string recipeName, string comment)
        {
            dl.UpdateCommentRecipe(recipeName, comment);
        }

        public List<Calend> getCalendDB()
        {
            return dl.getCalendDB();
        }

        public void AddCalendToDB(Calend calend)
        {
            dl.AddCalendToDB(calend);
        }
    }
}
