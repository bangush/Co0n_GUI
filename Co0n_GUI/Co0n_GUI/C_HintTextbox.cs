using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Co0n_GUI
{/// <summary>
 /// Extends the Standardtextbox to display a hint.
 /// </summary>
    public class C_HintTextbox : System.Windows.Forms.TextBox
    {
        System.Drawing.Color DefaultColor;
        public string PlaceHolderText { get; set; }
        public C_HintTextbox(string placeholdertext = "")
        {
            // get default color of text
            DefaultColor = this.ForeColor;
            // Add event handler for when the control gets focus
            this.GotFocus += (object sender, EventArgs e) =>
            {// Textbox got focus...
                if (this.Text.Equals(this.PlaceHolderText))
                {//... and stored text is equal to our placeholder text
                    //Empty the box
                    this.Text = String.Empty;
                    //And restore the original Textcolor
                    this.ForeColor = DefaultColor;
                }
            };

            // add event handling when focus is lost
            this.LostFocus += (Object sender, EventArgs e) => {
                //Textbox lost its focus...
                if (String.IsNullOrEmpty(this.Text) || this.Text == PlaceHolderText)
                {//... and .text ist not set or is set to our PlaceHolderText
                    //Set the Textcolor to grey
                    this.ForeColor = System.Drawing.Color.Gray;
                    //And set current .text to PlaceHolderText
                    this.Text = PlaceHolderText;
                }
                else
                {
                    // if .text is something different, restore the original foreground-color
                    this.ForeColor = DefaultColor;
                }
            };



            if (!string.IsNullOrEmpty(placeholdertext))
            {
                // change style   
                this.ForeColor = System.Drawing.Color.Gray;
                // Add text
                PlaceHolderText = placeholdertext;
                this.Text = placeholdertext;
            }



        }


    }
}
