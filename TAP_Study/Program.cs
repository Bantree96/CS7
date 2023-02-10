using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// TAP : Task-Based Asynchronous Pattern
/// </summary>
namespace TAP_Study
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // Async 키워드를 사용하거나 사용하지 않고 TAP를 구현할 수 있다.

        // Task를 수동으로 관리해야한다.
        public Task<int> OperationName1Async(int param)
        {
            return Task.FromResult(1);
        }

        // async await를 통해 Task를 자동으로 관리한다.
        public async Task<int> OperationName2Async(int param)
        {
            return 1;
        }

        // Task의 이점은 언제든지 작업을 취소할 수 있다는것이다.
        public void TaskCancel()
        {
            var cancelToken = new CancellationTokenSource();
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(3000, cancelToken.Token);
                // API call
            }, cancelToken.Token);

            // Stops the task
            cancelToken.Cancel(false);
        }
    }
}
