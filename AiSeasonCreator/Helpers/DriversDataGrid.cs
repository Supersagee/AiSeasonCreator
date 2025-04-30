using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Helpers
{
    public class DriversDataGrid : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public string Driver { get; set; }
        public int DriverNumber { get; set; }
        public Image CarLogo { get; set; }
        public string CarName { get; set; }

        private int _relativeSkill;
        public int RelativeSkill
        {
            get => _relativeSkill;
            set
            {
                if (_relativeSkill != value)
                {
                    _relativeSkill = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _aggression;
        public int Aggression
        {
            get => _aggression;
            set
            {
                if (_aggression != value)
                {
                    _aggression = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _optimism;
        public int Optimism
        {
            get => _optimism;
            set
            {
                if (_optimism != value)
                {
                    _optimism = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _smoothness;
        public int Smoothness
        {
            get => _smoothness;
            set
            {
                if (_smoothness != value)
                {
                    _smoothness = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _pitCrewSkill;
        public int PitCrewSkill
        {
            get => _pitCrewSkill;
            set
            {
                if (_pitCrewSkill != value)
                {
                    _pitCrewSkill = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _pitStrat;
        public int PitStrat
        {
            get => _pitStrat;
            set
            {
                if (_pitStrat != value)
                {
                    _pitStrat = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
