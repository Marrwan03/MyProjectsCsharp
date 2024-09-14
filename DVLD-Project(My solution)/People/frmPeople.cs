using clsBusinessTier;
using MyLibrary;
using System;
using System.IO;
using System.Data;

using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace DVLD_Project
{
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();
        }

        enTypeFilter FilterType;
        enum enTypeFilter
        {
            None,
            PersonID,
            NationalNo,
            FirstName,
            SecondName,
            ThirdName,
            LastName,
            CountryName,
            Gendor,
            Phone,
            Email
         
        }

        private DataTable _dtPerson;
        private DataView _dtPersonFilter;

       

     

        void _RefreshData(bool UsingFilter)
        {

            if (UsingFilter)
            {
                lblCountOfPeople.Text = _dtPersonFilter.Count.ToString();
            }

            else
            {
                _dtPerson = clsBusinessPeople.GetAllPeople();
                
                lblCountOfPeople.Text = clsBusinessPeople.GetPeopleCount().ToString();
                dgvPeoplelist.DataSource = _dtPerson;
            }


        }
       
        private void frmPeople_Load(object sender, EventArgs e)
        {
            //clsForm.SetForm(this, 1195, 630);
            _dtPerson = clsBusinessPeople.GetAllPeople();
            cbfilter.SelectedIndex = 0;
            _RefreshData(false);

            dgvPeoplelist.EnableHeadersVisualStyles = false;
            dgvPeoplelist.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
        }

        void _controlVisible(bool ShowTextBox = false, bool ShowRadioButton = false)
        {
            if (ShowTextBox)
            {
                txtFilter.Visible = true;
                pGender.Visible = false;
               
            }
            else 
            {
                txtFilter.Visible = false;
                pGender.Visible = true;
              
            }
            


        }
       
       

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            _dtPersonFilter = _dtPerson.DefaultView;
            txtFilter.Text = string.Empty;
            switch (cbfilter.SelectedIndex)
            {
                case 0:
                    {
                        txtFilter.Visible = false;
                        pGender.Visible=false;
                      
                        _RefreshData(false);
                        FilterType = enTypeFilter.None;
                        break;
                    }
                    case 1:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.PersonID;
                        break;
                    }
                    case 2:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.NationalNo;
                        break;
                    }
                    case 3:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.FirstName;
                        break;
                    }
                    case 4:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.SecondName;
                        break;
                    }
                    case 5:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.ThirdName;
                        break;
                    }
                    case 6:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.LastName;
                        break;
                    }
                    case 7:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.CountryName;
                        break;
                    }
                    case 8:
                    {
                        _controlVisible(false, true);
                        FilterType = enTypeFilter.Gendor;
                        break;
                    }
                    case 9:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.Phone;
                        break;
                    }
                    case 10:
                    {
                        _controlVisible(true);
                        FilterType = enTypeFilter.Email;
                        break;
                    }
               



            }

        }

        string GetFilterType()
        {
            string FT = string.Empty;
            switch (FilterType)
            {
                case enTypeFilter.PersonID:
                    {
                        FT = "PersonID";
                        break;
                    }
                case enTypeFilter.NationalNo:
                    {
                        FT = "NationalNo";
                        break;
                    }
                case enTypeFilter.FirstName:
                    {
                        FT = "FirstName";
                        break;
                    }
                case enTypeFilter.SecondName:
                    {
                        FT = "SecondName";
                        break;
                    }
                case enTypeFilter.ThirdName:
                    {
                        FT = "ThirdName";
                        break;
                    }
                case enTypeFilter.LastName:
                    {
                        FT = "LastName";
                        break;
                    }
                case enTypeFilter.CountryName:
                    {
                        FT = "CountryName";
                        break;
                    }
                case enTypeFilter.Gendor:
                    {
                        FT = "Gendor";
                        break;
                    }
                case enTypeFilter.Phone:
                    {
                        FT = "Phone";
                        break;
                    }
                case enTypeFilter.Email:
                    {
                        FT = "Email";
                        break;
                    }
                
            }
            return FT;
        }

        void FiltertxtDataView(string FilterName)
        {
            string FilterType = GetFilterType();
            if (FilterType == "PersonID")
            {
                _dtPersonFilter.RowFilter = "convert(PersonID, 'System.String') LIKE '" + FilterName + "%' ";
            }
            else
            {
                _dtPersonFilter.RowFilter = FilterType + " LIKE '" + FilterName + "%' ";
            }

          
            dgvPeoplelist.DataSource = _dtPersonFilter;

        }

        void FilterrRbDataView()
        {
            string FilterName = string.Empty;
            if(rbMale.Checked)
            {
                FilterName = "Male";
            }
            else
            {
                FilterName = "Female";
            }

            _dtPersonFilter.RowFilter = "Gendor LIKE '" + FilterName + "%' ";
            dgvPeoplelist.DataSource = _dtPersonFilter;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        string _LastFilterPhone = string.Empty;

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            //int id = 102a;
            //dataview1.RowFilter = "convert(PersonID, 'System.String') LIKE '" + id + "%' ";
          
         
            if (FilterType == enTypeFilter.PersonID || FilterType == enTypeFilter.Phone)
            {
                if (!clsTextProcessing.TextHasLetter(txtFilter.Text))
                {
                    _LastFilterPhone = txtFilter.Text;
                }
                
                txtFilter.Text = _LastFilterPhone;
                txtFilter.SelectionStart = _LastFilterPhone.Length;
            }

            FiltertxtDataView(txtFilter.Text);
            _RefreshData(true);

           
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            frmPersonDetails PersonDetails = new frmPersonDetails(int.Parse(dgvPeoplelist.CurrentRow.Cells[0].Value.ToString()));
            PersonDetails.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdatePerson frmUpdate_Person = new frmAdd_UpdatePerson((int)dgvPeoplelist.CurrentRow.Cells[0].Value);
            frmUpdate_Person.ShowDialog();
            _RefreshData(false);
        }

        private void picAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_UpdatePerson frmAdd_Person = new frmAdd_UpdatePerson(-1);
            frmAdd_Person.ShowDialog();
            _RefreshData(false);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdatePerson frmAdd_Person = new frmAdd_UpdatePerson(-1);
            frmAdd_Person.ShowDialog();
        }



        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure do you want delete this Person?", "Delete!",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //Delete From FilePhoto
            string path = @"C:\Users\lenovo\OneDrive\Desktop\DVLB-Photo\";
            clsBusinessPhotos PersonPhoto = clsBusinessPhotos.Find((int)dgvPeoplelist.CurrentRow.Cells[0].Value);
            if (PersonPhoto != null)
            {

                File.Delete(path + PersonPhoto.GuidName + ".png");
                if (!clsBusinessPhotos.DeletePhoto((int)dgvPeoplelist.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Delete Failed", "Wrong Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Delete from PeopleTable
            if (clsBusinessPeople.DeletePerson((int)dgvPeoplelist.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Delete succeeded");
            }
            else
            {
                MessageBox.Show("Delete Failed,\n This Person Has Refrance in another table", "Wrong Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReturnPhoto(clsBusinessPeople.Find((int)dgvPeoplelist.CurrentRow.Cells[0].Value), PersonPhoto.GuidName, path);
            }

            _RefreshData(false);


        }


        private void rbFilter_CheckedChanged(object sender, EventArgs e)
        {
            if(rbAll.Checked)
            {
                _RefreshData(false);
                return;
            }
            FilterrRbDataView();
            _RefreshData(true);
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFilter_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void pGender_Paint(object sender, PaintEventArgs e)
        {

        }

       
       

        void ReturnPhoto(clsBusinessPeople Person, string guid, string path)
        {
            clsBusinessPhotos PersonPhoto = new clsBusinessPhotos();
            if (Person.ImagePath != null)
            {
                PersonPhoto.ImagePath = Person.ImagePath;
                PersonPhoto.GuidName = guid;
                PersonPhoto.PersonID = Person.ID;
                if (PersonPhoto.Save())
                {
                    File.Copy(PersonPhoto.ImagePath, path + PersonPhoto.GuidName + ".png");
                }
            }
        }



        #region ColorControl
        void Text_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseEnter(sender, e);
        }
        void Text_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.TextBox_MouseLeave(sender, e);
        }

        void Button_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseEnter(sender, e);
        }
        void Button_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Button_MouseLeave(sender, e);
        }

        void Label_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseEnter(sender, e);
        }
        void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }

        

        void comboBox_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.comboBox_MouseEnter(sender, e);
        }
        void comboBox_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.comboBox_MouseLeave(sender, e);
        }

        void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.RadioButton_MouseEnter(sender, e);
        }
        void RadioButton_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.RadioButton_MouseLeave(sender, e);
        }

        void ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseEnter(sender, e);
        }
        void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.ToolStripMenuItem_MouseLeave(sender, e);
        }

        #endregion
    }
}
