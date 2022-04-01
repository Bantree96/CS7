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

        #region Button Method
        public void Zoom()
        {
            if(IsZoom)
            {
                // Top

                // 확대될 이미지 사이즈
                double ZoomTopImage_width = 1000 * (ZoomPercent / 100);
                double ZoomTopImage_height = 1000 * (ZoomPercent / 100);
                
                Bitmap cropBitmap = new Bitmap(_bitmap);
                // 자를 Bitmap에서 좌표를 구해 그 부분에 새 Bitmap을 만듬
                cropBitmap = cropBitmap.Clone(new Rectangle(50 - (100 / 2), 0 + 150, 150, 150),System.Drawing.Imaging.PixelFormat.DontCare);

                // 이미지의 사이즈를 키웠기 때문에 
                TopImage_Width = 200;
                TopImage_Height = 200;
                TopImage = _converter.BitmapToBitmapImage(cropBitmap);


                // Bottom
                double ZoomBottomImage_width = 1000 * (ZoomPercent / 100);
                double ZoomBottomImage_height = 1000 * (ZoomPercent / 100);

                cropBitmap = new Bitmap(_bitmap);
                // Rectangle은 그릴 좌표를 잡아주는것.
                cropBitmap = cropBitmap.Clone(new Rectangle(50 - (100 / 2), 0 + 150, 150, 150), System.Drawing.Imaging.PixelFormat.DontCare);

                TopImage_Width = 200;
                TopImage_Height = 200;
                TopImage = _converter.BitmapToBitmapImage(cropBitmap);
            }
        }


        #endregion
    }
}
