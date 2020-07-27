using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Components;

namespace CodeCamp2020.Client.Shared
{
    public partial class ErrorList : ComponentBase
    {
        [Parameter]
        public IEnumerable<string> Errors { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
    }
}
