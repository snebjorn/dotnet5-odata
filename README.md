# BadRequest is broken
## Code

```cs
[HttpGet]
[EnableQuery]
public IActionResult Get()
{
    return BadRequest("Baddy bad bad!");
}
```

## $filter

http://localhost:5000/odata/foos?$filter=Text eq 'foo'

### Response

```json
{
    "error": {
        "code": "",
        "message": "The query specified in the URI is not valid. Could not find a property named 'Text' on type 'Edm.String'.",
        "details": [],
        "innererror": {
            "message": "Could not find a property named 'Text' on type 'Edm.String'.",
            "type": "Microsoft.OData.ODataException",
            "stacktrace": "   at Microsoft.OData.UriParser.EndPathBinder.GeneratePropertyAccessQueryForOpenType(EndPathToken endPathToken, SingleValueNode parentNode)\r\n   at Microsoft.OData.UriParser.EndPathBinder.BindEndPath(EndPathToken endPathToken)\r\n   at Microsoft.OData.UriParser.MetadataBinder.BindEndPath(EndPathToken endPathToken)\r\n   at Microsoft.OData.UriParser.MetadataBinder.Bind(QueryToken token)\r\n   at Microsoft.OData.UriParser.BinaryOperatorBinder.GetOperandFromToken(BinaryOperatorKind operatorKind, QueryToken queryToken)\r\n   at Microsoft.OData.UriParser.BinaryOperatorBinder.BindBinaryOperator(BinaryOperatorToken binaryOperatorToken)\r\n   at Microsoft.OData.UriParser.MetadataBinder.BindBinaryOperator(BinaryOperatorToken binaryOperatorToken)\r\n   at Microsoft.OData.UriParser.MetadataBinder.Bind(QueryToken token)\r\n   at Microsoft.OData.UriParser.FilterBinder.BindFilter(QueryToken filter)\r\n   at Microsoft.OData.UriParser.ODataQueryOptionParser.ParseFilterImplementation(String filter, ODataUriParserConfiguration configuration, ODataPathInfo odataPathInfo)\r\n   at Microsoft.OData.UriParser.ODataQueryOptionParser.ParseFilter()\r\n   at Microsoft.AspNet.OData.Query.FilterQueryOption.get_FilterClause()\r\n   at Microsoft.AspNet.OData.Query.Validators.FilterQueryValidator.Validate(FilterQueryOption filterQueryOption, ODataValidationSettings settings)\r\n   at Microsoft.AspNet.OData.Query.FilterQueryOption.Validate(ODataValidationSettings validationSettings)\r\n   at Microsoft.AspNet.OData.Query.Validators.ODataQueryValidator.Validate(ODataQueryOptions options, ODataValidationSettings validationSettings)\r\n   at Microsoft.AspNet.OData.Query.ODataQueryOptions.Validate(ODataValidationSettings validationSettings)\r\n   at Microsoft.AspNet.OData.EnableQueryAttribute.ValidateQuery(HttpRequest request, ODataQueryOptions queryOptions)\r\n   at Microsoft.AspNet.OData.EnableQueryAttribute.CreateAndValidateQueryOptions(HttpRequest request, ODataQueryContext queryContext)\r\n   at Microsoft.AspNet.OData.EnableQueryAttribute.<>c__DisplayClass1_0.<OnActionExecuted>b__1(ODataQueryContext queryContext)\r\n   at Microsoft.AspNet.OData.EnableQueryAttribute.ExecuteQuery(Object responseValue, IQueryable singleResultCollection, IWebApiActionDescriptor actionDescriptor, Func`2 modelFunction, IWebApiRequestMessage request, Func`2 createQueryOptionFunction)\r\n   at Microsoft.AspNet.OData.EnableQueryAttribute.OnActionExecuted(Object responseValue, IQueryable singleResultCollection, IWebApiActionDescriptor actionDescriptor, IWebApiRequestMessage request, Func`2 modelFunction, Func`2 createQueryOptionFunction, Action`1 createResponseAction, Action`3 createErrorAction)"
        }
    }
}
```

## $select

http://localhost:5000/odata/foos?$select=id

### Response

```txt
System.ArgumentException: The type 'Edm.String' is not a structured type. Only structured types support $select and $expand.
   at Microsoft.AspNet.OData.Query.SelectExpandQueryOption..ctor(String select, String expand, ODataQueryContext context, ODataQueryOptionParser queryOptionParser)
   at Microsoft.AspNet.OData.Query.ODataQueryOptions.BuildQueryOptions(IDictionary`2 queryParameters)
   at Microsoft.AspNet.OData.Query.ODataQueryOptions.Initialize(ODataQueryContext context)
   at Microsoft.AspNet.OData.Query.ODataQueryOptions..ctor(ODataQueryContext context, HttpRequest request)
   at Microsoft.AspNet.OData.EnableQueryAttribute.CreateAndValidateQueryOptions(HttpRequest request, ODataQueryContext queryContext)
   at Microsoft.AspNet.OData.EnableQueryAttribute.<>c__DisplayClass1_0.<OnActionExecuted>b__1(ODataQueryContext queryContext)
   at Microsoft.AspNet.OData.EnableQueryAttribute.ExecuteQuery(Object responseValue, IQueryable singleResultCollection, IWebApiActionDescriptor actionDescriptor, Func`2 modelFunction, IWebApiRequestMessage request, Func`2 createQueryOptionFunction)
   at Microsoft.AspNet.OData.EnableQueryAttribute.OnActionExecuted(Object responseValue, IQueryable singleResultCollection, IWebApiActionDescriptor actionDescriptor, IWebApiRequestMessage request, Func`2 modelFunction, Func`2 createQueryOptionFunction, Action`1 createResponseAction, Action`3 createErrorAction)
   at Microsoft.AspNet.OData.EnableQueryAttribute.OnActionExecuted(ActionExecutedContext actionExecutedContext)
   at Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|19_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)

HEADERS
=======
Cache-Control: no-cache
Connection: keep-alive
Accept: */*
Accept-Encoding: gzip, deflate, br
Host: localhost:5001
Referer: http://localhost:5000/odata/foos?$select=id
User-Agent: PostmanRuntime/7.26.8
Postman-Token: 60e4b2a7-09ae-4caa-88c2-50ea2a0aaaf2
```
