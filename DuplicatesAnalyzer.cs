using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace FilesDuplicatesAnalyzer
{
   public class DuplicatesAnalyzer
   {
	  public string[] AlanyzeImages(string pathFiles, string fileTypes, SearchOption searchOptionType)
	  {
		 int top = 0;
		 int counter = 0;
		 int fileSize = 0;

		 top = 200;

		 try
		 {
			if(!Directory.Exists(pathFiles))
			{
			   Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" selected folder doesn't exist!  {pathFiles}");
			   throw new DirectoryNotFoundException("Selected folder doesn't exist");
			}

			List<string> result = new();

			Dictionary<string, string> fileHashes = new();

			string[] files;

			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "******************************************");
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "* Process Started");
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "******************************************");

			if(!string.IsNullOrEmpty(fileTypes))
			{
			   string[] fileExtensions = fileTypes.Split(',');
			   List<string> filteredFiles = new List<string>();

			   foreach(string extension in fileExtensions)
			   {
				  filteredFiles.AddRange(Directory.GetFiles(pathFiles, "*." + extension.Trim(), searchOptionType));
			   }

			   files = filteredFiles.ToArray();
			}
			else
			{
			   files = Directory.GetFiles(pathFiles, "*.*", searchOptionType);
			}

			foreach(string file in files)
			{
			   if(counter >= top)
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" :::! proccess has reached the top: {file}");
				  break;
			   }

			   if(!File.Exists(file))
			   {
				  // El archivo no existe, se omite su procesamiento
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" :::! file doesn't exist: {file}");
				  continue;
			   }

			   fileSize = (int)new FileInfo(file).Length;

			   // if file is les than xxx, then is not considered
			   if(fileSize <= 512)
			   {
				  // El archivo no existe, se omite su procesamiento
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" :::! small file size {fileSize} (jumped)!");
				  continue;
			   }

			   string fileHash = CalculateFileHash(file);

			   if(fileHashes.ContainsValue(fileHash))
			   {
				  string originalFile = fileHashes.FirstOrDefault(x => x.Value == fileHash).Key;
				  result.Add(originalFile + " | " + file);

				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" ::: Original: {originalFile} | Duplicated: {file}");
				  counter += 1;
			   }
			   else
			   {
				  fileHashes.Add(file, fileHash);
			   }
			}
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "******************************************");
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "* Process Finished");
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "******************************************");

			return result.ToArray();
		 }
		 catch(UnauthorizedAccessException ex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Exception(ux): {ex.Message}");
			throw new UnauthorizedAccessException("Not possible to read one or more files in selected folder!", ex);
		 }
		 catch(Exception ex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Exception(ex): {ex.Message}");
			throw new Exception($"Huston: we have a problem! AlanyzeImages - {ex}");
		 }
	  }

	  private string CalculateFileHash(string filePath)
	  {
		 using(var sha256 = SHA256.Create())
		 {
			try
			{
			   using(var stream = File.OpenRead(filePath))
			   {
				  byte[] hashBytes = sha256.ComputeHash(stream);
				  return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
			   }
			}
			catch(Exception ex)
			{
			   Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Exception(ex): {ex.Message}");
			   throw new Exception($"Huston: we have a problem! CalculateFileHash - {filePath} | {ex}");
			}
		 }
	  }

	  public string[] FindDuplicateFiles(string folderPath, string[] extensions, SearchOption searchOptionType)
	  {
		 Dictionary<string, List<string>> filesByHash = new();
		 HashSet<string> duplicateFiles = new();
		 List<string> tempDuplicateFiles = new();
		 List<string> duplicateFilesAndHush = new();

		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " Process Started");

		 foreach(var extension in extensions)
		 {
			string[] files = Directory.GetFiles(folderPath, $"*.{extension}", searchOptionType);

			foreach(var file in files)
			{
			   if(File.Exists(file))
			   {
				  string hash = GetFileHash(file);
				  duplicateFilesAndHush.Add(file + " " + hash);
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" {file + " " + hash}");

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
	  public string[] FindDuplicateFilesV01(string folderPath, string[] extensions, SearchOption SearchOptionType)
	  {
		 Dictionary<string, List<string>> filesByHash = new();
		 List<string> duplicateFiles = new();

		 Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " Process Started");

		 foreach(var extension in extensions)
		 {
			string[] files = Directory.GetFiles(folderPath, $"*.{extension}", SearchOptionType);

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
	  private string GetFileHashV01(string filePath)
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
