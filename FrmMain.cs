using System.Diagnostics;

namespace FilesDuplicatesAnalyzer
{
   public partial class FrmMain : Form
   {
	  private string[] FileExtensions = { "jpg", "png" };
	  public SearchOption SearchOptionType = SearchOption.TopDirectoryOnly;
	  public string[] duplicatedFiles;
	  private DuplicatesAnalyzer analyzer;

	  public FrmMain()
	  {
		 InitializeComponent();
	  }

	  private void Button_Click(object sender, EventArgs e)
	  {
		 try
		 {

			int AmountOfFiles = 0;

			// max and min to set into toolstrip
			tspbStatus.Minimum = 0;
			tspbStatus.Minimum = 100;

			using var fbd = new FolderBrowserDialog();
			DialogResult result = fbd.ShowDialog();

			if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
			{

			   AmountOfFiles = Directory.GetFiles(fbd.SelectedPath).Length;

			   analyzer = new DuplicatesAnalyzer();

			   //tspbStatus.Step = 5;

			   // What file type is going to analyze?
			   duplicatedFiles = analyzer.AlanyzeImages(fbd.SelectedPath, "jpg", SearchOptionType);

			   //tspbStatus.Step = 35;

			   if(duplicatedFiles.Length >= 1)
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" {duplicatedFiles.Length} files found");

				  //tspbStatus.Step = 40;
				  // Automatic adjustment of column widths to content
				  dgvDuplicate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

				  //tspbStatus.Step = 45;
				  // Create column "N°"
				  dgvDuplicate.Columns.Add("NumberColumn", "N°");
				  for(int i = 0; i < duplicatedFiles.Length; i++)
				  {
					 dgvDuplicate.Rows.Add((i + 1).ToString());
				  }

				  //tspbStatus.Step = 50;
				  // Create column "Original Name"
				  dgvDuplicate.Columns.Add("OriginalNameColumn", "Original Name");
				  for(int i = 0; i < duplicatedFiles.Length; i++)
				  {
					 string originalName = Path.GetFileName(duplicatedFiles[i].Split('|')[0]);
					 dgvDuplicate.Rows[i].Cells["OriginalNameColumn"].Value = originalName;
				  }

				  //tspbStatus.Step = 55;
				  // Create column "Original Image"
				  dgvDuplicate.Columns.Add("OriginalImageColumn", "Original Image");
				  for(int i = 0; i < duplicatedFiles.Length; i++)
				  {
					 string originalImagePath = duplicatedFiles[i].Split('|')[0];
					 Image resizedImage = GetResizedImage(originalImagePath.Trim(), 120, 150);
					 if(resizedImage != null)
					 {
						DataGridViewImageCell cell = new DataGridViewImageCell();
						cell.Value = resizedImage;
						dgvDuplicate.Rows[i].Cells["OriginalImageColumn"] = cell;
					 }
				  }

				  //tspbStatus.Step = 60;
				  // Create column "Duplicated Name"
				  dgvDuplicate.Columns.Add("DuplicateNameColumn", "Duplicate Name");
				  for(int i = 0; i < duplicatedFiles.Length; i++)
				  {
					 string duplicateName = Path.GetFileName(duplicatedFiles[i].Split('|')[1]);
					 dgvDuplicate.Rows[i].Cells["DuplicateNameColumn"].Value = duplicateName;
				  }

				  //tspbStatus.Step = 65;
				  // Create column "Duplicated image"
				  dgvDuplicate.Columns.Add("DuplicateImageColumn", "Duplicate image");
				  for(int i = 0; i < duplicatedFiles.Length; i++)
				  {
					 string duplicateImagePath = duplicatedFiles[i].Split('|')[1];
					 Image resizedImage = GetResizedImage(duplicateImagePath.Trim(), 120, 150);
					 if(resizedImage != null)
					 {
						DataGridViewImageCell cell = new DataGridViewImageCell();
						cell.Value = resizedImage;
						dgvDuplicate.Rows[i].Cells["DuplicateImageColumn"] = cell;
					 }
				  }

				  //tspbStatus.Step = 70;
				  // Resize all cells
				  foreach(DataGridViewRow row in dgvDuplicate.Rows)
				  {
					 row.Height = 202;
				  }

				  //tspbStatus.Step = 100;
				  lblFilesInFolderResult.Text = AmountOfFiles.ToString();
				  lblDuplicatedFilesResult.Text = duplicatedFiles.Length.ToString();
			   }
			   else
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " 0 files found");
				  MessageBox.Show("Does not exist duplicated files on selected folder!", "Everything is just fine!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			   }
			}
		 }
		 catch(FormatException fex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $"Button_Click: FormatException  {fex.Message}");
		 }
		 catch(Exception ex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $"Button_Click: Exception  {ex.Message}");
		 }
	  }

	  private Image GetResizedImage(string imagePath, int width, int height)
	  {
		 try
		 {
			using(Image originalImage = Image.FromFile(imagePath))
			{
			   Bitmap resizedImage = new Bitmap(width, height);
			   using(Graphics graphics = Graphics.FromImage(resizedImage))
			   {
				  graphics.DrawImage(originalImage, 0, 0, width, height);
			   }
			   return resizedImage;
			}
		 }
		 catch(Exception ex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $"GetResizedImage: Error al redimensionar la imagen ({ex.Message})");
			return null;
		 }
	  }

	  private void chkbSubFolders_CheckedChanged(object sender, EventArgs e)
	  {
		 if(chkbSubFolders.Checked)
			SearchOptionType = SearchOption.AllDirectories;
		 else
			SearchOptionType = SearchOption.TopDirectoryOnly;
	  }

	  private void btnDDuplicated_Click(object sender, EventArgs e)
	  {
		 try
		 {
			char parentesisLeft = '(';
			char parentesisRight = ')';
			char underline = '_';
			int counter = 0;

			DialogResult dialogResult = MessageBox.Show("Are we going to delete duplicated files?", "Just do it!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

			if(dialogResult == DialogResult.OK)
			{
			   foreach(string fileToDelete in duplicatedFiles)
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" fileToDelete: {fileToDelete}");
				  string[] DuplicatedFile = fileToDelete.Split("|");

				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" 0: {DuplicatedFile[0]}");
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" 1: {DuplicatedFile[1]}");

				  if(DuplicatedFile[0].Contains(parentesisLeft) && DuplicatedFile[0].Contains(parentesisRight))
				  {
					 if(File.Exists(DuplicatedFile[0].Trim()))
					 {
						File.Delete(DuplicatedFile[0].Trim());
						counter += 1;

						Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" File  {DuplicatedFile[0]} deleted");
					 }
				  }
				  else
				  {
					 if(File.Exists(DuplicatedFile[1].Trim()))
					 {
						File.Delete(DuplicatedFile[1].Trim());
						counter += 1;

						Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" File  {DuplicatedFile[1]} deleted");
					 }
				  }
			   }

			   if(counter == 1)
			   {
				  MessageBox.Show("Does not exist duplicated files on selected folder!", "Everything is just fine!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			   }
			   else
			   {
				  MessageBox.Show($"{counter} files deleted!", "Everything is just fine!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			   }
			}
			else
			{
			   Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " User has canceled the operation");
			}
		 }
		 catch(Exception ex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Exception: {ex.Message}");
		 }
	  }
   }
}