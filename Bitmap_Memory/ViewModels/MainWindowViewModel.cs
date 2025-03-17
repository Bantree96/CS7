using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Bitmap_Memory.ViewModels
{
	public class MainWindowViewModel : NotifyBase
	{
		private BitmapImage _image;
		public string Title { get; set; } = "Bitmap Memory";
		public BitmapImage Image { get => _image; set => SetProperty(ref _image, value); }
		public MainWindowViewModel()
		{
		}


		public void BitmapTest()
		{
			Bitmap bitmap = new Bitmap($@"C:\Users\TS_jiwon\Desktop\ABC.bmp");

			while (true)
			{
				byte[] array = ConvertBitmapToByteArray(bitmap);
				byte[] imageArray = new byte[array.Length];

				// Byte To IntPtr
				IntPtr ptr = new IntPtr();
				ptr = Marshal.AllocHGlobal(array.Length);

				Marshal.Copy(array, 0, ptr, array.Length);

				Marshal.Copy(ptr, imageArray, 0, array.Length);

				var bmp = ByteToBitmap(imageArray, bitmap.Width, bitmap.Height);

				Image = Bitmap2BitmapImage(bmp);

				Marshal.FreeHGlobal(ptr);
			}
		}

		/// <summary>
		/// Bitmap을 BitmapImage로 변환합니다.
		/// </summary>
		/// <param name="bitmap"></param>
		/// <returns></returns>
		public static BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
		{
			// 새 비트맵 이미지 객체 생성
			BitmapImage bitmapimage = new BitmapImage();
			// 메모리 스트림을 사용한다.
			using (MemoryStream stream = new MemoryStream())
			{

				bitmap.Save(stream, ImageFormat.Bmp);                   // 메모리 스트림에 bitmap을 Bmp로 저장한다.
				stream.Position = 0;                                    // 스트림 포지션 0으로 설정해 처음부터 잡는다.
				bitmapimage.BeginInit();                                // 비트맵 이미지 초기화
				bitmapimage.CacheOption = BitmapCacheOption.OnLoad;     // 비트맵 캐시옵셥 : 이미지가 다 생성되야 stream 닫게설정
				bitmapimage.StreamSource = stream;                      // 스트림소스에 스트림 내용을 집어 넣는다.
				bitmapimage.EndInit();                                  // 비트맵 이미지 초기화 종료
				bitmapimage.Freeze();                                   // 이미지 변경을 더 이상 하지 않는다고 선언(바인딩 권한 위해 필수)
				bitmap.Dispose();                                       // 필요 없으면 Dispose해

				return bitmapimage;
			}
		}

		public byte[] ConvertBitmapToByteArray(Bitmap bitmap)
		{
			// Bitmap 데이터의 사양을 가져오기 위해 BitmapData를 사용
			BitmapData bitmapData = bitmap.LockBits(
				new Rectangle(0, 0, bitmap.Width, bitmap.Height),
				ImageLockMode.ReadOnly,
				bitmap.PixelFormat);

			// 필요한 바이트 수 계산
			int bytes = Math.Abs(bitmapData.Stride) * bitmap.Height;
			byte[] byteArray = new byte[bytes];

			// Bitmap 데이터의 첫 번째 바이트 주소 가져오기
			IntPtr ptr = bitmapData.Scan0;

			// 바이트 배열로 데이터 복사
			Marshal.Copy(ptr, byteArray, 0, bytes);

			// Bitmap의 잠금 해제
			bitmap.UnlockBits(bitmapData);

			return byteArray;
		}

		/// <summary>
		/// Byte배열을 Bitmap으로 변환합니다.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns></returns>
		public static Bitmap ByteToBitmap(byte[] data, int width, int height)
		{
			// 여기에서 높이, 너비 및 형식을 알고있는 비트 맵을 만듭니다. 
			Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

			// BitmapData 생성 및 기록 될 모든 픽셀을 GC가 수집할 수 없도록 잠금 
			BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

			// 포인트 사용한다고 정의 하며 마샬 메모리 등록
			IntPtr unmanagedPointer = Marshal.AllocHGlobal(data.Length);

			// 바이트 배열의 데이터를 BitmapData로 복사합니다.
			Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
			// 마샬 메모리 해제
			Marshal.FreeHGlobal(unmanagedPointer);
			// 픽셀 잠금 해제 
			bmp.UnlockBits(bmpData);

			return bmp;
		}
	}

	public abstract class NotifyBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChaned([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (!Equals(field, value))
			{
				field = value;
				OnPropertyChaned(propertyName);
			}
		}
	}
}
