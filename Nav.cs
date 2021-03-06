using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Atlantic
{
    //Navbar button objects
    public class navBarButton
    {
        public bool clicked { get; set; }
        public System.Drawing.Image smallIcon { get; set; }
        public System.Drawing.Image largeIcon { get; set; }
        
        //set colors
        public Color notSelectedColor = Color.FromArgb(255, 27, 27, 28);
        public Color selectedColor = Color.FromArgb(255, 30, 30, 31);
        public bool saveClickStatus;
        public Color saveBackColor;
        public bool saveCurrentPanel;
        public System.Drawing.Image saveImage;
        public Button button { get; set; }

        public navBarButton() { }

        public navBarButton(bool _clicked, System.Drawing.Image _smallIcon, System.Drawing.Image _largeIcon, Button _button)
        {
            clicked = _clicked;
            smallIcon = _smallIcon;
            largeIcon = _largeIcon;
            button = _button;
        }

        public void mouseEnter(Button button)
        {
            if (this.button == button)
            {
                //mouse has entered button
                button.Image = this.largeIcon;
                button.BackColor = this.selectedColor;
            }
            else 
            {
                //Get non-selected button
                Button notSel = this.button;

                //Reset non-selected button attributes 
                notSel.Image = this.smallIcon;
                notSel.BackColor = this.notSelectedColor;
            }   
        }

        public void mouseLeave(Button button, Panel scrollBlock, bool hamburger)
        {
            if (this.button == button && this.clicked == false)
            {
                //mouse has left and button wasn't clicked
                button.Image = this.smallIcon;
                button.BackColor = this.notSelectedColor;
            }
            else if(this.button == button && this.clicked == true)
            {
                //mouse has entered button
                button.Image = this.largeIcon;
                button.BackColor = this.selectedColor;
                scrollBlock.Visible = true;
                scrollBlock.Location = new Point(0, button.Location.Y);
            }
            else if(this.button != button && this.clicked == true)
            {
                //user is currently on this page
                //Get selected button
                Button sel = this.button;
                sel.Image = this.largeIcon;
                sel.BackColor = this.selectedColor;
                scrollBlock.Visible = true;
                scrollBlock.Location = new Point(0, sel.Location.Y);
            }
        }

        public void mouseClicked(Button button, bool currentPanel)
        {   
            if(this.button == button && this.clicked == false)
            {
                button.Image = this.largeIcon;
                button.BackColor = this.selectedColor;
                this.saveCurrentPanel = currentPanel;
                this.clicked = true;
            }
            else if(this.button != button)
            {
                //get non-selected button
                Button notSel = this.button;
                notSel.Image = this.smallIcon;
                notSel.BackColor = this.notSelectedColor;
                this.clicked = false;
                this.saveClickStatus = false;
            }
        }
		
		public void saveOrRestoreSelection(bool currentPanel, Panel scrollBlock)
        {
            if(this.clicked == true && currentPanel != this.saveCurrentPanel)
            {
                //save clicked button attributes
                this.saveClickStatus = true;
                this.clicked = false;
                scrollBlock.Visible = false;
            }
            else if(this.saveClickStatus == true && currentPanel == this.saveCurrentPanel)
            {
                //restore clicked button atttributes
                //Get selected button
                Button sel = this.button;
                sel.Image = this.largeIcon;
                sel.BackColor = this.selectedColor;
                scrollBlock.Visible = true;
                scrollBlock.Location = new Point(0, sel.Location.Y);

                //set as clicked
                this.clicked = true;
                this.saveClickStatus = false;
            }
            else if(this.clicked == false && this.saveClickStatus == false)
            {
                //get non-selected button
                Button notSel = this.button;
                notSel.Image = this.smallIcon;
                notSel.BackColor = this.notSelectedColor;
            }      
        }
    }
}
