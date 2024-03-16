namespace Lister.Application.Extensions;

public static class DateTimeExtensions
{
    public static string ToDateString(this DateTime? date)
    {
        if (date.HasValue)
        {
            return date.Value.ToShortDateString();
        }

        return "";
    }
}
