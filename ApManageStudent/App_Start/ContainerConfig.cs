using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApManageStudent
{
    public class ContainerConfig
    {
        internal static void RegisterContanier()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.
         RegisterType<DA.StudentDataStore>()
        .As<DA.IStudentDataStore>()
        .InstancePerRequest();
            builder.
         RegisterType<DA.CourseDataStore>()
        .As<DA.ICourseDataStore>()
        .InstancePerRequest();

            builder.RegisterType<DA.DataBaseContext>()
        .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}