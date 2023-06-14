using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;

namespace FilesDuplicatesAnalyzer
{
   public class DuplicatesAnalyzer
   {

	  public string[] FindDuplicateFiles(string folderPath, string[] extensions, SearchOption searchOptionType)
	  {
		 Dictionary<string, List<string>> filesByHash = new();
		 HashSet<string> duplicateFiles = new HashSet<string>();
		 List<string> tempDuplicateFiles = new List<string>();

		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " Process Started");

		 foreach(var extension in extensions)
		 {
			string[] files = Directory.GetFiles(folderPath, $"*.{extension}", searchOptionType);

			foreach(var file in files)
			{
			   if(File.Exists(file))
			   {
				  string hash = GetFileHash(file);

				  if(!filesByHash.ContainsKey(hash))
				  {
					 filesByHash[hash] = new List<string>();
				  }
				  else
				  {
					 tempDuplicateFiles.Add(file);
					 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Duplicated file found: {file}");
				  }

				  filesByHash[hash].Add(file);
			   }
			}
		 }

		 duplicateFiles.UnionWith(tempDuplicateFiles); // Agregar los archivos duplicados encontrados a la lista final

		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " ");
		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " Process Finished");

		 return duplicateFiles.ToArray();
	  }


	  private string GetFileHash(string filePath)
	  {
		 using(var sha256 = SHA256.Create())
		 {
			using(var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
			   byte[] hashBytes = sha256.ComputeHash(stream);
			   return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
			}
		 }
	  }
	  public string[] FindDuplicateFilesOld(string folderPath, string[] extensions, SearchOption SearchOptionType)
	  {
		 Dictionary<string, List<string>> filesByHash = new();
		 List<string> duplicateFiles = new();

		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " Process Started");

		 foreach(var extension in extensions)
		 {
			string[] files = Directory.GetFiles(folderPath, $"*.{extension}", SearchOptionType);

			foreach(var file in files)
			{
			   if (File.Exists(file))
			   {
				  string hash = GetFileHash(file);

				  if(!filesByHash.ContainsKey(hash))
				  {
					 filesByHash[hash] = new List<string>();
				  }
				  else
				  {
					 duplicateFiles.AddRange(filesByHash[hash]);
					 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" duplicated file founded: {file}");
				  }

				  filesByHash[hash].Add(file);
			   }
			}
		 }

		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " ");
		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " Process Finished");

		 return duplicateFiles.ToArray();
	  }
	  private string GetFileHashOld(string filePath)
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
