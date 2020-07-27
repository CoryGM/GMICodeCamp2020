using System;
using System.Collections.Generic;

namespace CodeCamp2020.Shared.Pages.Pokedex
{
    public class ViewModel : ViewModelBase
    {
        private List<ViewModelEntity> _entities;
        public List<ViewModelEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = new List<ViewModelEntity>();

                return _entities;
            }

            set { _entities = value; }
        }
    }
}
