using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace data_bind
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string mainconn = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select * from employeedata";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlconn.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                StringBuilder sb = new StringBuilder();
                sb.Append("<center>");
                sb.Append("<h1>Bind data in html table from database</h1>");
                sb.Append("<h2>using Stringn builder class</h2>");
                sb.Append("<hr/>");
                sb.Append("<table border=1>");
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(dc.ColumnName.ToUpper());
                    sb.Append("</th>");
                }
                sb.Append("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sb.Append("<th>");
                        sb.Append(dr[dc.ColumnName].ToString());
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                sb.Append("</center>");
                Panel1.Controls.Add(new Label {Text=sb.ToString()});
                sqlconn.Close();

            }
        }
    }
}