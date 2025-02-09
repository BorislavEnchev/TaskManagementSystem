using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem;
using TaskManagementSystem.ViewModels;

public static class ViewModelLocator
{
    public static MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
    public static TaskViewModel TaskViewModel => App.ServiceProvider.GetRequiredService<TaskViewModel>();
    public static CommentViewModel CommentViewModel => App.ServiceProvider.GetRequiredService<CommentViewModel>();
}