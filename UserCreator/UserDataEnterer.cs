using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UserCreator.Interfaces;

namespace UserCreator
{
    public class UserDataEnterer : IUserDataEnterer<StreamWriter>
    {
        public static int nextId;

        public async Task WriteDataToCsv(StreamWriter writer, string fieldName, object data)
        {
            await writer.WriteLineAsync($"{GetNextId()},{fieldName},{data}");

            await writer.FlushAsync();
        }

        private int GetNextId()
        {
            Interlocked.Increment(ref nextId);

            return nextId;
        }
    }
}