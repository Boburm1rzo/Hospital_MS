using Hospital.Services;
using Hospital.Views.Dialogs;
using HospitalManagementSystem.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace Hospital.ViewModels
{
    public class PatientsViewModel : BaseViewModel
    {
        private readonly PatientsService _patientsService;
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                ApplyFilters();
            }
        }
        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set => SetProperty(ref _selectedPatient, value);
        }
        public ObservableCollection<Patient> Patients { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand FirstPageCommand { get; }
        public ICommand SecondPageCommand { get; }
        public ICommand ThirdPageCommand { get; }
        public ICommand FirstPageSizeCommand { get; }
        public ICommand SecondPageSizeCommand { get; }
        public ICommand ThirdPageSizeCommand { get; }
        public PatientsViewModel()
        {
            _patientsService = new PatientsService();
            Patients = new ObservableCollection<Patient>();

            AddCommand = new Command(OnAdd);
            EditCommand = new Command(OnEdit);
            DeleteCommand = new Command<Patient>(OnDelete);
            ShowDetailsCommand = new Command(OnShowDetails);

            PreviousPageCommand = new Command(OnPreviousPage);
            FirstPageCommand = new Command(OnFirstPage);
            SecondPageCommand = new Command(OnSecondPage);
            ThirdPageCommand = new Command(OnThirdPage);
            NextPageCommand = new Command(OnNextPage);

            FirstPageSizeCommand = new Command(OnFirstPageSize);
            SecondPageSizeCommand = new Command(OnSecondPageSize);
            ThirdPageSizeCommand = new Command(OnThirdPageSize);

            Load();
        }
        #region Pagination
        private int _totalPatientsCount;
        public int TotalPatientsCount
        {
            get => _totalPatientsCount;
            set => SetProperty(ref _totalPatientsCount, value);
        }
        private int pagesCount;
        private int pageSize = 15;
        private int _currentPage = 1;
        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                SetProperty(ref _currentPage, value);
                HasNextPage = CurrentPage < pagesCount;
                HasPreviousPage = CurrentPage > 3;
            }
        }
        private int _firstButtonContent = 1;
        public int FirstButtonContent
        {
            get => _firstButtonContent;
            set => SetProperty(ref _firstButtonContent, value);
        }

        private int _secondButtonContent = 2;
        public int SecondButtonContent
        {
            get => _secondButtonContent;
            set => SetProperty(ref _secondButtonContent, value);
        }

        private int _thirdButtonContent = 3;
        public int ThirdButtonContent
        {
            get => _thirdButtonContent;
            set => SetProperty(ref _thirdButtonContent, value);
        }

        private bool _isFirstPageSelected = true;
        public bool IsFirstPageSelected
        {
            get => _isFirstPageSelected;
            set => SetProperty(ref _isFirstPageSelected, value);
        }

        private bool _isSecondPageSelected = false;
        public bool IsSecondPageSelected
        {
            get => _isSecondPageSelected;
            set => SetProperty(ref _isSecondPageSelected, value);
        }

        private bool _isThirdPageSelected = false;
        public bool IsThirdPageSelected
        {
            get => _isThirdPageSelected;
            set => SetProperty(ref _isThirdPageSelected, value);
        }

        private bool _isFirstSizeSelected = true;
        public bool IsFirstSizeSelected
        {
            get => _isFirstSizeSelected;
            set => SetProperty(ref _isFirstSizeSelected, value);
        }

        private bool _isSecondSizeSelected = false;
        public bool IsSecondSizeSelected
        {
            get => _isSecondSizeSelected;
            set => SetProperty(ref _isSecondSizeSelected, value);
        }

        private bool _isThirdSizeSelected = true;
        public bool IsThirdSizeSelected
        {
            get => _isThirdSizeSelected;
            set => SetProperty(ref _isThirdSizeSelected, value);
        }

        private bool _hasFirstPage;
        public bool HasFirstPage
        {
            get => _hasFirstPage;
            set => SetProperty(ref _hasFirstPage, value);
        }

        private bool _hasSecondPage;
        public bool HasSecondPage
        {
            get => _hasSecondPage;
            set => SetProperty(ref _hasSecondPage, value);
        }

        private bool _hasThirdPage;
        public bool HasThirdPage
        {
            get => _hasThirdPage;
            set => SetProperty(ref _hasThirdPage, value);
        }

        private bool _hasNextPage;
        public bool HasNextPage
        {
            get => _hasNextPage;
            set => SetProperty(ref _hasNextPage, value);
        }

        private bool _hasPreviousPage = false;
        public bool HasPreviousPage
        {
            get => _hasPreviousPage;
            set => SetProperty(ref _hasPreviousPage, value);
        }
        private void OnPreviousPage()
        {
            if (_currentPage < 1)
                return;

            CurrentPage -= 3;
            FirstButtonContent -= 3;
            SecondButtonContent -= 3;
            ThirdButtonContent -= 3;
        }
        private void OnFirstPage()
        {
            IsFirstPageSelected = true;
            IsSecondPageSelected=false;
            IsThirdPageSelected=false;

            CurrentPage=FirstButtonContent;
            ApplyFilters();
        }
        private void OnSecondPage()
        {
            IsFirstPageSelected = true;
            IsSecondPageSelected = false;
            IsThirdPageSelected = false;
         
            CurrentPage=SecondButtonContent;
            ApplyFilters();
        }
        private void OnThirdPage()
        {
            IsFirstPageSelected = true;
            IsSecondPageSelected = false;
            IsThirdPageSelected = false;
            
            CurrentPage=ThirdButtonContent;
            ApplyFilters();
        }
        private void OnNextPage()
        {
            if (_currentPage > pagesCount)
            {
                return;
            }

            FirstButtonContent += 3;
            SecondButtonContent += 3;
            ThirdButtonContent += 3;

            HasSecondPage = pagesCount > SecondButtonContent;
            HasThirdPage = pagesCount > ThirdButtonContent;

            IsFirstPageSelected = true;
            IsSecondPageSelected = false;
            IsThirdPageSelected = false;
            CurrentPage = FirstButtonContent;
            ApplyFilters();
        }
        private void OnFirstPageSize()
        {
            IsFirstSizeSelected = true;
            IsSecondSizeSelected = false;
            IsThirdSizeSelected = false;
            pageSize = 15;
            pagesCount = (int)Math.Ceiling((double)_totalPatientsCount / pageSize);

            ApplyFilters();
        }
        private void OnSecondPageSize()
        {
            IsFirstSizeSelected = false;
            IsSecondSizeSelected = true;
            IsThirdSizeSelected = false;

            pageSize = 20;
            pagesCount = (int)Math.Ceiling((double)_totalPatientsCount / pageSize);

            ApplyFilters();
        }
        private void OnThirdPageSize()
        {
            IsFirstSizeSelected = false;
            IsSecondSizeSelected = false;
            IsThirdSizeSelected = true;

            pageSize = 50;
            pagesCount = (int)Math.Ceiling((double)_totalPatientsCount / pageSize);

            ApplyFilters();
        }

        #endregion
        public void Load()
        {
            var patients = _patientsService.GetPatients();
            _totalPatientsCount = _patientsService.GetTotalCount();
            pagesCount = (int)Math.Ceiling((double)_totalPatientsCount / pageSize);

            HasNextPage = pagesCount > 3;
            HasSecondPage = pagesCount > 1;
            HasFirstPage = pagesCount > 0;
            HasThirdPage = pagesCount > 2;

            foreach (var patient in patients)
            {
                Patients.Add(patient);
            }
        }
        public void ApplyFilters()
        {
            var patients = _patientsService.GetPatients(SearchText, CurrentPage, pageSize);
            Patients.Clear();
            foreach (var patient in patients)
            {
                Patients.Add(patient);
            }
        }
        public void OnAdd()
        {
            var dialog = new PatientsDialog();
            dialog.ShowDialog();
        }
        public void OnEdit()
        {
            var dialog = new PatientsUpdateDialog(SelectedPatient);
            dialog.ShowDialog();
        }
        public void OnDelete(Patient patient)
        {
            var result = MessageBox.Show($"Are you sure you want to delete:{patient.LastName} {patient.FirstName}?",
                "Confirm your action",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            _patientsService.Delete(patient);
            MessageBox.Show(
               $"Patient: {patient.FirstName} {patient.LastName} successfully deleted.",
               "Success",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
        }
        public void OnShowDetails()
        {
            if (SelectedPatient is null)
                return;

            var dialog = new PatientsDetailsDialog(SelectedPatient);
            dialog.ShowDialog();
        }

    }
}
