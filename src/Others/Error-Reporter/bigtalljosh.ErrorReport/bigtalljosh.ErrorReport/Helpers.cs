using System.Runtime.CompilerServices;

namespace bigtalljosh.ErrorReport
{
    public static class Helpers
    {
        public static string GetCaller([CallerMemberName] string caller = null) => caller;
    }
}
