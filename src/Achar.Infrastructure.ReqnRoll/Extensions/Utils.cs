using System.Threading.Tasks;
using Achar.Domain.Testing.Exception;

namespace Achar.Infrastructure.ReqnRoll.Extensions
{
    public static class Utils
    {
        public static async Task IgnoreIfNotFound(this Task task)
        {
            try
            {
                await task;
            }
            catch (ElementNotFoundException)
            {
            }
            catch (ElementNotVisibleException)
            {
            }
        }
    }
}