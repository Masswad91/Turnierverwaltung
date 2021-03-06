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
            Name.Visible = false;
            Bearbeitungsbutten.Visible = false;
            idLabel.Visible = false;
            Arzt.Visible = true;
            Fussballspieler.Visible = true;
            Handballspieler.Visible = true;
            Organisator.Visible = true;
            Tennisspieler.Visible = true;

        }

        protected void Hinzufeugen_Click1(object sender, EventArgs e)
        {
            Name.Visible = false;
            Personhinzufeugen.Visible = true;
            Bearbeitungsbutten.Visible = false;
            idLabel.Visible = false;
            Arzt.Visible = true;
            Fussballspieler.Visible = true;
            Handballspieler.Visible = true;
            Organisator.Visible = true;
            Tennisspieler.Visible = true;

        }
        protected void Hinzufeugen_Arzt(object sender, EventArgs e)
        {
            idLabel.Visible = true;
            Name.Visible = true;
            idLabe5.Visible = true;
            Bezeichnung.Visible = true;
        }

        protected void Hinzufeugen_Fussballspiele(object sender, EventArgs e)
        {
            idLabel.Visible = true;
            Name.Visible = true;
            idLabe2.Visible = true;
            Fussstearke.Visible = true;
        }

        protected void Hinzufeugen_Handballspieler(object sender, EventArgs e)
        {
            idLabel.Visible = true;
            Name.Visible = true;
            idLabe3.Visible = true;
            Handstearke.Visible = true;
        }

        protected void Hinzufeugen_Organisator(object sender, EventArgs e)
        {
            idLabel.Visible = true;
            Name.Visible = true;
            idLabe4.Visible = true;
            Rolle.Visible = true;

        }

        protected void Hinzufeugen_Tennisspieler(object sender, EventArgs e)
        {
            idLabel.Visible = true;
            Name.Visible = true;
            idLabe6.Visible = true;
            Mit_welcher_Hand.Visible = true;

        }

        public void ZeigeAlleDaten()
        {
            Teilnehmer_view.DataSource = Verwalter.HoleAllePersonen();
            Teilnehmer_view.DataBind();
        }

        protected void Alle_Anzeigen_Click(object sender, EventArgs e)
        {
            ZeigeAlleDaten();
        }


        protected void Loeschen_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in Teilnehmer_view.Rows)
            {

                CheckBox chkdel = (CheckBox)row.FindControl("check_box");

                if (chkdel.Checked)
                {
                    int teilnehmerID = Convert.ToInt32(row.Cells[1].Text);
                    Verwalter.Teilnehmerliste.Add(new Fussballspieler());
                    Verwalter.EinenTeilnehmerLoechen(teilnehmerID);
                }
            }

            ZeigeAlleDaten();
        }

        protected void Personbearbeiten_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in Teilnehmer_view.Rows)
            {
                CheckBox chkbearbeiten = (CheckBox)row.FindControl("check_box");

                if (chkbearbeiten.Checked)
                {
                    int teilnehmerID = Convert.ToInt32(row.Cells[1].Text);
                    int spieler_fussstearke = Convert.ToInt32(Fussstearke.Text);
                    Verwalter.Teilnehmerliste.Add(new Fussballspieler("", spieler_fussstearke));
                    Verwalter.EinenTeilnehmerBearbeiten(teilnehmerID);
                }

                ZeigeAlleDaten();
            }
        }

        protected void Personhinzufeugen_Click(object sender, EventArgs e)
        {

            if (Bezeichnung.Text != "")
            {
                Verwalter.Teilnehmerliste.Add(new Arzt(Name.Text, Bezeichnung.Text));
                Verwalter.EinenTeilnehmerHinzufuegen();
                Response.Redirect(Request.RawUrl);
            }
            else if (Fussstearke.Text != "")
            {
                int spieler_fussstearke = Convert.ToInt32(Fussstearke.Text);
                Verwalter.Teilnehmerliste.Add(new Fussballspieler(Name.Text, spieler_fussstearke));
                Verwalter.EinenTeilnehmerHinzufuegen();
                Response.Redirect(Request.RawUrl);

            }
            else if (Mit_welcher_Hand.Text != "")
            {
                Verwalter.Teilnehmerliste.Add(new Tennisspieler(Name.Text, Mit_welcher_Hand.Text));
                Verwalter.EinenTeilnehmerHinzufuegen();
                Response.Redirect(Request.RawUrl);
            }
            else if (Handstearke.Text != "")
            {
                int spieler_handtearke = Convert.ToInt32(Handstearke.Text);
                Verwalter.Teilnehmerliste.Add(new Handballspieler(Name.Text, spieler_handtearke));
                Verwalter.EinenTeilnehmerHinzufuegen();
                Response.Redirect(Request.RawUrl);
            }
            else if (Rolle.Text != "")
            {
                Verwalter.Teilnehmerliste.Add(new Organisator(Name.Text, Rolle.Text));
                Verwalter.EinenTeilnehmerHinzufuegen();
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Redirect(Request.RawUrl);
            }

        }

    }
}