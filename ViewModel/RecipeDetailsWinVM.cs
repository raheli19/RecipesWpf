using BL;
using BO.Recipers;
using BO;
using Recipes.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.ViewModel
{
    internal class RecipeDetailsWinVM
    {
        public WinReciperDetails WFD { get; set; }
        BLImp bl = new BLImp();
        public HelperClass helper;

        public ReciperInfoPartial ReciperPartial { get; set; }
        public ReciperDetail Reciper { get; set; }

        public RecipeDetailsWinVM(ReciperInfoPartial fip)
        {
            ReciperPartial = fip;
            Reciper = bl.GetReciperDetail(ReciperPartial.SourceId);

            helper = new HelperClass();
        }
        public string ReciperNumber
        {
            get
            {
                return bl.GetReciperNumber(Reciper);
            }
        }
        public string AirlineCompany
        {
            get
            {
                return bl.GetAirlineCompany(Reciper);
            }
        }
        public string Source
        {
            get
            {
                return bl.GetOrigin(ReciperPartial);
            }
        }
        public string Destination
        {
            get
            {
                return bl.GetDestination(ReciperPartial);
            }
        }
        public string SourceName
        {
            get
            {
                return bl.GetOriginName(Reciper);
            }
        }
        public string DestinationName
        {
            get
            {
                return bl.GetDestName(Reciper);
            }
        }
        public string SDest
        {
            get
            {
                return bl.GetScheDest(Reciper);


            }
        }
        public string SSource
        {
            get
            {
                return bl.GetSSource(Reciper);

            }
        }
        public string Act
        {
            get
            {
                return bl.GetActual(Reciper);

            }
        }
        public string Est
        {
            get
            {
                return bl.GetEstimated(Reciper);

            }
        }
        public string StatusAirplane
        {
            get
            {
                return bl.GetStatusAirplane(Reciper);

            }
        }
        public string ReciperStatus
        {
            get
            {
                return bl.GetReciperStatus(Reciper);

            }
        }

        public string Stimezone
        {
            get
            {
                return bl.GetSTimezone(Reciper);



            }
        }
        public string Dtimezone
        {
            get
            {
                return bl.GetDTimezone(Reciper);


            }
        }
        public int PBValue
        {
            get
            {
                return bl.GetProp(Reciper, ReciperPartial);
            }
        }
        public string PBStatus
        {
            get
            {
                return bl.GetRemainingDistance(Reciper, ReciperPartial).ToString("F1") + " km in " + bl.GetStringRemainingTime(Reciper) + " Left.";
            }
        }

        public string WeatherOrigin
        {
            get
            {
                var result = bl.GetWeather(Reciper, ReciperPartial);
                //This function returns a Dictionary of dictionaries.

                // there are 3 locations: current, origin and destination
                // for each location there are : temperature, main and shortDesc

                // For example, to have the temperature of the destination 
                // it is :
                return result["origin"]["shortDesc"].ToUpper() + " " + result["origin"]["temperature"] + " °C";
            }
        }
        public string WeatherDest
        {
            get
            {
                var result = bl.GetWeather(Reciper, ReciperPartial);
                return result["destination"]["shortDesc"].ToUpper() + " " + result["destination"]["temperature"] + " °C";
            }
        }
        public string WeatherCurrent
        {
            get
            {
                var result = bl.GetWeather(Reciper, ReciperPartial);
                return result["current"]["shortDesc"].ToUpper() + " " + result["current"]["temperature"] + " °C";
            }
        }

    }
}
