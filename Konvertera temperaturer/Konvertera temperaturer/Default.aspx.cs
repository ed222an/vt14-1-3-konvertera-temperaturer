using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Konvertera_temperaturer.Model;

namespace Konvertera_temperaturer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ConvertButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Variabler
                var startValue = int.Parse(StartTextBox.Text);
                var endValue = int.Parse(EndTextBox.Text);
                var scaleValue = int.Parse(ScaleTextBox.Text);

                // Väljer mellan °C & °F i tabellhuvudet.
                if (!CelToFahRadioButton.Checked)
                {
                    First.Text = "&degF";
                    Second.Text = "&degC";
                }

                for (int temp = startValue; temp <= endValue; temp += scaleValue)
                {
                    TableRow row = new TableRow();
                    ConversionTable.Rows.Add(row);
                    TableCell[] cells = new TableCell[] { new TableCell(), new TableCell() };
                    row.Cells.AddRange(cells);

                    cells[0].Text = temp.ToString();
                    cells[1].Text = CelToFahRadioButton.Checked ?
                        TemperatureConverter.CelsiusToFahrenheit(temp).ToString() :
                        TemperatureConverter.FahrenheitToCelsius(temp).ToString();
                }

                // Visar tabellen.
                ConversionLabel.Visible = true;
            }
        }
    }
}

/*
                // Skapar nya rader för tabellen.
                for (int rowNum = 1; rowNum < endValue; rowNum++)
                {
                    if (startValue > endValue)
                    {
                        break;
                    }

                    TableRow tempRow = new TableRow();
                    for (int cellNum = 0; cellNum < 2; cellNum++)
                    {
                        TableCell tempCell = new TableCell();

                        // Är Celsius till Fahrenheit vald?
                        if (CelToFahRadioButton.Checked == true)
                        {
                            if (cellNum == 0)
                            {
                                tempCell.Text = startValue.ToString();
                                tempRow.Cells.Add(tempCell);
                            }
                            else
                            {
                                tempCell.Text = TemperatureConverter.CelsiusToFahrenheit(startValue).ToString();
                                tempRow.Cells.Add(tempCell);
                            }
                        }
                        else // Annars räknas allt via Fahrenheit till Celsius.
                        {
                            if (cellNum == 0)
                            {
                                tempCell.Text = startValue.ToString();
                                tempRow.Cells.Add(tempCell);
                            }
                            else
                            {
                                tempCell.Text = TemperatureConverter.FahrenheitToCelsius(startValue).ToString();
                                tempRow.Cells.Add(tempCell);
                            }
                        }
                    }
                    // Ökar startvärdet med stegvärdet & lägger till raden i tabellen.
                    startValue += scaleValue;
                    ConversionTable.Rows.Add(tempRow);
                }

                // Skapar en stil för rader och celler.
                TableItemStyle tableStyle = new TableItemStyle();
                tableStyle.HorizontalAlign = HorizontalAlign.Center;
                tableStyle.VerticalAlign = VerticalAlign.Middle;
                tableStyle.Width = Unit.Pixel(100);

                // Lägger till stilen till tabellen.
                foreach (TableRow rw in ConversionTable.Rows)
                    foreach (TableCell cel in rw.Cells)
                        cel.ApplyStyle(tableStyle);
*/