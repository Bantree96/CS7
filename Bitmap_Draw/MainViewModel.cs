using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bitmap_Draw
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Biding
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private string _txt;
        private Bitmap _bitmap;
        private BitmapImage _displayImage;
        private BitmapSource _sourceImage;

        public string Txt { get { return _txt; } set { _txt = value; OnPropertyChanged(nameof(Txt)); } }
        public Bitmap MyBitmap { get { return _bitmap; } set { _bitmap = value; OnPropertyChanged(nameof(MyBitmap)); } }
        public BitmapImage DisplayImage { get { return _displayImage; } set { _displayImage = value; OnPropertyChanged(nameof(DisplayImage)); } }
        public BitmapSource SourceImage { get { return _sourceImage; } set { _sourceImage = value; OnPropertyChanged(nameof(SourceImage)); } }
        public MainViewModel()
        {
            // 로컬 이미지 가져오기 
            MyBitmap = new Bitmap("D://hello.bmp");

            // 이미지를 따로 가져감
            RenderTargetBitmap rtb = new RenderTargetBitmap(MyBitmap.Width, MyBitmap.Height, 96d, 96d, PixelFormats.Pbgra32);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.DrawRoundedRectangle(System.Windows.Media.Brushes.Transparent, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Red,10), new System.Windows.Rect(100, 100, 100, 100), 0, 0);
                dc.Close();
                rtb.Render(dv);
                if (rtb.IsFrozen)
                    rtb.Freeze();
            }

            SourceImage = rtb;


            // 이미지 바인딩 출력
            DisplayImage = BitmapToBitmapImage(MyBitmap.Clone() as Bitmap);

            // 이미지 합성 
            /*
            Bitmap bitmap = new Bitmap(_grabImage.Width, _grabImage.Height);

            Pen redPen = new Pen(System.Drawing.Brushes.Red, 10);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(_grabImage, 0, 0, _grabImage.Width, _grabImage.Height);
                g.DrawRectangle(redPen, new Rectangle(_grabImage.Width / 2, _grabImage.Height / 2, 100, 100));
            }
            bitmap.Save("D://hello.bmp");
            LabelImage = BitmapToBitmapImage(bitmap.Clone() as Bitmap);
            redPen.Dispose();
            bitmap.Dispose();
             */

        }

        /// <summary>
        /// 바인딩 출력을 위한 Bitmap -> BitmapImage 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            bitmap = (bitmap as Bitmap);
            BitmapImage bitmapImage = new BitmapImage();        // 새 비트맵 이미지 객체 생성
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);               // 메모리 스트림에 bitmap을 Bmp로 저장한다.
                stream.Position = 0;                                // 스트림 포지션 0으로 설정해 처음부터 잡음
                bitmapImage.BeginInit();                            // 비트맵 이미지 초기화
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // 비트맵 이미지가 다 생성되야 stream 닫게 캐시 설정
                bitmapImage.StreamSource = stream;                  // 
                bitmapImage.EndInit();                              // 비트맵 이미지 초기화 종료    
            }
            bitmapImage.Freeze(); // 이미지 변경 안할꺼다. 바인딩 하기위해서는 필수!!!!
            return bitmapImage;
        }
    }
}
