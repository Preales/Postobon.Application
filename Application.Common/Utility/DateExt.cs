namespace Application.Common.Utility
{
    public static class DateExt
    {
        public static DateTime getDate()
        {
            return DateTime.Now;
        }

        public static string getDateTime(DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToString("dd/MM/yyyy HH:mm:ss");

            return "";
        }

        public static string getDateTimeCode()
        {
            return DateTime.Now.ToString("ddMMyyyyHHmmss");
        }

        public static string ToFormatDate(this DateTime value)
        {
            return value.ToString("dd/MM/yyyy");
        }
    }
}
