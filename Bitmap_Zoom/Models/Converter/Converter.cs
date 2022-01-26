using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Bitmap_Zoom.Models.Converter
{
    public class Converter
    {
        /// <summary>
        /// 비트맵 -> 비트맵이미지 변환
        /// </summary>
        /// <param name="bitmap">변환할 비트맵</param>
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

        /// <summary>
        /// 비트맵이미지 -> 비트맵 변환
        /// </summary>
        /// <param name="bitmapImage">변환할 비트맵 이미지</param>
        /// <returns></returns>
        public Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }
    }
}
