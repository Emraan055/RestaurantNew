﻿using System.Web.Mvc;

namespace Restaurant.Areas.Receptor
{
    public class ReceptorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Receptor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Receptor_default",
                "Receptor/{controller}/{action}/{id}",
                new {controller="Receipts", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}