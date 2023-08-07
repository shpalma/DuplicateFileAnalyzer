using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesDuplicatesAnalyzer
{
   public class ManagementLogs
   {
	  string logFolderPath = @"c:\" + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
	  string logFileName = "FilesDuplicatesAnalyzer_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

	  /// <summary>
	  /// Generate log transactions
	  /// </summary>
	  /// <param name="flow_step">What step is doing the process</param>
	  /// <param name="flow_action">What action is doing</param>
	  /// <param name="MustGenerateLog">Determines whether or not to generate a record</param>
	  public void GenerateLog(string flow_step, string flow_action, bool MustGenerateLog)
	  {
		 // If the flag MustgenerateLog is false
		 // it has no generate log transactions 
		 if(!MustGenerateLog)
			return;

		 string logFilePath = Path.Combine(logFolderPath, logFileName);
		 string PreviousContent = string.Empty;

		 string logEntry = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + " " + flow_step + " " + flow_action;

		 try
		 {
			if(!Directory.Exists(logFolderPath))
			{
			   Directory.CreateDirectory(logFolderPath);
			}

			if(File.Exists(logFilePath))
			{ 
			   PreviousContent = File.ReadAllText(logFilePath);
			}

			using(StreamWriter sw = new StreamWriter(logFilePath, true))
			{
			   sw.WriteLine(logEntry);

			   if(string.IsNullOrEmpty(PreviousContent))
			   {
				  sw.WriteLine();
				  sw.WriteLine(PreviousContent);
			   }
			}
		 }
		 catch(Exception ex)
		 {
			// Manejar cualquier excepción que pueda ocurrir al generar el log
			Console.WriteLine("Error al generar el archivo de log: " + ex.Message);
		 }
	  }
   }
}
