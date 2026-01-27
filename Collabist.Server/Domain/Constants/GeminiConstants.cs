namespace Collabist.Server.Domain.Constants
{
    /*GeminiConstants
        Purpose
            Stores Gemini API related constants.
        Responsibilities
            Centralizes model and endpoint configuration
        Notes
            API key must never be hardcoded
        TODO
            Add support for multiple Gemini models
     */

    public static class GeminiConstants
    {
        public const string Model = "gemma-3-27b-it";
        public const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models";
    }
}
