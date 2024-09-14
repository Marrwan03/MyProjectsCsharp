using clsBusinessTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyLibrary;

namespace DVLD_Project
{
    public partial class frmAdd_UpdatePerson : Form
    {

        public delegate void MyDelegate(clsBusinessPeople Person);
        public event MyDelegate DataBack;

        clsBusinessPeople _Person;
       
        int _PersonID;
        public frmAdd_UpdatePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            if(_PersonID == -1)
            {
                lblTitle.Text = "Add New Person";
                
            }
            else 
            {
                lblTitle.Text = "Update Person";
                lblID.Text = _PersonID.ToString();
                
            }
        }

       
        

      


        private void frmAdd_UpdatePerson_Load(object sender, EventArgs e)
        {
            ctrlAdd_UpdatePerson3.LoadData(_PersonID);
        }

        
        private void ctrlAdd_UpdatePerson3_OnClose()
        {
            //if doesn`t save data
            if(_Person != null)
            {
                DataBack?.Invoke(_Person);
            }
           
            this.Close();
        }

        void _SetPhotoInFolderOrChance()
        {
            string path = @"C:\Users\lenovo\OneDrive\Desktop\DVLB-Photo\";
            Guid guid = Guid.NewGuid();
            clsBusinessPhotos PersonPhoto;

            if (clsBusinessPhotos.IsExists(_Person.ID))
            {
                PersonPhoto = clsBusinessPhotos.Find(_Person.ID);

                if(File.Exists(path + PersonPhoto.GuidName + ".png"))
                {
                    //Delete
                    File.Delete(path + PersonPhoto.GuidName + ".png");

                    //Update
                    PersonPhoto.ImagePath = _Person.ImagePath;


                    if (_Person.ImagePath != null)
                    {
                        PersonPhoto.GuidName = guid.ToString();
                        if (PersonPhoto.Save())
                        {
                            File.Copy(PersonPhoto.ImagePath, path + PersonPhoto.GuidName + ".png");
                        }
                    }
                    else
                    {
                        clsBusinessPhotos.DeletePhoto(_Person.ID);
                    }
                   
                }
                else
                {
                    if(_Person.ImagePath != null)
                    {
                        File.Copy(_Person.ImagePath, path + guid + ".png");
                    }
                   
                }

                

            }
            else
            {
                PersonPhoto = new clsBusinessPhotos();
                PersonPhoto.PersonID = _Person.ID;
                PersonPhoto.ImagePath = _Person.ImagePath;
                PersonPhoto.GuidName = guid.ToString();
                if (PersonPhoto.Save())
                {
                    File.Copy(_Person.ImagePath, path + guid + ".png");
                }
            }
        }


        private void ctrlAdd_UpdatePerson3_OnSave(clsBusinessPeople obj)
        {
            _Person = obj;
           

            if (ctrlAdd_UpdatePerson3.CompleteSave)
            {
                if (_Person.Save())
                {
                    lblID.Text = _Person.ID.ToString();
                    lblTitle.Text = "Update Person";
                    _SetPhotoInFolderOrChance();
                    if (!string.IsNullOrEmpty(_Person.ImagePath))
                    {
                        ctrlAdd_UpdatePerson3.llblRemove.Visible = true;
                        
                    }
                      


                    MessageBox.Show("Save is succeeded");
                }
                else
                {
                    MessageBox.Show("Save is failed");
                }
            }
            else
            {
                MessageBox.Show("try to follow system rols and set all your data", "Be Careful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlAdd_UpdatePerson3_Load(object sender, EventArgs e)
        {

        }


        public  void Label_MouseEnter(object sender, EventArgs e)
        {
           clsColorControl.Label_MouseEnter(sender, e);
        }

        public  void Label_MouseLeave(object sender, EventArgs e)
        {
            clsColorControl.Label_MouseLeave(sender, e);
        }

    }
}
