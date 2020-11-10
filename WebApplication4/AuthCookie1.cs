namespace WebApplication4
{
    public class AuthCookie
    {
        public static bool isLogin(string cookieName)
        {
            bool flag = false;
            string isCookie = CookieHelper.GetCookieValue(cookieName);
            if (!string.IsNullOrEmpty(isCookie))
            {
                flag = true;
            }
            return flag;
        }
    }
}