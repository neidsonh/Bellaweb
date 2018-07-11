using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CarouselDestaques
/// </summary>
public class CarouselDestaques : Panel
{

    private DataSet dataSource;

    public DataSet DataSource
    {
        get
        {
            return dataSource;
        }

        set
        {
            dataSource = value;
        }
    }

    public override void DataBind()
    {
        string listItems = "";

        StringBuilder listImages = new StringBuilder();
        bool first = true;

        foreach (DataTable table in dataSource.Tables)
        {
            listItems = ListItems(table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                Tuple<string, string, string> tupleRow = ToTuple(row);
                listImages.Append(CarouselImages(tupleRow.Item1, tupleRow.Item2, tupleRow.Item3, first));
                first = false;
            }
        }

        Controls.Add(Carousel(listItems, listImages.ToString()));
    }

    private static string ListItems(int qntd)
    {
        if (qntd < 1)
            throw new Exception("Quantidades de destaques deve ser maior ou igual a 1");

        StringBuilder sb = new StringBuilder("<ol class='carousel-indicators'>");

        for (int i = 0; i < qntd; i++) {
            string li = "<li data-target='#myCarousel' data-slide-to='{0}'{1}></li>";
            sb.Append(String.Format(li, i, (i == 0 ? " class='active'": "")));
        }

        sb.Append("</ol>");

        return sb.ToString();
    }

    private static Tuple<string, string, string> ToTuple(DataRow row)
    {
        string urlImg = Convert.ToString(row["des_imgurl"]);
        string urlDestaque = Convert.ToString(row["des_url"]);
        string titulo = Convert.ToString(row["des_titulo"]);
        return new Tuple<string, string, string>(
            urlImg, urlDestaque, titulo
        );
    }

    private static string CarouselImages(string urlImg, string urlDestque, string titulo, bool active)
    {
        string html = @"<div class='item{3} carousel-item'>
                            <div class='position-img'>
                                <img src='{0}' alt='{2}' class='img-responsive full-screen' />
                            </div>
                            <div class='text-img'>
                                <a class='carousel-link' href='{1}' target='_blank'>{2}</a>
                            </div>
                       </div>";


        return String.Format(html, urlImg, urlDestque, titulo, (active ? " active" : ""));
    }

    private static Control Carousel(string listItems, string listImages)
    {
        string html = @"
            <div id='myCarousel' class='carousel slide' data-ride='carousel'>
                {0}

                <!-- Tendencias -->
                <div class='carousel-inner' role='listbox'>
                    {1}                               
                </div>

                <a class='left carousel-control' href='#myCarousel' role='button' data-slide='prev'>
                    <span class='glyphicon glyphicon-chevron-left' aria-hidden='true'></span>
                    <span class='sr-only'>Previous</span>
                </a>
                <a class='right carousel-control' href='#myCarousel' role='button' data-slide='next'>
                    <span class='glyphicon glyphicon-chevron-right' aria-hidden='true'></span>
                    <span class='sr-only'>Next</span>
                </a>
            </div>
        ";

        return new LiteralControl(String.Format(html, listItems, listImages));
    }
}