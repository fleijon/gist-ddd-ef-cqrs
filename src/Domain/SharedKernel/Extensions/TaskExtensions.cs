using System;
using System.Threading.Tasks;

namespace SharedKernel
{
    public static class TaskExtensions
    {
        public static async Task<TResult> RunAndCatch<TResult>(this Task<TResult> @task)
        {
            try
            {
                return await task;
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException($"Failed with task. Reason: {ex.Message}", ex);
            }
        }

        public static async Task<TResult> AssertIsNotNull<TResult>(this Task<TResult> @task, string failMessage)
        {
            var result = await task.RunAndCatch();
            if (result == null)
            {
                throw new BusinessRuleException(failMessage);
            }
            return result;
        }
    }
}