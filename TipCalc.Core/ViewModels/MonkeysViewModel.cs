
using System.Linq;
using System.Threading.Tasks;

using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class MonkeysViewModel : MvxViewModel<Monkey>
    {
        public IMvxCommand<Monkey> MonkeySelectedCommand { get; private set; }
        private readonly IMvxNavigationService _navigationService;
        private readonly IMonkeyService _monkeyService;
        private MvxObservableCollection<Monkey> myMonkeys;
        private Monkey Selection;
        public MvxObservableCollection<Monkey> Monkeys
        {
            get => myMonkeys;
            set
            {
                myMonkeys = value;
                RaisePropertyChanged(() => Monkeys);

            }
        }
        private MvxObservableCollection<Monkey> myColMonkeys;
        public MvxObservableCollection<Monkey> ColMonkeys
        {
            get => myColMonkeys;
            set
            {
                myColMonkeys = value;
                RaisePropertyChanged(() => ColMonkeys);

            }
        }

        public string SelectedMonkeyMessage { get; private set; }


        public MonkeysViewModel(IMvxNavigationService navigationService, IMonkeyService monkeyService)
        {
            Monkeys = new MvxObservableCollection<Monkey>();
            ColMonkeys = new MvxObservableCollection<Monkey>();
            MonkeySelectedCommand = new MvxAsyncCommand<Monkey>(MonkeySelectedCommandFunction);
            _navigationService = navigationService;
            _monkeyService = monkeyService;
        }

        private async Task MonkeySelectedCommandFunction(Monkey selectedMonkey)
        {
            await _navigationService.Navigate<DaMonkeyDetailsModel, string>(selectedMonkey.Name);
            //Selection = selectedMonkey;
        }

        public override Task Initialize()
        {
            // Async initialization, YEY!
            foreach (var monkey in _monkeyService.GetMonkeys())
            {
                Monkeys.Add(monkey);
                ColMonkeys.Add(monkey);
            }

            return base.Initialize();

        }

        public override void Prepare(Monkey leakyMonkey)
        {
            Selection = leakyMonkey;
        }
    }
}
