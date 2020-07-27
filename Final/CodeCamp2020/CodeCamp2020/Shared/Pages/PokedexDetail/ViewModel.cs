using System;

namespace CodeCamp2020.Shared.Pages.PokedexDetail
{
    public class ViewModel : ViewModelBase
    {
        private ViewModelEntity _entity;

        public ViewModelEntity Entity
        {
            get
            {
                if (_entity == null)
                    _entity = new ViewModelEntity();

                return _entity;
            }

            set { _entity = value; }
        }
    }
}
