namespace GameOfLife
{
    public class BoardPoint : ViewModelBase
    {
        public BoardPoint()
        {
            ToggleCommand = new RelayCommand(Flip, x=> true); 
        }

        bool _isAlive;

        public bool IsAlive
        {
            get { return _isAlive; }
            private set
            {
                _isAlive = value;
                NotifyPropertyChanged(() => IsAlive);
            }
        }

        private void Flip(object o)
        {
            IsAlive = !IsAlive;
        }

        public RelayCommand ToggleCommand { get; private set; }
    }
}