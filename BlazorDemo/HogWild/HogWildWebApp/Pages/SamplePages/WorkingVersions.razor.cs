using HogWildSystem.BLL;
using HogWildSystem.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HogWildWebApp.Pages.SamplePages
{
    public partial class WorkingVersions
    {
        [Inject]
        protected WorkingVersionsService WorkingVersionsService { get; set; }

        public WorkingVersionsView? workingVersionsView;// = new();

        //protected override void OnInitialized()
        //{
        //    workingVersionsView = WorkingVersionsService.GetWorkingVersion();
        //}

        protected override Task OnInitializedAsync()
        {
            //workingVersionsView = WorkingVersionsService.GetWorkingVersion();
            return base.OnInitializedAsync();
        }
    }
}
