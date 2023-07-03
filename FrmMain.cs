using System.Diagnostics;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace FilesDuplicatesAnalyzer
{
   public partial class FrmMain : Form
   {
	  private string[] FileExtensions = { "jpg", "png" };
	  public SearchOption SearchOptionType = SearchOption.TopDirectoryOnly;
	  public string[] duplicatedFiles;

	  public FrmMain()
	  {
		 InitializeComponent();
	  }

	  private void Button_Click(object sender, EventArgs e)
	  {
		 try
		 {
			using var fbd = new FolderBrowserDialog();
			DialogResult result = fbd.ShowDialog();
			int counter = 0;

			if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
			{
			   lblFilesInFolderResult.Text = Directory.GetFiles(fbd.SelectedPath, "*.*").Length.ToString();

			   // images
			   DuplicatesAnalyzer analyzer = new();
			   duplicatedFiles = analyzer.AlanyzeImages(fbd.SelectedPath, "jpg", SearchOptionType);

			   // minimos y máximos de toolstrip
			   tspbStatus.Minimum = 0;
			   tspbStatus.Minimum = duplicatedFiles.Length;


			   if(duplicatedFiles.Length >= 1)
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" {duplicatedFiles.Length} files found");

				  // Ajustar automáticamente el ancho de las columnas al contenido
				  dgvDuplicate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

				  // Crear la columna "Número"
				  dgvDuplicate.Columns.Add("NumberColumn", "N°");
				  for(int i = 0; i < duplicatedFiles.Length; i++)
				  {
					 dgvDuplicate.Rows.Add((i + 1).ToString());
				  }

				  // Crear la columna "Nombre Original"
				  dgvDuplicate.Columns.Add("OriginalNameColumn", "Nombre Original");
				  for(int i = 0; i < duplicatedFiles.Length; i++)
				  {
					 string originalName = Path.GetFileName(duplicatedFiles[i].Split('|')[0]);
					 dgvDuplicate.Rows[i].Cells["OriginalNameColumn"].Value = originalName;
				  }

				  // Crear la columna "Imagen Original"
				  dgvDuplicate.Columns.Add("OriginalImageColumn", "Imagen Original");
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

				  // Crear la columna "Nombre Duplicado"
				  dgvDuplicate.Columns.Add("DuplicateNameColumn", "Nombre Duplicado");
				  for(int i = 0; i < duplicatedFiles.Length; i++)
				  {
					 string duplicateName = Path.GetFileName(duplicatedFiles[i].Split('|')[1]);
					 dgvDuplicate.Rows[i].Cells["DuplicateNameColumn"].Value = duplicateName;
				  }

				  // Crear la columna "Imagen Duplicada"
				  dgvDuplicate.Columns.Add("DuplicateImageColumn", "Imagen Duplicada");
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

				  foreach(DataGridViewRow row in dgvDuplicate.Rows)
				  {
					 row.Height = 202;
				  }

				  //// Crear la columna "Seleccione" con checkboxes
				  //dgvDuplicate.Columns.Add("SelectColumn", "Seleccione");
				  //for(int i = 0; i < duplicatedFiles.Length; i++)
				  //{
				  //DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
				  //dgvDuplicate.Rows[i].Cells["SelectColumn"] = cell;
				  //}

				  //// Manejar el evento CellContentClick para almacenar las imágenes duplicadas seleccionadas
				  //List<string> selectedImages = new List<string>();

				  //// Manejar el evento CellValueChanged para almacenar las imágenes duplicadas seleccionadas
				  //dgvDuplicate.CellValueChanged += (sender, e) =>
				  //{
				  //if(e.ColumnIndex == dgvDuplicate.Columns["SelectColumn"].Index && e.RowIndex >= 0)
				  //{
				  //DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvDuplicate.Rows[e.RowIndex].Cells["SelectColumn"];
				  //bool isChecked = (bool)cell.Value;

				  //if(isChecked)
				  //{
				  //   string duplicateImagePath = duplicatedFiles[e.RowIndex].Split('|')[1];
				  //   selectedImages.Add(duplicateImagePath);
				  //}
				  //else
				  //{
				  //   string duplicateImagePath = duplicatedFiles[e.RowIndex].Split('|')[1];
				  //   selectedImages.Remove(duplicateImagePath);
				  //}
				  //}
				  //};

			   }
			   else
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " 0 files found");
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
   }
}