using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankSystem.Model
{
    abstract class Person
    {
        public Person(char userType)
        {
            id = GenerateID(userType);
            password = "the password which the user has created";
        }

        private string id;
        private string password;
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string ID
        {
            get { return id; }
        }

        public string GetName()
        {
            return ConcatName(firstName, lastName);
        }

        private string ConcatName(string _firstName, string _lastName)
        {
            string _fullName = firstName + " " + lastName;
            return _fullName;
        }

        protected string GenerateID(char _userType)
        {
            Random random = new Random();

            char _firstCharacter = _userType;
            int _firstNumber = random.Next(0, 10);
            int _secondNumber = random.Next(0, 10);
            int _thirdNumber = random.Next(0, 10);
            int _fourthNumber = random.Next(0, 10);

            string _id = _firstCharacter + _firstNumber.ToString() + _secondNumber.ToString() + 
                _thirdNumber.ToString() + _fourthNumber.ToString();

            return _id;
        }
    }
}
