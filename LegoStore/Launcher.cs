using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LegoStoreApi;

class Launcher
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); // requires Microsoft.AspNetCore.App
        /* https://blog.stackademic.com/understanding-webapplication-createbuilder-args-in-asp-net-core-2bd63c76f438
         * builder allows to:
         *  - add Dependencies, Services, Components to app
         *  - add and modify middleware
         *  - app settings such as: connectionString, authentication providers, logging settings
         */

        builder.Services.AddControllers();
        /* From my understanding:
         *  - registers definitions of each class that extends Controller / ControllerBase classes
         *  - By default, on every API request creates instance of specific controller class which dies after request is fully finished
         *  - provides services ( things like [HttpGet], [Route], json stuff, and other things commonly used.
         */

        var app = builder
            .Build(); // application including configurations added to previous WebApplicationBuilder

        app.MapControllers(); // creates end-points for mine Controllers 

        app.Run(); // keeps app-thread running and listens for upcoming requests
    }
}