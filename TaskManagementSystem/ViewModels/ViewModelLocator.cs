using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem;
using TaskManagementSystem.ViewModels;

public static class ViewModelLocator
{
    public static MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
}