using Microsoft.Extensions.Hosting;
using VY.Business.Layer.Auth.Static.Auth;

namespace VY.Business.Layer.Auth.Worker
{
    public class MailVerifyWorker : BackgroundService
    {
        
        
        protected override  async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(TimeSpan.FromMinutes(2));
            while (true)
            {
                
                MailVerify.removeRangeVerify(DateTime.Now.AddHours(6));
                await Task.Delay(TimeSpan.FromMinutes(6));
            }
        }
    }
}
