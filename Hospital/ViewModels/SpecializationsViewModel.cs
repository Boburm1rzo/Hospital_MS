using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class SpecializationsViewModel : BaseViewModel
    {
        private readonly SpecializationsService _specializationsService;
        private string _searcheText;
        public string SearchText
        {
            get => _searcheText;
            set
            {
                SetProperty(ref _searcheText, value);
                SearchSpecializations(value);
            }
        }
        public ObservableCollection<Specialization> Specializations { get; }
        public ICommand AddCommand { get; }
        public SpecializationsViewModel()
        {
            _specializationsService = new SpecializationsService();
            Specializations = new ObservableCollection<Specialization>();
            AddCommand = new Command(OnAdd);
            Load();

        }
        public void Load()
        {
            var specializations = _specializationsService.GetAll();
            Specializations.Clear();
            foreach (var specialization in specializations)
            {
                Specializations.Add(specialization);
            }
        }
        public void SearchSpecializations(string SearchText)
        {
            var specializations = _specializationsService.GetAll(SearchText);
            Specializations.Clear();
            foreach (var specialization in specializations)
            {
                Specializations.Add(specialization);
            }
        }
        public void OnAdd()
        {
            var dialog = new SpecializationDialog();
            dialog.ShowDialog();
        }

    }
}
