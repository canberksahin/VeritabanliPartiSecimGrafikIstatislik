﻿using System;
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
    public partial class frmGrafikler : Form
    {
        public frmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=DbSecimProje;Integrated Security=True");
        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select IlceAd from tblIlce",con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboIlce.Items.Add(dr[0]);
            }
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("select sum(AParti),sum(BParti),sum(CParti),sum(DParti),sum(EParti) from tblIlce",con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ", dr2[4]);
            }

            con.Close();
        }

        private void cboIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select AParti,BParti,CParti,DParti,EParti from tblIlce where IlceAd=@p1", con);
            cmd.Parameters.AddWithValue("@p1", cboIlce.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = Convert.ToInt32(dr[0].ToString());
                progressBar2.Value = Convert.ToInt32(dr[1].ToString());
                progressBar3.Value = Convert.ToInt32(dr[2].ToString());
                progressBar4.Value = Convert.ToInt32(dr[3].ToString());
                progressBar5.Value = Convert.ToInt32(dr[4].ToString());
                chart1.Series["Partiler"].Points.Clear(); 
                chart1.Series["Partiler"].Points.AddXY("A PARTİ", dr[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ", dr[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ", dr[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ", dr[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ", dr[4]);

                lblA.Text = dr[0].ToString();
                lblB.Text = dr[1].ToString();
                lblC.Text = dr[2].ToString();
                lblD.Text = dr[3].ToString();
                lblE.Text = dr[4].ToString();
            }
            con.Close();
        }
    }
}
