namespace client_chart
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Nickname = new System.Windows.Forms.TextBox();
            this.textBox_Chat = new System.Windows.Forms.TextBox();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_SendMessage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Nickname
            // 
            this.textBox_Nickname.Location = new System.Drawing.Point(133, 30);
            this.textBox_Nickname.Name = "textBox_Nickname";
            this.textBox_Nickname.Size = new System.Drawing.Size(586, 26);
            this.textBox_Nickname.TabIndex = 0;
            // 
            // textBox_Chat
            // 
            this.textBox_Chat.Location = new System.Drawing.Point(22, 200);
            this.textBox_Chat.Multiline = true;
            this.textBox_Chat.Name = "textBox_Chat";
            this.textBox_Chat.Size = new System.Drawing.Size(697, 301);
            this.textBox_Chat.TabIndex = 1;
            this.textBox_Chat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Chat_KeyDown);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(22, 85);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(697, 79);
            this.textBox_Message.TabIndex = 2;
            this.textBox_Message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Message_KeyDown);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(765, 30);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(210, 40);
            this.button_Connect.TabIndex = 3;
            this.button_Connect.Text = "Подключиться";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_SendMessage
            // 
            this.button_SendMessage.Location = new System.Drawing.Point(765, 85);
            this.button_SendMessage.Name = "button_SendMessage";
            this.button_SendMessage.Size = new System.Drawing.Size(210, 79);
            this.button_SendMessage.TabIndex = 4;
            this.button_SendMessage.Text = "Отправить сообщение";
            this.button_SendMessage.UseVisualStyleBackColor = true;
            this.button_SendMessage.Click += new System.EventHandler(this.button_SendMessage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите имя";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 638);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_SendMessage);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.textBox_Chat);
            this.Controls.Add(this.textBox_Nickname);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Nickname;
        private System.Windows.Forms.TextBox textBox_Chat;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_SendMessage;
        private System.Windows.Forms.Label label1;
    }
}

