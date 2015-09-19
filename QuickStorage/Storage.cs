using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace QuickStorage
{
    class Storage
    {
        private const string storage = "data.json";

        /// <summary>
        /// Deserializes the application json storage
        /// </summary>
        /// <returns>A list of notes</returns>
        private async Task<List<Note>> deserializeJsonAsync()
        {
            List<Note> Notes;
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<Note>));

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(storage);

            Notes = (List<Note>)jsonSerializer.ReadObject(myStream);

            return Notes;
        }

        /// <summary>
        /// Stores a list of notes to the application storage
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        private async Task writeJsonAsync(List<Note> notes)
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Note>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                          storage,
                          CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, notes);
            }
        }
    }
}
