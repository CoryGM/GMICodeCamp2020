using System;
using System.Collections.Generic;

namespace CodeCamp2020.Shared.Pages
{
    public abstract class ViewModelBase
    {
        private List<string> _errors = new List<string>();

        public List<string> Errors 
        {
            get 
            {
                if (_errors == null)
                    _errors = new List<string>();

                return _errors; 
            } 

            set { _errors = value; }
        }

        public void AddError(string errorText)
        {
            Errors.Add(errorText);
        }
    }
}
