
namespace CG_6
{
    partial class Form
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
            this.components = new System.ComponentModel.Container();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.start_scale = new System.Windows.Forms.Button();
            this.Divide_and_Conquer = new System.Windows.Forms.Button();
            this.Cleaning = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraph
            // 
            this.zedGraph.Location = new System.Drawing.Point(35, 12);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(955, 690);
            this.zedGraph.TabIndex = 0;
            this.zedGraph.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.zedGraph_MouseDoubleClick);
            // 
            // start_scale
            // 
            this.start_scale.Location = new System.Drawing.Point(996, 41);
            this.start_scale.Name = "start_scale";
            this.start_scale.Size = new System.Drawing.Size(124, 51);
            this.start_scale.TabIndex = 1;
            this.start_scale.Text = "start scale";
            this.start_scale.UseVisualStyleBackColor = true;
            this.start_scale.Click += new System.EventHandler(this.start_scale_Click);
            // 
            // Divide_and_Conquer
            // 
            this.Divide_and_Conquer.Location = new System.Drawing.Point(996, 108);
            this.Divide_and_Conquer.Name = "Divide_and_Conquer";
            this.Divide_and_Conquer.Size = new System.Drawing.Size(124, 55);
            this.Divide_and_Conquer.TabIndex = 2;
            this.Divide_and_Conquer.Text = "Algorithm";
            this.Divide_and_Conquer.UseVisualStyleBackColor = true;
            this.Divide_and_Conquer.Click += new System.EventHandler(this.Divide_and_Conquer_Click);
            // 
            // Cleaning
            // 
            this.Cleaning.Location = new System.Drawing.Point(997, 184);
            this.Cleaning.Name = "Cleaning";
            this.Cleaning.Size = new System.Drawing.Size(123, 50);
            this.Cleaning.TabIndex = 3;
            this.Cleaning.Text = "Cleaning";
            this.Cleaning.UseVisualStyleBackColor = true;
            this.Cleaning.Click += new System.EventHandler(this.Cleaning_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 748);
            this.Controls.Add(this.Cleaning);
            this.Controls.Add(this.Divide_and_Conquer);
            this.Controls.Add(this.start_scale);
            this.Controls.Add(this.zedGraph);
            this.Name = "Form";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
        private System.Windows.Forms.Button start_scale;
        private System.Windows.Forms.Button Divide_and_Conquer;
        private System.Windows.Forms.Button Cleaning;
    }
}

