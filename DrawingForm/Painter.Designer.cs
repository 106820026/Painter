namespace DrawingForm
{
    partial class Form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._selectTextLabel = new System.Windows.Forms.Label();
            this._shapePositionTextLabel = new System.Windows.Forms.Label();
            this._line = new System.Windows.Forms.Button();
            this._hexagon = new System.Windows.Forms.Button();
            this._rectangle = new System.Windows.Forms.Button();
            this._clear = new System.Windows.Forms.Button();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._undo = new System.Windows.Forms.ToolStripLabel();
            this._redo = new System.Windows.Forms.ToolStripLabel();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._tableLayoutPanel1.SuspendLayout();
            this._tableLayoutPanel.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel1
            // 
            this._tableLayoutPanel1.ColumnCount = 2;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this._tableLayoutPanel1.Controls.Add(this._selectTextLabel, 0, 0);
            this._tableLayoutPanel1.Controls.Add(this._shapePositionTextLabel, 1, 0);
            this._tableLayoutPanel1.Location = new System.Drawing.Point(1307, 881);
            this._tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this._tableLayoutPanel1.Name = "_tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 1;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(493, 26);
            this._tableLayoutPanel1.TabIndex = 1;
            // 
            // _selectTextLabel
            // 
            this._selectTextLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._selectTextLabel.AutoSize = true;
            this._selectTextLabel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._selectTextLabel.Location = new System.Drawing.Point(31, 3);
            this._selectTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._selectTextLabel.Name = "_selectTextLabel";
            this._selectTextLabel.Size = new System.Drawing.Size(61, 19);
            this._selectTextLabel.TabIndex = 0;
            this._selectTextLabel.Text = "Select : ";
            // 
            // _shapePositionTextLabel
            // 
            this._shapePositionTextLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._shapePositionTextLabel.AutoSize = true;
            this._shapePositionTextLabel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._shapePositionTextLabel.Location = new System.Drawing.Point(308, 3);
            this._shapePositionTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._shapePositionTextLabel.Name = "_shapePositionTextLabel";
            this._shapePositionTextLabel.Size = new System.Drawing.Size(0, 19);
            this._shapePositionTextLabel.TabIndex = 4;
            // 
            // _line
            // 
            this._line.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._line.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._line.Location = new System.Drawing.Point(599, 2);
            this._line.Margin = new System.Windows.Forms.Padding(149, 2, 149, 2);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(152, 38);
            this._line.TabIndex = 3;
            this._line.Tag = "1";
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _hexagon
            // 
            this._hexagon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._hexagon.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._hexagon.Location = new System.Drawing.Point(1049, 2);
            this._hexagon.Margin = new System.Windows.Forms.Padding(149, 2, 149, 2);
            this._hexagon.Name = "_hexagon";
            this._hexagon.Size = new System.Drawing.Size(152, 38);
            this._hexagon.TabIndex = 1;
            this._hexagon.Tag = "2";
            this._hexagon.Text = "Hexagon";
            this._hexagon.UseVisualStyleBackColor = true;
            this._hexagon.Click += new System.EventHandler(this.HandleHexagonButtonClick);
            // 
            // _rectangle
            // 
            this._rectangle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._rectangle.Location = new System.Drawing.Point(149, 2);
            this._rectangle.Margin = new System.Windows.Forms.Padding(149, 2, 149, 2);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(152, 38);
            this._rectangle.TabIndex = 0;
            this._rectangle.Tag = "0";
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            this._rectangle.Click += new System.EventHandler(this.HandleRectangleButtonClick);
            // 
            // _clear
            // 
            this._clear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._clear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._clear.Location = new System.Drawing.Point(1499, 2);
            this._clear.Margin = new System.Windows.Forms.Padding(149, 2, 149, 2);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(152, 38);
            this._clear.TabIndex = 2;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this._tableLayoutPanel.ColumnCount = 4;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00061F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this._tableLayoutPanel.Controls.Add(this._line, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._hexagon, 1, 0);
            this._tableLayoutPanel.Controls.Add(this._rectangle, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._clear, 3, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this._tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 1;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(1800, 42);
            this._tableLayoutPanel.TabIndex = 3;
            // 
            // _undo
            // 
            this._undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._undo.Enabled = false;
            this._undo.Name = "_undo";
            this._undo.Size = new System.Drawing.Size(48, 22);
            this._undo.Text = "Undo";
            this._undo.Click += new System.EventHandler(this.UndoHandler);
            // 
            // _redo
            // 
            this._redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._redo.Enabled = false;
            this._redo.Name = "_redo";
            this._redo.Size = new System.Drawing.Size(46, 22);
            this._redo.Text = "Redo";
            this._redo.Click += new System.EventHandler(this.RedoHandler);
            // 
            // _toolStrip1
            // 
            this._toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._undo,
            this._redo});
            this._toolStrip1.Location = new System.Drawing.Point(0, 0);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1800, 25);
            this._toolStrip1.TabIndex = 2;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 911);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form";
            this.Text = "Painter";
            this._tableLayoutPanel1.ResumeLayout(false);
            this._tableLayoutPanel1.PerformLayout();
            this._tableLayoutPanel.ResumeLayout(false);
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
        private System.Windows.Forms.Label _selectTextLabel;
        private System.Windows.Forms.Label _shapePositionTextLabel;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Button _hexagon;
        private System.Windows.Forms.Button _rectangle;
        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.ToolStripLabel _undo;
        private System.Windows.Forms.ToolStripLabel _redo;
        private System.Windows.Forms.ToolStrip _toolStrip1;
    }
}

