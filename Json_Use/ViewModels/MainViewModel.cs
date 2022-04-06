
using Json_Use.Models;
using PropertyChanged;

namespace Json_Use.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        #region Field
        #endregion

        #region Property
        public string SavePath { get; set; }
        #endregion
        #region Constructor
        public MainViewModel()
        {
            DFS_JsonControll json = new DFS_JsonControll();
        }
        #endregion

       
    }


}
