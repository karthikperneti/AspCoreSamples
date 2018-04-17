using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using NSubstitute;
using Cat.Terra.Common.CwsAuthorization;
namespace CoreUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        CwsAuthorizationAttribute filter;
        [TestMethod]
        public void TestMethod1()
        {
            
            //ARRANGE 
            
            var httpContext = new DefaultHttpContext();
            var context = new ActionExecutingContext(
                new ActionContext
                {
                    HttpContext = httpContext ,
                    
                    RouteData = new RouteData(),
                    ActionDescriptor = new ActionDescriptor(),

                },
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                Substitute.For<Controller>());

            var contextAccesor = Substitute.For<HttpContextAccessor>();          
            contextAccesor.HttpContext = httpContext;
            var filterContext = Substitute.For<AuthorizationFilterContext>(context, new List<IFilterMetadata>() );
            filterContext.HttpContext.Request.Headers.Add("AuthorizationToken", "ahjhasfjfasdjjdajsd");
           
            //ACT
            filter = new CwsAuthorizationAttribute(contextAccesor);
            filter.OnAuthorization(filterContext);

            //ASSERT
            Assert.AreEqual("", "");

        }
    }
}
