namespace clean.api.Middleweres
{
    public class SaturdayMidellewere
    {

        private readonly RequestDelegate _requestDelegate;

        public SaturdayMidellewere(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }   
        public async Task InvokeAsync(HttpContext context)
        {
            var now = DateTime.UtcNow;

            var friday= new DateTime(now.Year,now.Month,now.Day,16,0,0,DateTimeKind.Utc);
            var saturday = new DateTime(now.Year, now.Month, now.Day, 20, 0, 0, DateTimeKind.Utc);

            if (now.DayOfWeek== DayOfWeek.Friday && now >=friday|| now.DayOfWeek == DayOfWeek.Friday && now <= saturday)
            {

                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("לא ניתן לבצע בקשות בשבת");
                return;
            }
            await _requestDelegate(context);

        }
    }
}
