using System.Threading.Tasks;
using Achar.Domain.Testing.Exception;

namespace Achar.Infrastructure.ReqnRoll.Extensions
{
    public class Utils
    {
        public static async Task IfPresentPerformAction(Task task)
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