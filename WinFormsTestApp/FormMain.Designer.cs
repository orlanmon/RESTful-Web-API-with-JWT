
namespace WinFormsTestApp
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_Invoke = new Button();
            button_Invoke_Two = new Button();
            button_invoke_register = new Button();
            button_invoke_login = new Button();
            textBox_JSONTOKEN = new TextBox();
            textBox_register_username = new TextBox();
            textBox_register_password = new TextBox();
            textBox_login_username = new TextBox();
            textBox_login_password = new TextBox();
            label_JSONWebToken = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            dataGridView_Products = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Products).BeginInit();
            SuspendLayout();
            // 
            // button_Invoke
            // 
            button_Invoke.Location = new Point(13, 58);
            button_Invoke.Name = "button_Invoke";
            button_Invoke.Size = new Size(139, 23);
            button_Invoke.TabIndex = 0;
            button_Invoke.Text = "Invoke Get Product";
            button_Invoke.UseVisualStyleBackColor = true;
            button_Invoke.Click += button_Invoke_Click;
            // 
            // button_Invoke_Two
            // 
            button_Invoke_Two.Location = new Point(13, 117);
            button_Invoke_Two.Name = "button_Invoke_Two";
            button_Invoke_Two.Size = new Size(139, 23);
            button_Invoke_Two.TabIndex = 1;
            button_Invoke_Two.Text = "Invoke Get Products";
            button_Invoke_Two.UseVisualStyleBackColor = true;
            button_Invoke_Two.Click += button_Invoke_Two_Click;
            // 
            // button_invoke_register
            // 
            button_invoke_register.Location = new Point(79, 107);
            button_invoke_register.Name = "button_invoke_register";
            button_invoke_register.Size = new Size(75, 23);
            button_invoke_register.TabIndex = 2;
            button_invoke_register.Text = "Register";
            button_invoke_register.UseVisualStyleBackColor = true;
            button_invoke_register.Click += button_invoke_register_Click;
            // 
            // button_invoke_login
            // 
            button_invoke_login.Cursor = Cursors.No;
            button_invoke_login.Location = new Point(99, 127);
            button_invoke_login.Name = "button_invoke_login";
            button_invoke_login.Size = new Size(75, 23);
            button_invoke_login.TabIndex = 3;
            button_invoke_login.Text = "Logon";
            button_invoke_login.UseVisualStyleBackColor = true;
            button_invoke_login.Click += button_invoke_login_Click;
            // 
            // textBox_JSONTOKEN
            // 
            textBox_JSONTOKEN.Location = new Point(237, 61);
            textBox_JSONTOKEN.Multiline = true;
            textBox_JSONTOKEN.Name = "textBox_JSONTOKEN";
            textBox_JSONTOKEN.Size = new Size(502, 101);
            textBox_JSONTOKEN.TabIndex = 4;
            // 
            // textBox_register_username
            // 
            textBox_register_username.Location = new Point(94, 21);
            textBox_register_username.Name = "textBox_register_username";
            textBox_register_username.Size = new Size(100, 23);
            textBox_register_username.TabIndex = 5;
            // 
            // textBox_register_password
            // 
            textBox_register_password.Location = new Point(94, 62);
            textBox_register_password.Name = "textBox_register_password";
            textBox_register_password.Size = new Size(100, 23);
            textBox_register_password.TabIndex = 6;
            // 
            // textBox_login_username
            // 
            textBox_login_username.Location = new Point(88, 50);
            textBox_login_username.Name = "textBox_login_username";
            textBox_login_username.Size = new Size(100, 23);
            textBox_login_username.TabIndex = 7;
            // 
            // textBox_login_password
            // 
            textBox_login_password.Location = new Point(88, 85);
            textBox_login_password.Name = "textBox_login_password";
            textBox_login_password.Size = new Size(100, 23);
            textBox_login_password.TabIndex = 8;
            // 
            // label_JSONWebToken
            // 
            label_JSONWebToken.AutoSize = true;
            label_JSONWebToken.Location = new Point(237, 32);
            label_JSONWebToken.Name = "label_JSONWebToken";
            label_JSONWebToken.Size = new Size(99, 15);
            label_JSONWebToken.TabIndex = 9;
            label_JSONWebToken.Text = "JSON Web Token:";
            label_JSONWebToken.Click += label_JSONWebToken_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 24);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 10;
            label1.Text = "User Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 62);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 11;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 86);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 13;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 53);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 12;
            label4.Text = "User Name";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox_register_username);
            groupBox1.Controls.Add(textBox_register_password);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button_invoke_register);
            groupBox1.Location = new Point(43, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(243, 136);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Register";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox_JSONTOKEN);
            groupBox2.Controls.Add(label_JSONWebToken);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(button_invoke_login);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox_login_username);
            groupBox2.Controls.Add(textBox_login_password);
            groupBox2.Location = new Point(43, 168);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(745, 188);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Login";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView_Products);
            groupBox3.Controls.Add(button_Invoke);
            groupBox3.Controls.Add(button_Invoke_Two);
            groupBox3.Location = new Point(42, 373);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(746, 186);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Secured Web API";
            // 
            // dataGridView_Products
            // 
            dataGridView_Products.AllowUserToAddRows = false;
            dataGridView_Products.AllowUserToDeleteRows = false;
            dataGridView_Products.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Products.Location = new Point(245, 25);
            dataGridView_Products.Name = "dataGridView_Products";
            dataGridView_Products.ReadOnly = true;
            dataGridView_Products.Size = new Size(495, 150);
            dataGridView_Products.TabIndex = 2;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 586);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormMain";
            Text = "FormMain";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_Products).EndInit();
            ResumeLayout(false);
        }




        #endregion

        private Button button_Invoke;
        private Button button_Invoke_Two;
        private Button button_invoke_register;
        private Button button_invoke_login;
        private TextBox textBox_JSONTOKEN;
        private TextBox textBox_register_username;
        private TextBox textBox_register_password;
        private TextBox textBox_login_username;
        private TextBox textBox_login_password;
        private Label label_JSONWebToken;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DataGridView dataGridView_Products;
    }
}
