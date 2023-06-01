using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BitmapAndSource
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BitmapTest();
        }

        private void BitmapTest()
        {
            Bitmap bitmap = new Bitmap($@"C:\Users\TS_jiwon\Desktop\캡처.PNG");

            BitmapSource bitmapsource = GetBitmapSourceFromBitmap(bitmap);
            BitmapImage bitmapImage = Bitmap2BitmapImage(bitmap);

            //bitmap.Dispose();

            MainImage.Source = bitmapImage;
        }

        private BitmapSource GetBitmapSourceFromBitmap(System.Drawing.Bitmap bitmap)
        {
            BitmapSource bitmapSource;

            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();
            bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
            bitmapSource.Freeze();

            return bitmapSource;
        }

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            // 새 비트맵 이미지 객체 생성
            BitmapImage bitmapimage = new BitmapImage();
            // 메모리 스트림을 사용한다.
            using (MemoryStream stream = new MemoryStream())
            {
                // 메모리 스트림에 bitmap을 Bmp로 저장한다.
                bitmap.Save(stream, ImageFormat.Bmp);
                // 스트림 포지션 0으로 설정해 처음부터 잡는다.
                stream.Position = 0;
                // 비트맵 이미지 초기화
                bitmapimage.BeginInit();
                // 비트맵 캐시옵셥 : 이미지가 다 생성되야 stream 닫게설정
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                // 스트림소스에 스트림 내용을 집어 넣는다.
                bitmapimage.StreamSource = stream;
                // 비트맵 이미지 초기화 종료
                bitmapimage.EndInit();
                // 이미지 변경을 더 이상 하지 않는다고 선언(바인딩 권한 위해 필수)
                bitmapimage.Freeze();

                bitmap.Dispose();
                
                return bitmapimage;
            }
        }
    }
}
