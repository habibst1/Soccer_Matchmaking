// Create a new service (e.g., FinishLobbyService.cs)

using System;
using System.Threading;
using System.Threading.Tasks;
using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class FinishLobbyService : IHostedService, IDisposable
{
    private readonly IServiceProvider _provider;
    private Timer _timer;

    public FinishLobbyService(IServiceProvider provider)
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
            var lobbies = _context.Lobbies.Include(a => a.admin).Include(t => t.TimeSlot).Include(p => p.Players);

            foreach (var lobby in lobbies)
            {
                if (lobby.TimeSlot != null && DateTime.Now >= lobby.TimeSlot.end_time && !lobby.IsFinished)
                {
                    lobby.finishLobby();

                    if (!lobby.IsFull)
                    {
                        var linkedLobbiesCopy = new List<Lobby>(lobby.TimeSlot.LinkedLobbies);

                        for (int i = 0; i < linkedLobbiesCopy.Count; i++)
                        {
                            Lobby otherlobby = linkedLobbiesCopy[i];

                            if (otherlobby != lobby)
                            {
                                var linkedPlayers = _context.Users.Where(p => p.LinkedLobbyId == otherlobby.Id).ToList();

                                foreach (var player in linkedPlayers)
                                {
                                    player.LinkedLobbyId = null;
                                    otherlobby.admin = null;
                                }

                                lobby.TimeSlot.LinkedLobbies.Remove(otherlobby);
                                _context.Lobbies.Remove(otherlobby);
                            }

                        }
                        var ts = lobby.TimeSlot;
                        lobby.TimeSlot.LinkedLobbies.Remove(lobby);
                        lobby.admin = null;
                        _context.TimeSlots.Remove(ts);
                        _context.Lobbies.Remove(lobby);
                    }
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
