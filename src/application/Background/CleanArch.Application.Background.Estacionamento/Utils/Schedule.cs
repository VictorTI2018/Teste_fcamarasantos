using Cronos;

namespace CleanArch.Application.Background.Estacionamento.Utils
{
    public class Schedule
    {
        public static async Task RunAsync(string expression,
            TimeZoneInfo zone,
            CancellationToken cancellationToken)
        {
            var parse = CronExpression.Parse(expression, CronFormat.IncludeSeconds);
            var currentTime = DateTime.UtcNow;
            var ocurrence = parse.GetNextOccurrence(currentTime, zone);

            Console.WriteLine($"Next Schedule: {ocurrence}");

            var delay = ocurrence.Value - currentTime;

            await Task.Delay(delay, cancellationToken);
        }
    }
}
