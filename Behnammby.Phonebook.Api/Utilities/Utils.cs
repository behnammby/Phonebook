using System;
using Behnammby.Phonebook.Api.Enumerations;

namespace Behnammby.Phonebook.Api.Utilities
{
    public static class Utils
    {
        public static int ResolveTotalPages(int total, int limit) => (int)Math.Ceiling(((float)total) / limit);
        public static int ResolveStatusCode(RestHttpStatusCodes statusCode) => (int)statusCode;
    }
}