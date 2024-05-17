using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasicDemos
{
    public enum CharacterType
    {
        Elf,
        Ork
    }

    public class Character : INotifyPropertyChanged, IDisposable
    {
        private string _name;
        public CharacterType CharacterType { get; }
        public List<string> Weaponry { get; }

        public Character(CharacterType characterType)
        {
            CharacterType = characterType;
            Weaponry = new List<string>();
        }

        public Character(CharacterType characterType, string name) : this(characterType)
        {
            _name = name;
        }

        public int Armor
        {
            get
            {
                switch (CharacterType)
                {
                    case CharacterType.Elf:
                        return 60;

                    case CharacterType.Ork:
                        return 100;

                    default: throw new ArgumentException();
                }
            }
        }

        public bool IsDead => Health <= 0;

        public double Speed
        {
            get
            {
                switch (CharacterType)
                {
                    case CharacterType.Elf:
                        return 1.7;

                    case CharacterType.Ork:
                        return 1.4;

                    default: throw new ArgumentException();
                }
            }
        }

        public int Wear { get; private set; } = 15;
        public int Health { get; private set; } = 100;
        public int Defense => Wear >= Armor ? 0 : Armor - Wear;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public void ChangeWear(int newWear)
        {
            if (Wear < newWear)
            {
                Wear = newWear;
                OnPropertyChanged(nameof(Wear));
            }
        }

        public void Damage(int damage)
        {
            if (damage > 1000)
                throw new ArgumentOutOfRangeException(nameof(damage));
            Health -= damage - Defense;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name;
        }

        public void Dispose()
        {
        }
    }
}