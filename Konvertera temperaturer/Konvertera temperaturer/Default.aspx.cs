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
                var endValue = int.Parse(EndTextBox.Text);

                // Skapar en stil för rader och celler.
                TableItemStyle tableStyle = new TableItemStyle();
                tableStyle.HorizontalAlign = HorizontalAlign.Center;
                tableStyle.VerticalAlign = VerticalAlign.Middle;
                tableStyle.Width = Unit.Pixel(100);

                // Väljer mellan °C & °F i tabellhuvudet.
                if (CelToFahRadioButton.Checked == true)
                {
                    HeaderLabel1.Text = "&degC";
                    HeaderLabel2.Text = "&degF";
                }
                else
                {
                    HeaderLabel1.Text = "&degF";
                    HeaderLabel2.Text = "&degC";
                }

                // Create more rows for the table.
                for (int rowNum = 1; rowNum < endValue; rowNum++)
                {
                    TableRow tempRow = new TableRow();
                    for (int cellNum = 0; cellNum < 2; cellNum++)
                    {
                        TableCell tempCell = new TableCell();
                        // Olika utskrift beroende av Celsius eller Fahrenheit.
                        if (rowNum == 1 && cellNum == 0)
                        {
                            tempCell.Text = StartTextBox.Text;
                            tempRow.Cells.Add(tempCell);
                        }
                        else if (CelToFahRadioButton.Checked == true)
                        {
                            tempCell.Text =
                                String.Format("({0})", rowNum);
                            tempRow.Cells.Add(tempCell);
                        }
                        else
                        {
                            tempCell.Text =
                                String.Format("({0},{1})", rowNum, cellNum);
                            tempRow.Cells.Add(tempCell);
                        }
                    }
                    ConversionTable.Rows.Add(tempRow);
                }

                // Lägger till stilen till tabellen.
                foreach (TableRow rw in ConversionTable.Rows)
                    foreach (TableCell cel in rw.Cells)
                        cel.ApplyStyle(tableStyle);

                // Visar tabellen.
                ConversionLabel.Visible = true;
            }
        }


    }
}