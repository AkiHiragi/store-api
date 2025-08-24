using System.Collections.Generic;

namespace store_api.Common;

public static class SharedData
{
    public static class Roles
    {
        public const string Admin = "admin";
        public const string Consumer = "consumer";

        public static IReadOnlyList<string> AllRoles => new List<string>() { Admin, Consumer };
    }
}