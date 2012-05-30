using System;
using Microsoft.Phone.Tasks;
using System.Windows;
using System.IO;
using RingtoneSaver.Infrastructure.Common;
using System.IO.IsolatedStorage;

namespace RingtoneSaver.Infrastructure.Media
{
	public static class MediaService
	{
        private const string AUDIO_FILES_FOLDER = "/Audio";

		private static IAudioPlayer audioPlayer;

		public static void Init(IAudioPlayer audioPlayer)
		{
			MediaService.audioPlayer = audioPlayer;
		}

		public static void PlayAudio(Uri uri)
		{
			audioPlayer.PlayAudio(uri);
		}

        public static void SaveRingtone(Uri uri)
        {
            var isoStoreUri = TruncateTo1MbAndSave(uri);
            SaveRingtoneTask task = new SaveRingtoneTask();
            task.Completed += task_Completed;
            task.IsShareable = true;
            task.Source = isoStoreUri;
            task.Show();
        }

        static void task_Completed(object sender, TaskEventArgs e)
        {
            MessageBox.Show(e.TaskResult.ToString());
        }

        private static Uri TruncateTo1MbAndSave(Uri uri)
        {
            var isoStorage = IsolatedStorageFile.GetUserStoreForApplication();
            
            if (false == isoStorage.DirectoryExists(AUDIO_FILES_FOLDER))
                isoStorage.CreateDirectory(AUDIO_FILES_FOLDER);

            string fileName = FileNameResolver.GetFileNameWithExtensionFromUri(uri);
            string filePath = AUDIO_FILES_FOLDER + "/" + fileName;

            if (isoStorage.FileExists(filePath))
                isoStorage.DeleteFile(filePath);

            Uri relativeUri = new Uri(uri.AbsolutePath.Substring(1), UriKind.Relative);
            using (var inFile = App.GetResourceStream(relativeUri).Stream)
            {
                using (var outFile = isoStorage.CreateFile(filePath))
                {
                    byte[] buffer = new byte[8192];
                    int bytesReadOverall = 0;
                    int bytesRead = 0;
                    long megaByte = 1024 * 1000;
                    inFile.Seek(inFile.Length - megaByte - 1024 * 100, SeekOrigin.Begin);
                    while ((bytesRead = inFile.Read(buffer, 0, buffer.Length)) > 0 && (bytesReadOverall += bytesRead) <= megaByte)
                    {
                        outFile.Write(buffer, 0, bytesRead);
                    }
                }
            }

            return new Uri("isostore:" + filePath, UriKind.Absolute); 
        }
    }
}
