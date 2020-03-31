using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VeritabanliPartiSecimGrafikIstatislik
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=DbSecimProje;Integrated Security=True");
        private void btnOyGrisi_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblIlce (IlceAd,AParti,BParti,CParti,DParti,EParti) values(@p1,@p2,@p3,@p4,@p5,@p6)",con);
            cmd.Parameters.AddWithValue("@p1",txtIlceAd.Text);
            cmd.Parameters.AddWithValue("@p2",txtA.Text);
            cmd.Parameters.AddWithValue("@p3",txtb.Text);
            cmd.Parameters.AddWithValue("@p4",txtC.Text);
            cmd.Parameters.AddWithValue("@p5",txtD.Text);
            cmd.Parameters.AddWithValue("@p6",txtE.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            txtA.Clear();
            txtb.Clear();
            txtC.Clear();
            txtD.Clear();
            txtE.Clear();
            txtIlceAd.Clear();
            MessageBox.Show("Oy girişi gerçekleşti");
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            frmGrafikler frm = new frmGrafikler();
            frm.Show();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
