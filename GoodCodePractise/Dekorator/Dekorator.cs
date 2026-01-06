using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Dekorator
{
   class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public User(string name, string surname, int age, double height)
        {
            Name = name;
            Surname = surname;
            Age = age;  
            Height = height;

        }
        public User()
        {
            
        }

    }
    class RegisteredUsers
    {
        protected List<User> users = new List<User>
        {
            new User("Jan", "Kowalski", 34, 1.87),
            new User("Norbert", "Nowal", 40, 1.56),
            new User("Janina", "Ratajczak", 28, 1.76),
            new User("Ewelina", "Bryk", 24, 1.85),
        }; 
        public List<User> Users {
            get
            {
                return users;
            }
            set
            {
                users = value;
            }
        }
        public RegisteredUsers()
        {
            
        }
    }
    class SprawdzUsera:RegisteredUsers
    {
        public bool CzyIstnieje(User user)
        {
            foreach (var usr in users)
            {
                if (usr.Name == user.Name && usr.Surname == user.Surname && usr.Height == user.Height && usr.Age == user.Age)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
