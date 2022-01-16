using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV_TC.Reports;

namespace QLDSV_TC
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();

            //if (Program.mGroup == Program.nhomQuyen[2])
            //{
            //    ribbonPage2.Visible = false;
            //}

            Form frm = this.CheckExists(typeof(FormLop));
            if (frm != null) frm.Activate();
            else
            {
                FormLop f = new FormLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }

        private void btnDangnhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormLogin));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormLogin f = new FormLogin();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void fmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormLop));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormLop f = new FormLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormMonHoc));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormMonHoc f = new FormMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLopTinChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormLopTC));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormLopTC f = new FormLopTC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormSinhVien));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormSinhVien f = new FormSinhVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormDiem));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormDiem f = new FormDiem();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            new FormLogin(Program.mlogin, Program.password).Show();
        }

        private void btnRPDSLTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormDiem));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormRPDSLTC f = new FormRPDSLTC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void dsvt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormDiem));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormRPDSSVLTC f = new FormRPDSSVLTC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form fm = this.CheckExists(typeof(FormDiem));
            if (fm != null)
            {
                fm.Activate();
            }
            else
            {
                FormRPBangDiem f = new FormRPBangDiem();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}