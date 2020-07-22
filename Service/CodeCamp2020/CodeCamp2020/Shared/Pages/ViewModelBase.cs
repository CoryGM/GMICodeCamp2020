using System;
using System.Collections.Generic;

namespace CodeCamp2020.Shared.Pages
{
    public abstract class ViewModelBase
    {
        private readonly List<string> _errors = new List<string>();

        public string[] Errors 
        {
            get { return _errors.ToArray(); } 
        }

        public void AddError(string errorText)
        {
            _errors.Add(errorText);
        }
    }
}
