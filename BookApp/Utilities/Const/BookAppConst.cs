using System;
using System.Text.RegularExpressions;

namespace BookApp.Utilities.Const
{
    public static class BookAppConst
    {

        public const string sqliteDatabaseName = "BookApp.db3";

        public static bool IsInvalidEmail(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;

            Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");
            return RegEmail.IsMatch(inputData);
        }
    }

    public class NavigationTo
    {
        public const string LoginPage = "LoginPage";
        public const string RegisterPage = "RegisterPage";
        public const string ResetPage = "ResetPage";
        public const string HomePage = "HomePage";

    }
}