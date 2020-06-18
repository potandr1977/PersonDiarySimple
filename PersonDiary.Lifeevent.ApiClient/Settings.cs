namespace PersonDiary.LifeEvent.ApiClient
{
    public static class Settings
    {
        public static string LifeEventMicroServiceUrl { get; } = "http://persondiary.lifeevent.webapi";

        public static string PersonMicroServiceUrl { get; } = "http://persondiary.person.webapi";
    }
}
