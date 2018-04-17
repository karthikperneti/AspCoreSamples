<h1>Authorization Filter - Unit Test using nSubstitute</h1>

This is a sample unit test case to test the authorization filter in core application using nSubstitute for mocking. As like any unit test case this test case the following.
<li>Arrange</li>
<li>Act</li>
<li>Assert</li>

<h3>Arrange</h3>
In Arrange, We need to mock the AuthrizationFilterContext. 

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
      
<h3>Act</h3>

Act is simple, Initialize the filter and call the onAuthirization metod.

            filter = new CwsAuthorizationAttribute(contextAccesor);
            filter.OnAuthorization(filterContext);
             
 
 
