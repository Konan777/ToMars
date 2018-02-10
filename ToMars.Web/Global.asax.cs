using System;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using ToMars.WEB.Infrastructure;
using AutoMapper;
using ToMars.Model;
using ToMars.Model.Models;
using ToMars.Model.Context;
using ToMars.Model.Entities;
using ToMars.Web.Controllers;


namespace ToMars.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            RegisterBundles(BundleTable.Bundles);
            RegisterGlobalFilters(GlobalFilters.Filters);
            DependencyResolver.SetResolver(new NinjectDependencyResolver());
            MapperBootstrap();
            SetUpDatabase();
        }

        private void SetUpDatabase()
        {
            var facade = DependencyResolver.Current.GetService<IGeneralFacade>();
            var sett = facade.Settings;
            sett.Restore();
            if (sett.Databases.Count == 0) {
                var db = new MSSQL_Database() {
                    Name = "MSSQL",
                    ConnectionString =
                        //@"Data Source=AMUR-GO-220\SQLEXPRESS;initial catalog=Books;integrated security=True;Connect Timeout=5"
                        "Data Source=KONAN-PC;initial catalog=Books;integrated security=True;Connect Timeout=5"
                };
                sett.Databases.Add(db);
                sett.SelectedDatabase = db;
            }

        }

        private void MapperBootstrap()
        {
            // Настройка AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<Anketa, AnketaModel>());
        }

        protected void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleExceptionAttribute());
            
        }

        protected void RegisterBundles(BundleCollection bundles)
        {
            // http://go.microsoft.com/fwlink/?LinkId=301862
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/jquery-ui-{version}.js")
                .Include("~/Scripts/jquery.mask.js")
                .Include("~/Scripts/jquery.signalR-2.2.2.js")
                .Include("~/Scripts/tomars.js")
            );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*")
            );

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/themes/base/jquery-ui.css")
                .Include("~/Content/bootstrap.css", "~/Content/site.css")
            );
        }

        protected void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{fileId}/{page}/{column}",
                defaults: new
                {
                    controller = "Home", action = "Index",
                    fileId = UrlParameter.Optional,
                    page = UrlParameter.Optional,
                    column = UrlParameter.Optional
                }
            );
        }

    }

    public class HandleExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // Определимся с источником ошибки
            var controller = " ";
            var action = " ";
            var currentRouteData = RouteTable.Routes.GetRouteData(filterContext.HttpContext);
            if (currentRouteData != null) {
                if (currentRouteData.Values["controller"] != null && !string.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                    controller = currentRouteData.Values["controller"].ToString();

                if (currentRouteData.Values["action"] != null && !string.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                    action = currentRouteData.Values["action"].ToString();
            }

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                //var facade = DependencyResolver.Current.GetService<IGeneralFacade>();
                //facade.GetLogger().Log(filterContext.Exception.StackTrace.Replace("\r\n", "~").Split('~').FirstOrDefault());
                // Ajax call
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        Controller = controller,
                        Action = action,
                        Message = filterContext.Exception.StackTrace.Replace("\r\n","~").Split('~').FirstOrDefault()
                    }
                };
                filterContext.ExceptionHandled = true;
            }
            else
            {
                //base.OnException(filterContext);
                var routeAction = "GenericError";

                // Сформируем RouteData
                var routeData = new RouteData();
                routeData.Values["controller"] = "Error";
                routeData.Values["action"] = routeAction;
                routeData.Values["exception"] = new HandleErrorInfo(filterContext.Exception, controller, action);

                // Чистим
                filterContext.HttpContext.ClearError();
                filterContext.HttpContext.Response.Clear();

                // Редирект на ErrorController
                IController errCtrl = new ErrorController();
                var rc = new RequestContext(filterContext.HttpContext, routeData);
                errCtrl.Execute(rc);
            }

        }
    }
}
