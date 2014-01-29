using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                // Skapar en stil för rader och celler.
                TableItemStyle tableStyle = new TableItemStyle();
                tableStyle.HorizontalAlign = HorizontalAlign.Center;
                tableStyle.VerticalAlign = VerticalAlign.Middle;
                tableStyle.Width = Unit.Pixel(100);

                // Create more rows for the table.
                for (int rowNum = 2; rowNum < 10; rowNum++)
                {
                    TableRow tempRow = new TableRow();
                    for (int cellNum = 0; cellNum < 2; cellNum++)
                    {
                        TableCell tempCell = new TableCell();
                        tempCell.Text =
                            String.Format("({0},{1})", rowNum, cellNum);
                        tempRow.Cells.Add(tempCell);
                    }
                    ConversionTable.Rows.Add(tempRow);
                }

                // Lägger till stilen till tabellen.
                foreach (TableRow rw in ConversionTable.Rows)
                    foreach (TableCell cel in rw.Cells)
                        cel.ApplyStyle(tableStyle);


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

                ConversionLabel.Visible = true;
            }
        }


    }
}