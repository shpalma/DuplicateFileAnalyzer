using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;

namespace FilesDuplicatesAnalyzer
{
   public class DuplicatesAnalyzer
   {
	  public string[] FindDuplicateFiles(string folderPath, string[] extensions, SearchOption SearchOptionType)
	  {
		 Dictionary<string, List<string>> filesByHash = new();
		 List<string> duplicateFiles = new();

		 Debug.WriteLine("Process Started");
		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss"));

		 foreach(var extension in extensions)
		 {
			string[] files = Directory.GetFiles(folderPath, $"*.{extension}", SearchOptionType);

			foreach(var file in files)
			{
			   if (File.Exists(file))
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + string.Empty + file);
				  string hash = GetFileHash(file);

				  if(!filesByHash.ContainsKey(hash))
				  {
					 filesByHash[hash] = new List<string>();
				  }
				  else
				  {
					 duplicateFiles.AddRange(filesByHash[hash]);
				  }

				  filesByHash[hash].Add(file);
			   }
			}
		 }

		 Debug.WriteLine("Process Finished");
		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss"));

		 return duplicateFiles.ToArray();
	  }

	  private string GetFileHash(string filePath)
	  {
		 using(var md5 = MD5.Create())
		 {
			using(var stream = File.OpenRead(filePath))
			{
			   byte[] hashBytes = md5.ComputeHash(stream);
			   return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
			}
		 }
	  }
   }
}
