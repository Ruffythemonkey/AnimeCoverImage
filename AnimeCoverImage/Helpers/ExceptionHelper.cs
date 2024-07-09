namespace AnimeCoverImage.Helpers
{
    public static class ExceptionHelper
    {
        public static bool ThrowsException(Action action)
        {
            try
            {
                action();
                return false; // Keine Ausnahme geworfen
            }
            catch
            {
                return true; // Ausnahme geworfen
            }
        }
    }
}
