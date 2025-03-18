using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Bitmap_Memory.ViewModels
{
	public class MainWindowViewModel : NotifyBase
	{
		private WriteableBitmap _image;
		private Thread _imageThread;
		public string Title { get; set; } = "Bitmap Memory";
		public WriteableBitmap Image { get => _image; set => SetProperty(ref _image, value); }
		public MainWindowViewModel()
		{
			_imageThread = new Thread(BitmapTest);

		}

		public void Run()
		{
			_imageThread.Start();
		}


		public void BitmapTest()
		{
			Bitmap bitmap = new Bitmap($@"C:\Users\TS_jiwon\Desktop\ABC.bmp");

			while (true)
			{
				Thread.Sleep(1000);

				// Bitmap To Byte
				byte[] array = ConvertBitmapToByteArray(bitmap);
				byte[] imageArray = new byte[array.Length];

				// Byte To IntPtr
				IntPtr ptr = new IntPtr();
				ptr = Marshal.AllocHGlobal(array.Length);

				Marshal.Copy(array, 0, ptr, array.Length);


				Application.Current.Dispatcher.Invoke(() =>
				{
					var image = IntPtrToWriteableBitmap(ptr, bitmap.Width, bitmap.Height, array.Length);
					Image = image;
				});

				Marshal.FreeHGlobal(ptr);
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


		public WriteableBitmap IntPtrToWriteableBitmap(IntPtr ptr, int width, int height, int length)
		{
			var image = new WriteableBitmap(width, height, 96, 96, PixelFormats.Indexed8, BitmapPalettes.Gray256);
			byte[] newArray = new byte[length];

			// WriteableBitmap을 작업하기 위한 메모리 Lock
			image.Lock();

			// Point간 Copy기능이 없어 Ptr을 Array로 Copy
			Marshal.Copy(ptr, newArray, 0, newArray.Length);

			// Array를 image의 BackBuffer로 Copy 
			// 백 버퍼에 변경 내용을 작성한다.
			Marshal.Copy(newArray, 0, image.BackBuffer, newArray.Length);

			// 이게 UI에게 알려줌
			// 변경된 영역을 나타낸다.
			image.AddDirtyRect(new Int32Rect(0, 0, width, height)); 

			// WriteableBitmap작업 마치고 메모리 Unlock
			// 백 버퍼를 해제하고 화면에 프레젠테이션을 허용한다.
			image.Unlock();
			return image;
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
