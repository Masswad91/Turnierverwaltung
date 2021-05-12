using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnierverwaltung.View
{
    public partial class Turnierverwaltung : System.Web.UI.Page
    {
        private Controller _verwalter;

        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = Global.Verwalter;
        }
        protected void Bearbeiten_Click(object sender, EventArgs e)
        {
            Name.Visible = true;
            Bearbeitungsbutten.Visible = true;
            Personhinzufeugen.Visible = false;
            idLabel.Visible = true;

        }

        protected void Hinzufeugen_Click1(object sender, EventArgs e)
        {
            Name.Visible = true;
            Personhinzufeugen.Visible = true;
            Bearbeitungsbutten.Visible = false;
            idLabel.Visible = true;
        }

        public void ZeigeAlleDaten()
        {
            GridView1.DataSource = Verwalter.HoleAllePersonen();
            GridView1.DataBind();
        }
        protected void Alle_Anzeigen_Click(object sender, EventArgs e)
        {
            ZeigeAlleDaten();
        }


        protected void Personhinzufeugen_Click(object sender, EventArgs e)
        {
            Verwalter.insert_teilnehmer(Name.Text);
            Response.Redirect(Request.RawUrl);
        }

        protected void Loeschen_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {

                CheckBox chkdel = (CheckBox)row.FindControl("check_box");

                if (chkdel.Checked)
                {
                    int teilnehmerID = Convert.ToInt32(row.Cells[1].Text);
                    Verwalter.EinenTeilnehmerloeschen(teilnehmerID);
                }
            }

            ZeigeAlleDaten();
        }

        protected void Personbearbeiten_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkbearbeiten = (CheckBox)row.FindControl("check_box");

                if (chkbearbeiten.Checked)
                {
                    int teilnehmerID = Convert.ToInt32(row.Cells[1].Text);
                    Verwalter.EinenTeilnehmerBearbeiten(teilnehmerID, Name.Text);
                }

                ZeigeAlleDaten();
            }
        }
    }
}