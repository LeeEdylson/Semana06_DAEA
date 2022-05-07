using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Business;
using Semana05.Model;

namespace Semana05.ViewModel
{
    public class ManCategoriaViewModel:ViewModelBase
    {
        #region propiedades
        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if(_ID!=value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
