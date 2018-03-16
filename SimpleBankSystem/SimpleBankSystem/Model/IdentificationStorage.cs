using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankSystem.Model
{
    class IdentificationStorage
    {
        #region Variable Declarations
        private string userIntegerID = "";
        private string id = "";
        private bool idIsUnique = false;

        int firstNumber = 0;
        int secondNumber = 0;
        int thirdNumber = 0;
        int fourthNumber = 0;

        #endregion

        #region Singleton Pattern
        // Singleton Pattern
        private static IdentificationStorage singletonReference = null;
        private IdentificationStorage()
        {

        }

        public static IdentificationStorage getInstance()
        {
            if(singletonReference == null)
            {
                singletonReference = new IdentificationStorage();
            }
            return singletonReference;
        }
        //End Singleton Implementation
        #endregion

        #region Dictionary Declaration
        //ID is recorded with the unique number as the key and the user as the value.
        private Dictionary<string, char> idStorage = new Dictionary<string, char>()
        {

        };
        #endregion

        public string GenerateID(char _userType)
        {
            Random random = new Random();

            do
            {
               firstNumber = random.Next(0, 10);
               secondNumber = random.Next(0, 10);
               thirdNumber = random.Next(0, 10);
               fourthNumber = random.Next(0, 10);

                userIntegerID = firstNumber.ToString() + secondNumber.ToString() +
                    thirdNumber.ToString() + fourthNumber.ToString();

                if (IsIDUnique(userIntegerID))
                {
                    id = _userType + firstNumber.ToString() + secondNumber.ToString() +
                        thirdNumber.ToString() + fourthNumber.ToString();

                    idIsUnique = true;

                    RecordID(userIntegerID, _userType);

                    return id;
                }
            } while (idIsUnique);

            return "";
        }

        private bool IsIDUnique(string _id)
        {
            //Logic to compare _id with the dictionary data structure
            foreach(KeyValuePair<string, char> kvp in idStorage)
            {
                if(kvp.Key.Equals(_id))
                {
                    //ID is NOT unique
                    return false;
                }
            }
            return true;
        }

        private void RecordID(string _userIntegerID, char _userType)
        {
            idStorage.Add(_userIntegerID, _userType);
            //Record these ID's in a database server along with their registered passwords
        }

        public void PrintAllID()
        {
            foreach(KeyValuePair<string, char> kvp in idStorage)
            {
                Console.WriteLine(kvp.Value + kvp.Key);
            }
        }
    }
}
