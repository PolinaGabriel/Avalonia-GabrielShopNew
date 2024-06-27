using System.Collections.Generic;

namespace GabrielShop
{
    public static class Group
    {
        public static List<User> users = new List<User>() {
            new User()
            {
               log = "",
               pass = "",
               role = 0
            },
            new User()
            {
               log = "admin",
               pass = "admin",
               role = 1
            },
            new User()
            {
               log = "user",
               pass = "user",
               role = 2
            }
        };

    }
}
