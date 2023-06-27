using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;

namespace FilesDuplicatesAnalyzer
{
   public class DuplicatesAnalyzer
   {

	  public string[] AlanyzeImages(string pathFiles, string fileTypes, SearchOption searchOptionType)
	  {
		 if(!Directory.Exists(pathFiles))
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" directorio especificado no existe: {pathFiles}");
			throw new DirectoryNotFoundException("El directorio especificado no existe.");
		 }

		 List<string> result = new();

		 Dictionary<string, string> fileHashes = new();

		 try
		 {
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
			   if(!File.Exists(file))
			   {
				  // El archivo no existe, se omite su procesamiento
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" :::! archivo no existe: {file}");
				  continue;
			   }

			   string fileHash = CalculateFileHash(file);

			   if(fileHashes.ContainsValue(fileHash))
			   {
				  string originalFile = fileHashes.FirstOrDefault(x => x.Value == fileHash).Key;
				  result.Add(originalFile + " | " + file);

				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" ::: Original: {originalFile} | Duplicado: {file}");
			   }
			   else
			   {
				  fileHashes.Add(file, fileHash);
			   }
			}
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "******************************************");
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "* Process Finished");
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "******************************************");
		 }
		 catch(UnauthorizedAccessException ex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Exception(ux): {ex.Message}");
			throw new UnauthorizedAccessException("No se tiene acceso para leer uno o más archivos en el directorio especificado.", ex);
		 }
		 catch(Exception ex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Exception(ex): {ex.Message}");
			throw new Exception("Ocurrió un error al analizar las imágenes.", ex);
		 }

		 return result.ToArray();
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
			   throw new Exception("Ocurrió un error al calcular el hash del archivo: " + filePath, ex);
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
				  duplicateFilesAndHush.Add(file + " " +  hash);
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
