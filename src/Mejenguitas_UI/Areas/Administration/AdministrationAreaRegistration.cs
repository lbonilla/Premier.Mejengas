using System.Web.Mvc;

namespace Mejenguitas_UI.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("Administration_Jugador", "Administration/Jugador",
                              new { controller = "Jugador", action = "List", id = UrlParameter.Optional });
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new {controller="Juego", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
