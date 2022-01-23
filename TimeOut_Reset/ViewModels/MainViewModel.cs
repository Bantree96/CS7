using System.Threading;
using System.Windows;
using System.ComponentModel;

namespace TimeOut_Reset.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Field
        private Thread _workerThread;
        private Thread _timeoutThread;
        private bool _isRunning = false;

        private string _Text;
        #endregion

        #region Property
        public string Text 
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        #endregion

        #region Event
        // 타임아웃을 위한 핸들러
        private EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.ManualReset);

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Constructor
        public MainViewModel()
        {
           

        }
        #endregion

        #region Button Method
        public void Start()
        {
            _isRunning = true;

            _workerThread = new Thread(new ThreadStart(Grab))
            {
                Name = "WorkThread",
                IsBackground = true
            };
            _workerThread.Start();

            _timeoutThread = new Thread(new ThreadStart(TimeOut))
            {
                Name = "TimeOutThread",
                IsBackground = true
            };
            _timeoutThread.Start();
        }

        public void Stop()
        {
            _isRunning = false;
        }
        #endregion
        
        #region Function Method
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                // View 
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Grab()
        {
            while(_isRunning)
            {
                for (int i = 0; i < 1000; i++)
                {
                    //ewh.Set();
                    Text = $"{i}";
                }
            }
        }
        
        public void TimeOut()
        {
            if (!ewh.WaitOne(3000))
            {
                Stop();
                MessageBox.Show("타임아웃!!");
            }
        }

        #endregion

    }
}
