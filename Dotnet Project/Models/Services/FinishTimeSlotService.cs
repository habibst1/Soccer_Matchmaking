// Create a new service (e.g., FinishLobbyService.cs)

using System;
using System.Threading;
using System.Threading.Tasks;
using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class FinishTimeSlotService : IHostedService, IDisposable
{
    private readonly IServiceProvider _provider;
    private Timer _timer;

    public FinishTimeSlotService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1)); // Check every minute
        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using (var scope = _provider.CreateScope())
        {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>(); // Replace YourDbContext with your actual DbContext type
            var timesslots = _context.TimeSlots.Include(l => l.LinkedLobbies);

            foreach(var ts in timesslots)
            {
                if (DateTime.Now > ts.end_time  &&  ts.LinkedLobbies.Count()==0)
                {
                    _context.TimeSlots.Remove(ts);                    
                }
            }

            _context.SaveChanges();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
