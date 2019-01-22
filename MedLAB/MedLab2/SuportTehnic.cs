using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace MedLab2
{
    class SuportTehnic:DevComponents.DotNetBar.Office2007Form
    {
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuportTehnic));
            this.reflectionImage1 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.SuspendLayout();
            // 
            // reflectionImage1
            // 
            // 
            // 
            // 
            this.reflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionImage1.Image = ((System.Drawing.Image)(resources.GetObject("reflectionImage1.Image")));
            this.reflectionImage1.Location = new System.Drawing.Point(2, 88);
            this.reflectionImage1.Name = "reflectionImage1";
            this.reflectionImage1.Size = new System.Drawing.Size(112, 143);
            this.reflectionImage1.TabIndex = 3;
            // 
            // reflectionLabel1
            // 
            this.reflectionLabel1.Location = new System.Drawing.Point(12, 12);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(116, 70);
            this.reflectionLabel1.TabIndex = 2;
            this.reflectionLabel1.Text = "<b><font size=\"+10\"><i>Med</i><font color=\"#B02B2C\">LAB</font></font></b>";
            // 
            // SuportTehnic
            // 
            this.ClientSize = new System.Drawing.Size(399, 403);
            this.Controls.Add(this.reflectionImage1);
            this.Controls.Add(this.reflectionLabel1);
            this.Name = "SuportTehnic";
            this.Text = "Suport Tehnic";
            this.ResumeLayout(false);

        }
    }
}
