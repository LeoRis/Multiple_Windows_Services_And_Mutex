using System;

namespace WindowsService
{
    public class User
    {
        public static string UserFirstName { get; set; }
        public static string UserLastName { get; set; }
        public int UserAge { get; set; }

        public User(string fname, string lname, int age)
        {
            UserFirstName = fname;
            UserLastName = lname;
            UserAge = age;
        }

        public static string PrintUserFirstName()
        {
            return UserFirstName;
        }

        public static string PrintUserLastName()
        {
            return UserLastName;
        }
    }
}
