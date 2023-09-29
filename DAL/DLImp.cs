﻿using DAL.DB;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using BO.Flights;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using GeoCoordinatePortable;
using System.Text.RegularExpressions;

//using System.Activities;
//using System.Device.Location;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using sqlServer;

namespace DAL
{
    public class DLImp : IDL
    {
        HelperClass helperC = new HelperClass();

        #region recipes

        static public List<Recipe> recipesDataBase = new List<Recipe>();
        static public List<Calend> calendarList = new List<Calend>();


        public List<Recipe> getRecipesDB()
        {
            return recipesDataBase;
        }



        public void AddRecipeToDB(Recipe recipe)
        {
            recipesDataBase.Add(recipe);
        }

        public List<Calend> getCalendDB()
        {
            return calendarList;
        }



        public void AddCalendToDB(Calend calend)
        {
            calendarList.Add(calend);
        }

        public List<RecipeInfoPartial> SearchByIngredients(List<string> listOfIngredients)
        {
            //JObject AllRecipesData = null;
            JArray AllRecipesData = null;
            string ingredientsParam = string.Join(",", listOfIngredients); // Convertir la liste en une chaîne de caractères séparée par des virgules
            //string allURL = @"https://api.spoonacular.com/recipes/findByIngredients?ingredients=" + listOfIngredients + "&apiKey=58e214373f5d418dbd86a05188042992";
            string allURL = $"https://api.spoonacular.com/recipes/findByIngredients?ingredients={ingredientsParam}&apiKey=58e214373f5d418dbd86a05188042992";

            Dictionary<string, List<RecipeInfoPartial>> recipesDictionary = new Dictionary<string, List<RecipeInfoPartial>>();
            List<RecipeInfoPartial> recipes = new List<RecipeInfoPartial>();

            using (var webClient = new System.Net.WebClient())
            {
                HelperClass Helper = new HelperClass();
                var json = RequestDataSync(allURL);
                AllRecipesData = JArray.Parse(json);



                try
                {
                    foreach (var item in AllRecipesData)

                    {

                        JObject recipe = (JObject)item;

                        string recipeId = recipe["id"].ToString();

                        string recipeTitle = recipe["title"].ToString();

                        string imageLink = recipe["image"].ToString();

                        string missedIngredientsCount = recipe["missedIngredientCount"].ToString();
                        int missedIngredientsCountDouble = Convert.ToInt16(missedIngredientsCount);

                        string usedIngredientsCount = recipe["usedIngredientCount"].ToString();
                        int usedIngredientsCountDouble = Convert.ToInt16(usedIngredientsCount);

                        string usedIngredients = "";
                        string missedIngredients = "";

                        for (int i = 0; i < missedIngredientsCountDouble; i++)
                        {
                            missedIngredients += "- " + (recipe["missedIngredients"][i]["name"].ToString()) + "\n";

                        }
                        for (int i = 0; i < usedIngredientsCountDouble; i++)
                        {
                            usedIngredients += "- " + (recipe["usedIngredients"][i]["name"].ToString()) + "\n";

                        }


                        recipes.Add(new RecipeInfoPartial
                        {

                            Id = recipeId,
                            Title = recipeTitle,
                            ImageLink = imageLink,
                            UsedIngredientsCount = usedIngredientsCountDouble,
                            MissedIngredientsCount = missedIngredientsCountDouble,
                            UsedIngredients = usedIngredients,
                            MissedIngredients = missedIngredients,



                        });
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }

            }

            return recipes;


        }

        public List<RecipeKeyWord> SearchByKeyWord(string keyWord)
        {
            JObject AllRecipesData = null;
            string allURL = $"https://api.spoonacular.com/recipes/complexSearch?query={keyWord}&apiKey=58e214373f5d418dbd86a05188042992";

            Dictionary<string, List<RecipeKeyWord>> recipesDictionary = new Dictionary<string, List<RecipeKeyWord>>();
            List<RecipeKeyWord> recipes = new List<RecipeKeyWord>();

            using (var webClient = new System.Net.WebClient())
            {
                HelperClass Helper = new HelperClass();
                var json = RequestDataSync(allURL);
                AllRecipesData = JObject.Parse(json);
                //AllRecipesData = JArray.Parse(json);

                int count = 0;

                try
                {
                    foreach (var recipe in AllRecipesData)

                    {
                        count++;
                        if (count > 1) { break; }
                        string totalRecipes = AllRecipesData.GetValue("number").ToString();
                        int totalRecipesInt = Convert.ToInt16(totalRecipes);

                        // JObject recipe = (JObject)item;
                        for (int i = 0; i < totalRecipesInt; i++)
                        {

                            string recipeId = recipe.Value[i]["id"].ToString();


                            string recipeTitle = recipe.Value[i]["title"].ToString();

                            string recipeImage = recipe.Value[i]["image"].ToString();


                            recipes.Add(new RecipeKeyWord
                            {
                                Id = recipeId,
                                Title = recipeTitle,
                                ImageLink = recipeImage,
                            });

                        }

                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }

            }
            return recipes;

        }

        public string AnalyzedRecipeInstructions(string recipeId)
        {
            JArray AllRecipesData = null;
            string allURL = $"https://api.spoonacular.com/recipes/{recipeId}/analyzedInstructions?&apiKey=58e214373f5d418dbd86a05188042992";

            Dictionary<string, List<RecipeInfoPartial>> recipesDictionary = new Dictionary<string, List<RecipeInfoPartial>>();
            List<RecipeInfoPartial> recipes = new List<RecipeInfoPartial>();
            string steps = "";

            using (var webClient = new System.Net.WebClient())
            {
                HelperClass Helper = new HelperClass();
                var json = RequestDataSync(allURL);
                AllRecipesData = JArray.Parse(json);

                try
                {
                    foreach (var item in AllRecipesData)

                    {

                        JObject recipe = (JObject)item;

                        for (int i = 0; i < recipe["steps"].Count(); i++)
                        {
                            steps += "- " + (recipe["steps"][i]["step"].ToString()) + "\n" + "\n";

                        }

                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }

            }

            return steps;


        }

        public List<RecipesSimilar> GetSimilarRecipes(string recipeId)
        {
            JArray AllRecipesData = null;
            string allURL = $"https://api.spoonacular.com/recipes/{recipeId}/similar?&apiKey=58e214373f5d418dbd86a05188042992";

            List<RecipesSimilar> recipes = new List<RecipesSimilar>();

            using (var webClient = new System.Net.WebClient())
            {
                HelperClass Helper = new HelperClass();
                var json = RequestDataSync(allURL);
                AllRecipesData = JArray.Parse(json);



                try
                {
                    foreach (var item in AllRecipesData)

                    {

                        JObject recipe = (JObject)item;

                        string id = recipe["id"].ToString();

                        string recipeTitle = recipe["title"].ToString();
                        string recipeReadyInMinutes = recipe["readyInMinutes"].ToString();
                        string recipeServings = recipe["servings"].ToString();





                        recipes.Add(new RecipesSimilar
                        {

                            Id = id,
                            Title = recipeTitle,
                            ReadyInMinutes = recipeReadyInMinutes,
                            Servings = recipeServings,



                        });
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }

            }

            return recipes;
        }

        #region  RATING & COMMENTS
        // RATING & COMMENTS
        
        public void UpdateRateRecipe(string recipeName, int starRating)
        {

            List<Recipe> recipeDetails = getRecipesDB();
            var existingRecipe = recipeDetails.FirstOrDefault(r => r.Title == recipeName);

           // Update existing recipe with new rate
           existingRecipe.StarRating = starRating;
                    
           List<Recipe> checkLst = getRecipesDB();
           
        }

           
        public void UpdateCommentRecipe(string recipeName, string comment)
        {
            List<Recipe> recipeDetails = getRecipesDB();
            var existingRecipe = recipeDetails.FirstOrDefault(r => r.Title == recipeName);

            // Update existing recipe with new rate
            existingRecipe.Comments = comment;

            List<Recipe> checkLst = getRecipesDB();

        }
        #endregion





        private const string flightDetails = @"https://data-live.flightradar24.com/clickhandler/?version=1.5&flight=";
        public Dictionary<string, List<FlightInfoPartial>> GetCurrentFlights()
        {
            Console.WriteLine("AAAAAAAAAAA");
            JObject AllFlightsData = null;
            string allURL = @"https://data-cloud.flightradar24.com/zones/fcgi/feed.js?faa=1&bounds=41.13,29.993,25.002,36.383&satellite=1&mlat=1&flarm=1&adsb=1&gnd=1&air=1&vehicles=1&estimated=1&maxage=14400&gliders=1&selected=2d1e1f33&ems=1&stats=1";

            Dictionary<string, List<FlightInfoPartial>> flightsDictionary = new Dictionary<string, List<FlightInfoPartial>>();

            List<FlightInfoPartial> Incoming = new List<FlightInfoPartial>();
            List<FlightInfoPartial> Outgoing = new List<FlightInfoPartial>();

            using (var webClient = new System.Net.WebClient())
            {
                HelperClass Helper = new HelperClass();
                var json = RequestDataSync(allURL);
                AllFlightsData = JObject.Parse(json);
                try
                {
                    foreach (var item in AllFlightsData)
                    {
                        var key = item.Key;
                        if (key == "full_count" || key == "version")
                            continue;
                        if (item.Value[11].ToString() == "TLV")
                            Outgoing.Add(new FlightInfoPartial
                            {
                                Source = item.Value[11].ToString(),
                                Destination = item.Value[12].ToString(),
                                SourceId = key,
                                Long = Convert.ToDouble(item.Value[2]),
                                Lat = Convert.ToDouble(item.Value[1]),
                                DateAndTime = Helper.GetDateTimeFromEpoch(Convert.ToDouble(item.Value[10])),
                                FlightCode = item.Value[13].ToString(),
                            });
                        else if (item.Value[12].ToString() == "TLV")
                            Incoming.Add(new FlightInfoPartial
                            {
                                Id = -1,
                                Source = item.Value[11].ToString(),
                                Destination = item.Value[12].ToString(),
                                SourceId = key,
                                Long = Convert.ToDouble(item.Value[2]),
                                Lat = Convert.ToDouble(item.Value[1]),
                                DateAndTime = Helper.GetDateTimeFromEpoch(Convert.ToDouble(item.Value[10])),
                                FlightCode = item.Value[13].ToString(),


                            });
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }

                flightsDictionary.Add("Incoming", Incoming);
                flightsDictionary.Add("Outgoing", Outgoing);
            }
            return flightsDictionary;
        }



        private string RequestDataSync(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                Console.WriteLine("URL", url);
                return webClient.DownloadString(url);
            }
        }

        public FlightDetail GetFlightData(string key)
        {
            string CurrentUrl = (string)flightDetails + key;
            FlightDetail currentFlight = null;

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(CurrentUrl);
                try
                {
                    currentFlight = (FlightDetail)JsonConvert.DeserializeObject<FlightDetail>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

            }

            return currentFlight;
        }


        public List<Recipe> GetAllRecipeDetails(string Id)
        {
            Random random = new Random();
            List<Ingredient> AllDetails = new List<Ingredient>();
            string allDetailsString = string.Empty;
            List<Recipe> recipesList = new List<Recipe>();

            DateTime startDate = new DateTime(2022, 1, 1); // Start date
            DateTime endDate = new DateTime(2023, 12, 31); // End date

            // Calculate the number of days between start and end dates
            int range = (endDate - startDate).Days;

            string allURL = $"https://api.spoonacular.com/recipes/{Id}/information?includeNutrition=false&apiKey=58e214373f5d418dbd86a05188042992";
            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    // HelperClass Helper = new HelperClass();
                    //var json = RequestDataSync(allURL);
                    //RecipeDetails = JArray.Parse(json);
                    var json = webClient.DownloadString(allURL);
                    var recipe = JsonConvert.DeserializeObject<Recipe>(json);

                    if (recipe.extendedIngredients != null)
                    {
                        foreach (var ingredient in recipe.extendedIngredients)
                        {
                            string ingredientId = ingredient.Id.ToString();
                            string ingredientName = ingredient.Name.ToString();
                            string ingredientAisle = ingredient.Aisle.ToString();
                            allDetailsString += "- id: " + ingredientId + "\n  name: " + ingredientName + "\n  aisle: " + ingredientAisle + "\n" + "\n";

                            // Create an Ingredient object and add it to the list
                            AllDetails.Add(new Ingredient
                            {
                                Id = ingredientId,
                                Name = ingredientName,
                                Aisle = ingredientAisle,
                            });
                        }

                        //string recipeId = recipe.RId.ToString();
                        string title = recipe.Title.ToString();
                        string readyInMinutes = recipe.ReadyInMinutes.ToString();
                        string servings = recipe.Servings.ToString();
                        string summary = recipe.Summary.ToString();
                        string summarytWithoutHtml = Regex.Replace(summary, "<.*?>", "");
                        string[] words = summarytWithoutHtml.Split(' ');
                        int wordCount = 0;
                        string resultSum = "";

                        foreach (string word in words)
                        {
                            resultSum += word + " ";
                            wordCount++;

                            if (wordCount == 10)
                            {
                                resultSum += Environment.NewLine;
                                wordCount = 0;
                            }
                        }

                        string image = recipe.Image.ToString();
                        string instructions = recipe.Instructions.ToString();
                        string instructionsWithoutHtml = Regex.Replace(instructions, "<.*?>", "");
                        string[] words2 = instructionsWithoutHtml.Split(' ');
                        int wordCount2 = 0;
                        string resultIns = "";

                        foreach (string word in words2)
                        {
                            resultIns += word + " ";
                            wordCount2++;

                            if (wordCount2 == 10)
                            {
                                resultIns += Environment.NewLine;
                                wordCount2 = 0;
                            }
                        }

                        int starRat = random.Next(1, 6);

                        string comment = "";

                        // Generate a random number of days to add to the start date , Add the random number of days to the start date
                        int randomDays = random.Next(range);
                        DateTime randomDate = startDate.AddDays(randomDays);

                        string date = randomDate.ToString("yyyy-MM-dd").Replace('/', '-');

                        string extIngredients = AllDetails.ToString();


                        recipesList.Add(new Recipe
                        {
                            RId = Id,
                            Title = title,
                            ReadyInMinutes = readyInMinutes,
                            Servings = servings,
                            Summary = resultSum,
                            Image = image,
                            Instructions = resultIns,
                            StarRating = starRat,
                            Comments = comment,
                            Date = date,
                            extendedIngredientsString = allDetailsString,
                            extendedIngredients = AllDetails,

                        });

                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }
                return recipesList;

            }
        }


        #endregion

        #region user
        public void AddUser(User u)
        {
            using (var db = new FlightContext())
            {
                db.Users.Add(u);
                db.SaveChanges();
            }

        }

        public void AddWatch(Watch w)
        {
            using (var db = new FlightContext())
            {
                db.Watches.Add(w);
                db.SaveChanges();
            }
        }

        public void UpdatePassword(User u, string newPassword)
        {
            using (var ctx = new FlightContext())
            {
                var user = ctx.Users.Find(u);
                if (user != null)
                {
                    ctx.Users.Remove(user);
                    user.Password = newPassword;
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }

            }
        }

        public bool ExistUser(User u)
        {
            using (var ctx = new FlightContext())
            {
                if (ctx.Users.Find(u.UserId) != null)
                    return true;
                return false;
            }
        }

        //public List<Watch> GetUserWatches(string userName, DateTime start, DateTime end)
        //{
        //    using (var db = new FlightContext())
        //    {
        //        var l = (db.Watches.Where(w => w.UserName == userName && w.Date <= end && w.Date >= start)).ToList();
        //        l.Reverse();
        //        return l;
        //    }
        //}

        public List<Calend> GetCalendWatches(DateTime date)
        {
            try
            {
                if (getRecipesDB() != null)
                {
                    foreach (
                        var item in getRecipesDB())
                    {
                        if (item.Date == date.ToString("yyyy-MM-dd").Replace('/', '-'))
                        {
                            string holidayName = RecordRecipeUsage(date);
                           
                            var cal = new Calend
                            {
                                Recipe = item.Title,
                                Date = date,
                                HolidayName = holidayName
                            };
                            AddCalendToDB(cal);
                        }
                    }
                    return getCalendDB();
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return getCalendDB();
        }



        #endregion

        #region holidays
        public string RecordRecipeUsage(DateTime date)
        {

            List<DateTime> recordedDates = new List<DateTime>();

            DateTime currentDate = date;
            DateTime endDate = currentDate.AddDays(6);
            string start = currentDate.ToString("yyyy-MM-dd").Replace('/', '-');
            string end = currentDate.AddDays(6).ToString("yyyy-MM-dd").Replace('/', '-');

            string URL = $"https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&mf=on&ss=on&start={start}&end={end}";

            using (var webClient = new System.Net.WebClient())
            {

                try
                {
                    var json = webClient.DownloadString(URL);
                    var holidays = JsonConvert.DeserializeObject<HolidayRoot>(json);


                    if (holidays.items != null && holidays.items.Count > 0)
                    {
                        foreach (var item in holidays.items)
                        {
                            DateTime holidayDate = DateTime.Parse(item.date);

                            if (currentDate <= holidayDate && holidayDate <= endDate)
                            {
                                var recipeUsage = new RecipeDateUsage
                                {
                                    Date = holidayDate.ToString("yyyy-MM-dd"),
                                    Hebrew_date = item.hebrew,
                                    Title = item.title
                                };

                                return recipeUsage.Title.ToString(); // Return the first holiday found
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }

                return "No Jewish holiday in this period";
            }
        }
        #endregion

        #region weather
        public Dictionary<string, string> GetCurrentWeather(string lon, string lat)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string URL = @"https://openweathermap.org/data/2.5/onecall?lat=" + lat + "&lon=" + lon + "&units=metric&appid=439d4b804bc8187953eb36d2a8c26a02";
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(URL);
                WeatherRoot weatherRoot = JsonConvert.DeserializeObject<WeatherRoot>(json);
                string temperature = weatherRoot.current.temp.ToString();
                string mainWeather = weatherRoot.current.weather.First().main;
                string shortDesc = weatherRoot.current.weather.First().description;

                result.Add("temperature", temperature);
                result.Add("mainWeather", mainWeather);
                result.Add("shortDesc", shortDesc);

            }
            return result;
        }
        #endregion

        #region distance and time
        public Dictionary<string, string> GetLonLatOrigin(FlightDetail flight)
        {
            string lon = flight.airport.origin.position.longitude.ToString();
            string lat = flight.airport.origin.position.latitude.ToString();
            return new Dictionary<string, string>() { { "lon", lon }, { "lat", lat } };
        }

        public Dictionary<string, string> GetLonLatDestination(FlightDetail flight)
        {
            string lon = flight.airport.destination.position.longitude.ToString();
            string lat = flight.airport.destination.position.latitude.ToString();
            return new Dictionary<string, string>() { { "lon", lon }, { "lat", lat } };
        }

        public double GetDistance(FlightDetail flight)
        {
            Dictionary<string, string> origin = GetLonLatOrigin(flight);
            Dictionary<string, string> dest = GetLonLatDestination(flight);

            GeoCoordinate pin1 = new GeoCoordinate(Convert.ToDouble(origin["lat"]), Convert.ToDouble(origin["lon"]));
            GeoCoordinate pin2 = new GeoCoordinate(Convert.ToDouble(dest["lat"]), Convert.ToDouble(dest["lon"]));

            double distanceBetween = pin1.GetDistanceTo(pin2);

            return distanceBetween / 1000;

        }

        public double GetRemainingDst(FlightDetail flight, FlightInfoPartial fip)
        {
            Dictionary<string, string> dest = GetLonLatDestination(flight);

            GeoCoordinate pin1 = new GeoCoordinate(Convert.ToDouble(fip.Lat), Convert.ToDouble(fip.Long));
            GeoCoordinate pin2 = new GeoCoordinate(Convert.ToDouble(dest["lat"]), Convert.ToDouble(dest["lon"]));

            double distanceBetween = pin1.GetDistanceTo(pin2);


            double tmp = distanceBetween / 1000; //km
            return tmp;
        }

        public TimeSpan GetTimeBetween(FlightDetail flight)
        {
            HelperClass helperClass = new HelperClass();
            DateTime origin = DateTime.UtcNow;
            long time;
            if (flight.time.estimated.arrival != null)
            {
                time = (long)flight.time.estimated.arrival;
            }
            else time = flight.time.scheduled.arrival;
            DateTime dest = helperClass.GetDateTimeFromEpoch(time);

            TimeSpan res = dest.Subtract(origin);
            return res;

        }
        #endregion

        #region other
        public string GetFlightNumber(FlightDetail flight)
        {
            try
            {
                if (flight.identification.number.Default != null)
                {
                    var flightnum = flight.identification.number.Default;
                    if (flight.identification.number.alternative != null)
                        flightnum += " / " + flight.identification.number.alternative;
                    return flightnum.ToString();
                }
                return "N/A";
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return "N/A";
            }
        }

        public string GetAirlineCompany(FlightDetail flight)
        {
            var airline = flight.airline.name;
            return airline;
        }

        public string GetOrigin(FlightInfoPartial fip)
        {
            try
            {
                return fip.Source;
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return "N/A";
            }
        }

        public string GetDestination(FlightInfoPartial fip)
        {
            try
            {
                return fip.Destination;
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return "N/A";
            }
        }

        public string GetOriginName(FlightDetail flight)
        {
            try
            {
                return flight.airport.origin.name;
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return "N/A";
            }
        }

        public string GetDestName(FlightDetail flight)
        {
            try
            {
                return flight.airport.destination.name;
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return "N/A";
            }
        }

        public string GetScheDest(FlightDetail flight)
        {
            try
            {
                HelperClass helper = new HelperClass();
                int utctime = flight.time.scheduled.arrival;
                int offset = flight.airport.destination.timezone.offset;
                int total = utctime + offset;
                return helper.GetDateTimeFromEpoch(total).ToString("HH:mm");

            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return "N/A";
            }
        }

        public string GetSSource(FlightDetail flight)
        {
            try
            {
                int utctime = flight.time.scheduled.departure;
                int offset = flight.airport.origin.timezone.offset;
                int total = utctime + offset;
                return helperC.GetDateTimeFromEpoch(total).ToString("HH:mm");

            }
            catch (Exception)
            {
                return "N/A";
            }
        }

        public string GetActual(FlightDetail flight)
        {
            if (flight.time.real.departure != null)
            {
                long utctime = (long)flight.time.real.departure;
                long offset = flight.airport.origin.timezone.offset;
                long total = utctime + offset;
                return helperC.GetDateTimeFromEpoch(total).ToString("HH:mm");
            }
            return GetScheDest(flight);
        }

        public string GetEstimated(FlightDetail flight)
        {
            if (flight.time.estimated.arrival != null)
            {
                long utctime = (long)flight.time.estimated.arrival;
                long offset = flight.airport.destination.timezone.offset;
                long total = utctime + offset;
                return helperC.GetDateTimeFromEpoch(total).ToString("HH:mm");

            }
            return helperC.GetDateTimeFromEpoch(flight.time.scheduled.arrival).ToString("HH:mm");

        }

        public string GetStatusAirplane(FlightDetail flight)
        {
            switch (flight.status.generic.status.text)
            {
                case "scheduled":
                    return "scheduled.png";
                case "landed":
                    return "land.png";
                case "estimated":
                    return "estimated.png";
                case "delayed":
                    return "delayed.png";

            }
            return "takeoff.png";
        }

        public string GetFlightStatus(FlightDetail flight)
        {
            return flight.status.text;
        }

        public string GetSTimezone(FlightDetail flight)
        {
            try
            {
                return flight.airport.origin.timezone.abbr + "(UTC " + flight.airport.origin.timezone.offsetHours + ")";
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return "N/A";
            }
        }

        public string GetDTimezone(FlightDetail flight)
        {
            try
            {
                return flight.airport.origin.timezone.abbr + "(UTC " + flight.airport.destination.timezone.offsetHours + ")";
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                return "N/A";
            }
        }

        #endregion



    }
}




