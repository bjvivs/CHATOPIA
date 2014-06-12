using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHATOPIA.CLI
{
    class Something : INotifyPropertyChanged
    {
        // member variable
        string _Description;

        //  property
        public string Description
        {
            // read
            get { return _Description; }

            // write
            set
            {
                _Description = value;
                Console.WriteLine("Descripton updated to: '{0}'", value);
                FirePropertyChanged("Description");
            }
        }

        private void FirePropertyChanged(string p)
        {
            var h = PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(p));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Something();
            s.PropertyChanged += s_PropertyChanged;
            s.Description = "The Description is this ";

            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }

        static void s_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("Field {0} on object of type {1} changed.", e.PropertyName, sender.GetType().FullName);
        }
    }
}
