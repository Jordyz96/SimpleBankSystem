using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankSystem.Model
{
    class IdentificationStorage
    {
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
            string _userIntegerID = "";
            string _id = "";
            bool _idIsUnique = false;

            int _firstNumber = 0;
            int _secondNumber = 0;
            int _thirdNumber = 0;
            int _fourthNumber = 0;

            Random random = new Random();

            do
            {
               _firstNumber = random.Next(0, 10);
               _secondNumber = random.Next(0, 10);
               _thirdNumber = random.Next(0, 10);
               _fourthNumber = random.Next(0, 10);

                _userIntegerID = _firstNumber.ToString() + _secondNumber.ToString() +
                    _thirdNumber.ToString() + _fourthNumber.ToString();

                if (IsIDUnique(_userIntegerID))
                {
                    _id = _userType + _firstNumber.ToString() + _secondNumber.ToString() +
                        _thirdNumber.ToString() + _fourthNumber.ToString();

                    _idIsUnique = true;

                    RecordID(_userIntegerID, _userType);

                    return _id;
                }
            } while (_idIsUnique);

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
        }
    }
}
