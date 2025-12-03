using FileStorage.Collections;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Diagnostics;


namespace Gerador_Planilhas
{
  public partial class Form1 : Form
  {
    ListStorageSet<string> players;
    ListStorageSet<string> goalKeepers;
    BindingList<string> playersBinding;
    BindingList<string> goalKeepersBinding;
    public Form1()
    {
      players = new ListStorageSet<string>(AppContext.BaseDirectory, "jogadores.json");
      playersBinding = new BindingList<string>([.. players]);
      playersBinding.ListChanged += (s, e) =>
      {
        players.Clear();
        foreach (string player in playersBinding)
          players.Add(player);
      };

      goalKeepers = new ListStorageSet<string>(AppContext.BaseDirectory, "goleiros.json");
      goalKeepersBinding = new BindingList<string>([.. goalKeepers]);
      goalKeepersBinding.ListChanged += (s, e) =>
      {
        goalKeepers.Clear();
        foreach (string player in goalKeepersBinding)
          goalKeepers.Add(player);
      };
      InitializeComponent();
      LoadDates();
    }

    private void LoadDates()
    {
      maskedTextBox1.Text = DateTime.Now.ToString("yyyy");
      DateTime initialDate = new DateTime(DateTime.Now.Year, 1, 1);
      for (int i = 0; i < 12; i++)
      {
        DateTime actualDate = initialDate.AddMonths(i);
        string monthName = actualDate.ToString("MMMM").ToUpper();
        comboBox1.Items.Add(new { MonthNumber = actualDate.Month, MonthName = monthName });
      }
      comboBox1.SelectedIndex = 0;
      comboBox1.DisplayMember = "MonthName";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      listBox1.DataSource = playersBinding;
      listBox2.DataSource = goalKeepersBinding;
      timer1.Start();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      string playerNames = Interaction.InputBox("Exemplo: Gabriel, Moises", "Digite os nomes:", "");

      if (string.IsNullOrWhiteSpace(playerNames))
        return;

      string[] names = playerNames.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
      foreach (string name in names)
      {
        if (!playersBinding.Contains(name))
          playersBinding.Add(name);
      }

      players.SaveChanges();
    }

    

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      object? selectedMonth = comboBox1.SelectedItem;
      bool enableGenButton = false;

      if (selectedMonth is null)
        enableGenButton = false;
      else if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) || maskedTextBox1.Text.Length < 4 || Convert.ToInt32(maskedTextBox1.Text) > 2099)
        enableGenButton = false;
      else if (playersBinding.Count == 0)
        enableGenButton = false;
      else
        enableGenButton = true;


      button3.Enabled = enableGenButton;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.Description = "Selecione a pasta para salvar a planilha";
      DialogResult result = folderBrowserDialog.ShowDialog();

      if (result != DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
        return;



      ExcelGenerator generator = new ExcelGenerator(playersBinding.ToList(), goalKeepersBinding.ToList(), ((dynamic)comboBox1.SelectedItem).MonthNumber, Convert.ToInt32(maskedTextBox1.Text));
      string pathToSave = Path.Combine(folderBrowserDialog.SelectedPath, $"Planilha_Ganhadores_Pelada_{((dynamic)comboBox1.SelectedItem).MonthName}_{maskedTextBox1.Text}_{DateTime.Now:ddMMyyyymmssfff}.xlsx");
      generator.GenerateExcel(pathToSave);
      DialogResult interactionResult = MessageBox.Show("Planilha gerada com sucesso! Deseja abrir a pasta da planilha?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      if (interactionResult == DialogResult.Yes)
      {
        Process explorerProcess = new Process();
        explorerProcess.StartInfo.FileName = "explorer.exe";
        explorerProcess.StartInfo.Arguments = $"/select,\"{pathToSave}\"";
        explorerProcess.Start();
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      string goalKeepersNames = Interaction.InputBox("Exemplo: Gabriel, Moises", "Digite os nomes:", "");

      if (string.IsNullOrWhiteSpace(goalKeepersNames))
        return;

      string[] names = goalKeepersNames.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
      foreach (string name in names)
      {
        if (!goalKeepersBinding.Contains(name))
          goalKeepersBinding.Add(name);
      }

      goalKeepers.SaveChanges();
    }

    private bool RequestCanDelete(string title, string message)
    {
      DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
      return result == DialogResult.Yes;
    }

    private void button2_Click(object sender, EventArgs e)
    {
  

      List<string> selecteds = [.. listBox1.SelectedItems.Cast<string>()];
      if (selecteds.Count == 0)
        return;

      if (!RequestCanDelete("Atenção", "Deseja Deletar O(s) iten(s) selecionado(s)?"))
        return;

      foreach (string selected in selecteds)
        playersBinding.Remove(selected);

      players.SaveChanges();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      

      List<string> selecteds = [.. listBox2.SelectedItems.Cast<string>()];
      if (selecteds.Count == 0)
        return;

      if (!RequestCanDelete("Atenção", "Deseja Deletar Os itens selecionados?"))
        return;

      foreach (string selected in selecteds)
        goalKeepersBinding.Remove(selected);

      goalKeepers.SaveChanges();
    }
  }
}
