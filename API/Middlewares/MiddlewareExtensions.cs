namespace E_Commerce.API.Middlewares;

public static class MiddlewareExtensions
{
    public static void UseApplicationMiddleware(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}
