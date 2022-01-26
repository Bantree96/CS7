using PropertyChanged;
using System;
using System.Drawing;
using System.Windows.Media.Imaging;
using Bitmap_Zoom.Models.Converter;

namespace Bitmap_Zoom.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        #region Field
        private Bitmap _bitmap;
        private Converter _converter;
        #endregion
        #region Property

        /// <summary>
        /// 출력되는 메인이미지
        /// </summary>
        public BitmapImage MainImage { get; set; }
        public BitmapImage TopImage { get; set; }
        public double TopImage_Width { get; set; } = 100;
        public double TopImage_Height { get; set; } = 100;
        public BitmapImage BottomImage { get; set; }
        public BitmapImage LeftImage { get; set; }
        public BitmapImage RightImage { get; set; }

        /// <summary>
        /// 줌 기능 사용할지 판단
        /// </summary>
        public bool IsZoom { get; set; }

        /// <summary>
        /// 줌 배율
        /// </summary>
        public int ZoomPercent { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            _converter = new Converter();

            _bitmap = new Bitmap(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\1.png");
            MainImage = _converter.BitmapToBitmapImage(_bitmap);

            ZoomPercent = 50;
        }
        #endregion

        #region Method
        public void Zoom()
        {
            if(IsZoom)
            {
                double ZoomUpImage_width = 1000 * (ZoomPercent / 100);
                double ZoomUpImage_height = 1000 * (ZoomPercent / 100);
                Bitmap cropBitmap;

                cropBitmap = new Bitmap(_bitmap);
                // Rectangle은 그릴 좌표를 잡아주는것.
                cropBitmap = cropBitmap.Clone(new Rectangle(50 - (100 / 2), 0 + 150, 150, 150),System.Drawing.Imaging.PixelFormat.DontCare);

                TopImage_Width = 200;
                TopImage_Height = 200;
                TopImage = _converter.BitmapToBitmapImage(cropBitmap);
            }
        }
        #endregion
    }
}
