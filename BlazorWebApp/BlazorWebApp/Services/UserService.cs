using BlazorWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<UserService> _logger;

    public UserService(
        IServiceScopeFactory serviceScopeFactory,
        IHttpContextAccessor httpContextAccessor,
        ILogger<UserService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    private T GetService<T>()
    {
        var scope = _serviceScopeFactory.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }

    public async Task<ApplicationUser> GetCurrentUserAsync()
    {
        try
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userManager = GetService<UserManager<ApplicationUser>>();
            return await userManager.GetUserAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting the current user.");
            throw;
        }
    }

    public async Task<string> GetUserNameAsync(ApplicationUser user)
    {
        try
        {
            var userManager = GetService<UserManager<ApplicationUser>>();
            return await userManager.GetUserNameAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting the user name.");
            throw;
        }
    }

    public async Task<string> GetPhoneNumberAsync(ApplicationUser user)
    {
        try
        {
            var userManager = GetService<UserManager<ApplicationUser>>();
            return await userManager.GetPhoneNumberAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting the phone number.");
            throw;
        }
    }

    public async Task<IdentityResult> SetPhoneNumberAsync(ApplicationUser user, string phoneNumber)
    {
        try
        {
            var userManager = GetService<UserManager<ApplicationUser>>();
            return await userManager.SetPhoneNumberAsync(user, phoneNumber);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while setting the phone number.");
            throw;
        }
    }

    public async Task UpdateUserAsync(ApplicationUser user)
    {
        try
        {
            var contextFactory = GetService<IDbContextFactory<ApplicationDbContext>>();
            await using var context = contextFactory.CreateDbContext();
            context.Update(user);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating the user.");
            throw;
        }
    }

    public async Task RefreshSignInAsync(ApplicationUser user)
    {
        try
        {
            var signInManager = GetService<SignInManager<ApplicationUser>>();
            await signInManager.RefreshSignInAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while refreshing the sign-in.");
            throw;
        }
    }

    public void SignOut()
    {
        try
        {
            var signInManager = GetService<SignInManager<ApplicationUser>>();
            signInManager.SignOutAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while signing out.");
            throw;
        }
    }
}