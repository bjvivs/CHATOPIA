using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHATOPIA.ViewModels
{
    class MessageEntryViewModel
    {
        // member variable
        private string _Message;

        /// <summary>
        /// contains the text to be sent 
        /// </summary>
        /// property becaues it doesn't have a parameter list (not a function) and it can return a value
        public string Message
        {
            get { return _Message; }
            set 
            {
                _Message = value;
            }
        }
        // method
        public void Send() {

            _Message = String.Empty;
        }
    }
}
