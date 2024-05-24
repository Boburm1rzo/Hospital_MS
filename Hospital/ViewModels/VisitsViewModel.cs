using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class VisitsViewModel : BaseViewModel
    {
        private readonly VisitsService _visitsService;
        public ObservableCollection<Visit> Visits { get; }
        public ICommand AddCommand { get; }
        public VisitsViewModel()
        {
            _visitsService = new VisitsService();
            Visits = new ObservableCollection<Visit>();
            AddCommand = new Command(OnAdd);
            Load();
        }
        public void Load()
        {
            var visits = _visitsService.GetVisits();
            Visits.Clear();
            foreach (Visit visit in visits)
            {
                Visits.Add(visit);
            }
        }
        public void OnAdd()
        {
            var dialog = new VisitsDialog();
            dialog.ShowDialog();
        }
    }
}
