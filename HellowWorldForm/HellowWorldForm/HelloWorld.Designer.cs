namespace HellowWorldForm
{
    partial class HelloWorld
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnHelloWorld;
            this.labelHelloWorld = new System.Windows.Forms.Label();
            btnHelloWorld = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHelloWorld
            // 
            btnHelloWorld.Location = new System.Drawing.Point(304, 175);
            btnHelloWorld.Name = "btnHelloWorld";
            btnHelloWorld.Size = new System.Drawing.Size(134, 68);
            btnHelloWorld.TabIndex = 0;
            btnHelloWorld.Text = "Click Me!";
            btnHelloWorld.UseVisualStyleBackColor = true;
            btnHelloWorld.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelHelloWorld
            // 
            this.labelHelloWorld.AutoSize = true;
            this.labelHelloWorld.Location = new System.Drawing.Point(319, 283);
            this.labelHelloWorld.Name = "labelHelloWorld";
            this.labelHelloWorld.Size = new System.Drawing.Size(94, 20);
            this.labelHelloWorld.TabIndex = 1;
            this.labelHelloWorld.Text = "Hello World!";
            this.labelHelloWorld.Visible = false;
            this.labelHelloWorld.Click += new System.EventHandler(this.label1_Click);
            // 
            // HelloWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelHelloWorld);
            this.Controls.Add(btnHelloWorld);
            this.Name = "HelloWorld";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHelloWorld;
    }
}

