using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuvFormat
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            if(GlobalAyarlar.GoruntuEn!=0)
            {
                spnEn.EditValue = GlobalAyarlar.GoruntuEn;
            }

            if (GlobalAyarlar.GoruntuBoy!=0)
            {
                spnBoy.EditValue = GlobalAyarlar.GoruntuBoy;
            }

            if (string.IsNullOrEmpty(GlobalAyarlar.YuvFormat))
            {
                cmbFormat.Text = GlobalAyarlar.YuvFormat;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (spnBoy.EditValue==null || spnEn.EditValue==null || string.IsNullOrEmpty(cmbFormat.Text))
            {
                XtraMessageBox.Show("Tüm alanların dolu olduğuna emin olun", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GlobalAyarlar.GoruntuBoy = int.Parse(spnBoy.EditValue.ToString());
            GlobalAyarlar.GoruntuEn = int.Parse(spnEn.EditValue.ToString());
            GlobalAyarlar.YuvFormat = cmbFormat.Text;

            XtraMessageBox.Show("İşleminiz başarıyla gerçekleştirilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            return;
        }
    }
}
