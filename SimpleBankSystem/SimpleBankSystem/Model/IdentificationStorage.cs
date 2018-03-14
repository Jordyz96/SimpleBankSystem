using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankSystem.Model
{
    class IdentificationStorage
    {
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

        //ID is recorded with the unique number as the key and the user as the value.
        private Dictionary<string, char> idStorage = new Dictionary<string, char>()
        {

        };

        public void RecordID(string _id)
        {
            string _userIntegerID = "";
            char _userCharID = ' ';

            IDSplitter(_id, ref _userIntegerID, ref _userCharID);

            idStorage.Add(_userIntegerID, _userCharID);
        }

        private void IDSplitter(string _id, ref string _userIntegerID, ref char _userCharID)
        {
            int i = 0;
            foreach(char c in _id)
            {
                if (i < 1)
                    _userCharID = c;
                else
                {
                    _userIntegerID = _userIntegerID + c;
                }
                i++;
            }
        }
    }
}
