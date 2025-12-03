using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_Planilhas
{
  internal class ExcelGenerator
  {

    public ExcelGenerator(List<string> players, List<string> goalKeepers, int month, int year)
    {
      Players = players;
      GoalKeepers = goalKeepers;
      Month = month;
      Year = year;
    }

    public List<string> Players { get; }
    public List<string> GoalKeepers { get; }
    public int Month { get; }
    public int Year { get; }

    private void PreConfigure(int row, string headerName, ExcelWorksheet worksheet)
    {
      worksheet.Cells[row, 1].Value = headerName;
      DateTime date = new DateTime(Year, Month, 1);

      List<DateTime> tuesdays = [];
      for (int day = 1; day <= DateTime.DaysInMonth(Year, Month); day++)
      {
        DateTime currentDate = new DateTime(Year, Month, day);
        if (currentDate.DayOfWeek == DayOfWeek.Tuesday)
          tuesdays.Add(currentDate);
      }
      for (int i = 0; i < tuesdays.Count; i++)
      {
        worksheet.Cells[row, i + 2].Value = tuesdays[i].ToString("dd/MM");
      }
    }

    private void PosConfigure(int footerPosition, ExcelWorksheet worksheet)
    {
      ExcelRange headerCells = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];
      headerCells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
      headerCells.Style.Fill.BackgroundColor.SetColor(Color.Gray);
      headerCells.Style.Font.Name = "Arial";
      headerCells.Style.Font.Size = 12;
      headerCells.Style.Font.Color.SetColor(Color.Black);

      ExcelRange footerCells = worksheet.Cells[footerPosition, 1, footerPosition, worksheet.Dimension.End.Column];
      footerCells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
      footerCells.Style.Fill.BackgroundColor.SetColor(Color.Gray);
      footerCells.Style.Font.Name = "Arial";
      footerCells.Style.Font.Size = 12;
      footerCells.Style.Font.Color.SetColor(Color.Black);

      ExcelRange allCells = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];
      allCells.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
      allCells.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
      allCells.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
      allCells.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
      allCells.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
      allCells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
      allCells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
    }

    private int FillBody(int row, List<string> body, ExcelWorksheet worksheet)
    {
      int result = row;
      for (int i = 0; i < body.Count; i++)
      {
        result = row + i;

        var cell = worksheet.Cells[result, 1];

        cell.Value = body[i];
        cell.Style.Font.Name = "Arial";
        cell.Style.Font.Size = 12;
        cell.Style.Font.Color.SetColor(Color.Black);
      }
      return result;
    }

    public void GenerateExcel(string saveToPath)
    {
      using ExcelPackage package = new ExcelPackage();
      ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Jogadores_Do_Mes");
      //Configuring PlayersHeader
      PreConfigure(1, "Jogadores", worksheet);
      int lastFilledPlayersRow = FillBody(2, Players, worksheet);

      //Configuring GoalKeepersHeader
      PreConfigure(lastFilledPlayersRow + 1, "Goleiros", worksheet);
      int lastFilledGoalKeepersRow = FillBody(lastFilledPlayersRow + 2, GoalKeepers, worksheet);

      PosConfigure(lastFilledPlayersRow + 1, worksheet);
      File.WriteAllBytes(saveToPath, package.GetAsByteArray());
    }
  }
}
