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

        public void mouseClicked(Button button)
        {   
            if(this.button == button && this.clicked == false)
            {
                button.Image = this.largeIcon;
                button.BackColor = this.selectedColor;
                this.clicked = true;
            }
            else if(this.button != button)
            {
                //get non-selected button
                Button notSel = this.button;
                notSel.Image = this.smallIcon;
                notSel.BackColor = this.notSelectedColor;
                this.clicked = false;
            }
        }

        public void saveSelection(bool firstPanel)
        {
            this.saveClickStatus = false;

            if(this.clicked == true)
            {
                this.saveClickStatus = true;
                this.saveCurrentPanel = firstPanel;
            }

            this.clicked = false;
        }

        public void restoreSelection(Panel scrollBlock, bool firstPanel)
        {
            if(this.saveClickStatus == true)
            {
                this.clicked = true;
                this.button.BackColor = this.selectedColor;
                this.button.Image = this.largeIcon;

                if (this.saveCurrentPanel == true && firstPanel == true)
                {
                    scrollBlock.Visible = true;
                    scrollBlock.Location = new Point(0, this.button.Location.Y);
                }
                else if(this.saveCurrentPanel == false && firstPanel == false)
                {
                    scrollBlock.Visible = true;
                    scrollBlock.Location = new Point(0, this.button.Location.Y);
                }
            }
        }
    }
}
