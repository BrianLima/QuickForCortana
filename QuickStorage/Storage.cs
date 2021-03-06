﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace QuickStorage
{
    public class Storage
    {
        private const string storage = "data.json";

        /// <summary>
        /// Deserializes the application json storage
        /// </summary>
        /// <returns>A list of notes</returns>
        public async Task<ObservableCollection<Note>> deserializeJsonAsync()
        {
            if (!File.Exists(ApplicationData.Current.LocalFolder.Path + @"\" + storage))
            {
                ObservableCollection<Note> SampleNotes = new ObservableCollection<Note>()
                {
                    new Note { Content = "Parked my car at sesame street", Date = DateTime.Now },
                    new Note { Content = "I have to buy milk next", Date = DateTime.Now },
                    new Note { Content = "Remind my friends to download this app", Date = DateTime.Now }
                };

                await writeJsonAsync(SampleNotes);
            }

            ObservableCollection<Note> Notes;
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Note>));

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(storage);

            Notes = (ObservableCollection<Note>)jsonSerializer.ReadObject(myStream);

            return Notes;
        }

        /// <summary>
        /// Stores a list of notes to the application storage
        /// </summary>
        /// <param name="notes"></param>
        public async Task writeJsonAsync(ObservableCollection<Note> Notes)
        {
            if (Notes == null)
                return;

            var serializer = new DataContractJsonSerializer(typeof(List<Note>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(storage, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, Notes);
            }
        }
    }
}