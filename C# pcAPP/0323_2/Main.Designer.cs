namespace sizetest
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LblBetween = new System.Windows.Forms.Label();
            this.DTPLastDate = new System.Windows.Forms.DateTimePicker();
            this.DTPFirstDate = new System.Windows.Forms.DateTimePicker();
            this.btnChartOkay = new System.Windows.Forms.Button();
            this.btnChartPdSales = new System.Windows.Forms.Button();
            this.btnChartSales = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.GridViewMem = new System.Windows.Forms.DataGridView();
            this.GridViewCart = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GridViewProd = new System.Windows.Forms.DataGridView();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnInbound = new System.Windows.Forms.Button();
            this.btnOutbound = new System.Windows.Forms.Button();
            this.btnPdOrder = new System.Windows.Forms.Button();
            this.btnPdMdfy = new System.Windows.Forms.Button();
            this.btnPdRegister = new System.Windows.Forms.Button();
            this.btnPdDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboMemID = new System.Windows.Forms.ComboBox();
            this.textMemPass = new System.Windows.Forms.TextBox();
            this.textMemName = new System.Windows.Forms.TextBox();
            this.textMemPhone = new System.Windows.Forms.TextBox();
            this.textMemMail = new System.Windows.Forms.TextBox();
            this.btnMemOkay = new System.Windows.Forms.Button();
            this.btnMemCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPdOkay = new System.Windows.Forms.Button();
            this.btnPdCancel = new System.Windows.Forms.Button();
            this.textPdName = new System.Windows.Forms.TextBox();
            this.textPdPrice = new System.Windows.Forms.TextBox();
            this.textPdQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.NowDate = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMemDelete = new System.Windows.Forms.Button();
            this.ChartSale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblBetween
            // 
            this.LblBetween.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.LblBetween, 2);
            this.LblBetween.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblBetween.Location = new System.Drawing.Point(246, 807);
            this.LblBetween.Margin = new System.Windows.Forms.Padding(5, 13, 3, 3);
            this.LblBetween.Name = "LblBetween";
            this.LblBetween.Size = new System.Drawing.Size(16, 18);
            this.LblBetween.TabIndex = 28;
            this.LblBetween.Text = "~";
            // 
            // DTPLastDate
            // 
            this.DTPLastDate.CustomFormat = "MM/dd";
            this.DTPLastDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTPLastDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPLastDate.Location = new System.Drawing.Point(265, 802);
            this.DTPLastDate.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.DTPLastDate.Name = "DTPLastDate";
            this.DTPLastDate.Size = new System.Drawing.Size(63, 21);
            this.DTPLastDate.TabIndex = 27;
            // 
            // DTPFirstDate
            // 
            this.DTPFirstDate.CustomFormat = "MM/dd";
            this.DTPFirstDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTPFirstDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFirstDate.Location = new System.Drawing.Point(178, 802);
            this.DTPFirstDate.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.DTPFirstDate.Name = "DTPFirstDate";
            this.DTPFirstDate.Size = new System.Drawing.Size(63, 21);
            this.DTPFirstDate.TabIndex = 26;
            // 
            // btnChartOkay
            // 
            this.btnChartOkay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChartOkay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChartOkay.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChartOkay.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChartOkay.Location = new System.Drawing.Point(328, 794);
            this.btnChartOkay.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartOkay.Name = "btnChartOkay";
            this.btnChartOkay.Size = new System.Drawing.Size(51, 34);
            this.btnChartOkay.TabIndex = 25;
            this.btnChartOkay.Text = "조회";
            this.btnChartOkay.UseVisualStyleBackColor = false;
            // 
            // btnChartPdSales
            // 
            this.btnChartPdSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnChartPdSales, 2);
            this.btnChartPdSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChartPdSales.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChartPdSales.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChartPdSales.Location = new System.Drawing.Point(89, 794);
            this.btnChartPdSales.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartPdSales.Name = "btnChartPdSales";
            this.btnChartPdSales.Size = new System.Drawing.Size(89, 34);
            this.btnChartPdSales.TabIndex = 24;
            this.btnChartPdSales.Text = "상품별";
            this.btnChartPdSales.UseVisualStyleBackColor = false;
            // 
            // btnChartSales
            // 
            this.btnChartSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChartSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChartSales.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChartSales.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChartSales.Location = new System.Drawing.Point(0, 794);
            this.btnChartSales.Margin = new System.Windows.Forms.Padding(0);
            this.btnChartSales.Name = "btnChartSales";
            this.btnChartSales.Size = new System.Drawing.Size(89, 34);
            this.btnChartSales.TabIndex = 23;
            this.btnChartSales.Text = "총매출";
            this.btnChartSales.UseVisualStyleBackColor = false;
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel1.SetColumnSpan(this.btnChart, 8);
            this.btnChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChart.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChart.Location = new System.Drawing.Point(0, 325);
            this.btnChart.Margin = new System.Windows.Forms.Padding(0);
            this.btnChart.Name = "btnChart";
            this.tableLayoutPanel1.SetRowSpan(this.btnChart, 2);
            this.btnChart.Size = new System.Drawing.Size(379, 60);
            this.btnChart.TabIndex = 19;
            this.btnChart.Text = "매출 그래프";
            this.btnChart.UseVisualStyleBackColor = false;
            // 
            // GridViewMem
            // 
            this.GridViewMem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridViewMem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.GridViewMem, 4);
            this.GridViewMem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewMem.Location = new System.Drawing.Point(382, 148);
            this.GridViewMem.Name = "GridViewMem";
            this.tableLayoutPanel1.SetRowSpan(this.GridViewMem, 11);
            this.GridViewMem.RowTemplate.Height = 23;
            this.GridViewMem.Size = new System.Drawing.Size(624, 324);
            this.GridViewMem.TabIndex = 18;
            // 
            // GridViewCart
            // 
            this.GridViewCart.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.GridViewCart, 8);
            this.GridViewCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewCart.Location = new System.Drawing.Point(3, 148);
            this.GridViewCart.Name = "GridViewCart";
            this.tableLayoutPanel1.SetRowSpan(this.GridViewCart, 6);
            this.GridViewCart.RowTemplate.Height = 23;
            this.GridViewCart.Size = new System.Drawing.Size(373, 174);
            this.GridViewCart.TabIndex = 17;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 17;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.120334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.051571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.068762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.085953F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.01719F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.01719F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.085953F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.068762F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.10528F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.10528F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.10528F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.035093F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.007019F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.042111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.021056F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.021056F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.042111F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.GridViewCart, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.GridViewMem, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnChart, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnChartSales, 0, 24);
            this.tableLayoutPanel1.Controls.Add(this.btnChartPdSales, 1, 24);
            this.tableLayoutPanel1.Controls.Add(this.btnChartOkay, 7, 24);
            this.tableLayoutPanel1.Controls.Add(this.DTPFirstDate, 3, 24);
            this.tableLayoutPanel1.Controls.Add(this.DTPLastDate, 6, 24);
            this.tableLayoutPanel1.Controls.Add(this.LblBetween, 4, 24);
            this.tableLayoutPanel1.Controls.Add(this.GridViewProd, 8, 14);
            this.tableLayoutPanel1.Controls.Add(this.btnProduct, 8, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnInbound, 9, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnOutbound, 10, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnPdOrder, 11, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnPdMdfy, 13, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnPdRegister, 14, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnPdDelete, 16, 13);
            this.tableLayoutPanel1.Controls.Add(this.label1, 12, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 12, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 12, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 12, 8);
            this.tableLayoutPanel1.Controls.Add(this.label5, 12, 10);
            this.tableLayoutPanel1.Controls.Add(this.comboMemID, 12, 3);
            this.tableLayoutPanel1.Controls.Add(this.textMemPass, 12, 5);
            this.tableLayoutPanel1.Controls.Add(this.textMemName, 12, 7);
            this.tableLayoutPanel1.Controls.Add(this.textMemPhone, 12, 9);
            this.tableLayoutPanel1.Controls.Add(this.textMemMail, 12, 11);
            this.tableLayoutPanel1.Controls.Add(this.btnMemOkay, 12, 12);
            this.tableLayoutPanel1.Controls.Add(this.btnMemCancel, 15, 12);
            this.tableLayoutPanel1.Controls.Add(this.label7, 11, 14);
            this.tableLayoutPanel1.Controls.Add(this.label8, 11, 16);
            this.tableLayoutPanel1.Controls.Add(this.label9, 11, 18);
            this.tableLayoutPanel1.Controls.Add(this.btnLogout, 15, 24);
            this.tableLayoutPanel1.Controls.Add(this.btnPdOkay, 11, 21);
            this.tableLayoutPanel1.Controls.Add(this.btnPdCancel, 14, 21);
            this.tableLayoutPanel1.Controls.Add(this.textPdName, 11, 15);
            this.tableLayoutPanel1.Controls.Add(this.textPdPrice, 11, 17);
            this.tableLayoutPanel1.Controls.Add(this.textPdQuantity, 11, 19);
            this.tableLayoutPanel1.Controls.Add(this.label10, 13, 24);
            this.tableLayoutPanel1.Controls.Add(this.NowDate, 13, 23);
            this.tableLayoutPanel1.Controls.Add(this.button17, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnMemDelete, 12, 1);
            this.tableLayoutPanel1.Controls.Add(this.ChartSale, 0, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 25;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.2129F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.427565F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.705799F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.705799F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.818283F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.804262F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.139932F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.24956F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.24956F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.713782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.24956F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.139671F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.449275F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.623188F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.321114F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1255, 828);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // GridViewProd
            // 
            this.GridViewProd.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridViewProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.GridViewProd, 3);
            this.GridViewProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewProd.Location = new System.Drawing.Point(382, 526);
            this.GridViewProd.Name = "GridViewProd";
            this.tableLayoutPanel1.SetRowSpan(this.GridViewProd, 11);
            this.GridViewProd.RowTemplate.Height = 23;
            this.GridViewProd.Size = new System.Drawing.Size(561, 299);
            this.GridViewProd.TabIndex = 29;
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProduct.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProduct.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProduct.Location = new System.Drawing.Point(382, 478);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(183, 42);
            this.btnProduct.TabIndex = 30;
            this.btnProduct.Text = "상품 관리";
            this.btnProduct.UseVisualStyleBackColor = false;
            // 
            // btnInbound
            // 
            this.btnInbound.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnInbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInbound.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInbound.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInbound.Location = new System.Drawing.Point(571, 478);
            this.btnInbound.Name = "btnInbound";
            this.btnInbound.Size = new System.Drawing.Size(183, 42);
            this.btnInbound.TabIndex = 30;
            this.btnInbound.Text = "입고 내역";
            this.btnInbound.UseVisualStyleBackColor = false;
            // 
            // btnOutbound
            // 
            this.btnOutbound.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOutbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOutbound.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOutbound.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOutbound.Location = new System.Drawing.Point(760, 478);
            this.btnOutbound.Name = "btnOutbound";
            this.btnOutbound.Size = new System.Drawing.Size(183, 42);
            this.btnOutbound.TabIndex = 30;
            this.btnOutbound.Text = "출고 내역";
            this.btnOutbound.UseVisualStyleBackColor = false;
            // 
            // btnPdOrder
            // 
            this.btnPdOrder.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel1.SetColumnSpan(this.btnPdOrder, 2);
            this.btnPdOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPdOrder.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdOrder.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdOrder.Location = new System.Drawing.Point(949, 478);
            this.btnPdOrder.Name = "btnPdOrder";
            this.btnPdOrder.Size = new System.Drawing.Size(69, 42);
            this.btnPdOrder.TabIndex = 31;
            this.btnPdOrder.Text = "상품\r\n주문";
            this.btnPdOrder.UseVisualStyleBackColor = false;
            // 
            // btnPdMdfy
            // 
            this.btnPdMdfy.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnPdMdfy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPdMdfy.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdMdfy.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdMdfy.Location = new System.Drawing.Point(1024, 478);
            this.btnPdMdfy.Name = "btnPdMdfy";
            this.btnPdMdfy.Size = new System.Drawing.Size(69, 42);
            this.btnPdMdfy.TabIndex = 31;
            this.btnPdMdfy.Text = "상품\r\n수정\r\n";
            this.btnPdMdfy.UseVisualStyleBackColor = false;
            // 
            // btnPdRegister
            // 
            this.btnPdRegister.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel1.SetColumnSpan(this.btnPdRegister, 2);
            this.btnPdRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPdRegister.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdRegister.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdRegister.Location = new System.Drawing.Point(1099, 478);
            this.btnPdRegister.Name = "btnPdRegister";
            this.btnPdRegister.Size = new System.Drawing.Size(68, 42);
            this.btnPdRegister.TabIndex = 31;
            this.btnPdRegister.Text = "상품\r\n등록\r\n";
            this.btnPdRegister.UseVisualStyleBackColor = false;
            // 
            // btnPdDelete
            // 
            this.btnPdDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnPdDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPdDelete.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdDelete.Location = new System.Drawing.Point(1173, 478);
            this.btnPdDelete.Name = "btnPdDelete";
            this.btnPdDelete.Size = new System.Drawing.Size(79, 42);
            this.btnPdDelete.TabIndex = 31;
            this.btnPdDelete.Text = "상품\r\n삭제";
            this.btnPdDelete.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 5);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(1012, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 22);
            this.label1.TabIndex = 33;
            this.label1.Text = "userID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 5);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(1012, 273);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 22);
            this.label3.TabIndex = 33;
            this.label3.Text = "userName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 5);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(1012, 213);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 22);
            this.label2.TabIndex = 33;
            this.label2.Text = "userPassword";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 5);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1012, 333);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 22);
            this.label4.TabIndex = 33;
            this.label4.Text = "userPhone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 5);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1012, 393);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "userMail";
            // 
            // comboMemID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboMemID, 5);
            this.comboMemID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboMemID.FormattingEnabled = true;
            this.comboMemID.Location = new System.Drawing.Point(1012, 178);
            this.comboMemID.Name = "comboMemID";
            this.comboMemID.Size = new System.Drawing.Size(240, 20);
            this.comboMemID.TabIndex = 34;
            // 
            // textMemPass
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textMemPass, 5);
            this.textMemPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMemPass.Location = new System.Drawing.Point(1012, 238);
            this.textMemPass.Name = "textMemPass";
            this.textMemPass.Size = new System.Drawing.Size(240, 21);
            this.textMemPass.TabIndex = 35;
            // 
            // textMemName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textMemName, 5);
            this.textMemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMemName.Location = new System.Drawing.Point(1012, 298);
            this.textMemName.Name = "textMemName";
            this.textMemName.Size = new System.Drawing.Size(240, 21);
            this.textMemName.TabIndex = 35;
            // 
            // textMemPhone
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textMemPhone, 5);
            this.textMemPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMemPhone.Location = new System.Drawing.Point(1012, 358);
            this.textMemPhone.Name = "textMemPhone";
            this.textMemPhone.Size = new System.Drawing.Size(240, 21);
            this.textMemPhone.TabIndex = 35;
            // 
            // textMemMail
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textMemMail, 5);
            this.textMemMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMemMail.Location = new System.Drawing.Point(1012, 418);
            this.textMemMail.Name = "textMemMail";
            this.textMemMail.Size = new System.Drawing.Size(240, 21);
            this.textMemMail.TabIndex = 35;
            // 
            // btnMemOkay
            // 
            this.btnMemOkay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnMemOkay, 3);
            this.btnMemOkay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemOkay.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMemOkay.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMemOkay.Location = new System.Drawing.Point(1012, 448);
            this.btnMemOkay.Name = "btnMemOkay";
            this.btnMemOkay.Size = new System.Drawing.Size(118, 24);
            this.btnMemOkay.TabIndex = 36;
            this.btnMemOkay.Text = "확인";
            this.btnMemOkay.UseVisualStyleBackColor = false;
            // 
            // btnMemCancel
            // 
            this.btnMemCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnMemCancel, 2);
            this.btnMemCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemCancel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMemCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMemCancel.Location = new System.Drawing.Point(1136, 448);
            this.btnMemCancel.Name = "btnMemCancel";
            this.btnMemCancel.Size = new System.Drawing.Size(116, 24);
            this.btnMemCancel.TabIndex = 36;
            this.btnMemCancel.Text = "취소";
            this.btnMemCancel.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label7, 6);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(949, 527);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(303, 27);
            this.label7.TabIndex = 37;
            this.label7.Text = "ProductName";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label8, 6);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(949, 592);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(303, 22);
            this.label8.TabIndex = 37;
            this.label8.Text = "ProductPrice";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label9, 6);
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(949, 648);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 22);
            this.label9.TabIndex = 37;
            this.label9.Text = "ProductQuantity";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnLogout, 2);
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogout.Location = new System.Drawing.Point(1136, 797);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(116, 28);
            this.btnLogout.TabIndex = 38;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnPdOkay
            // 
            this.btnPdOkay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnPdOkay, 3);
            this.btnPdOkay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPdOkay.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdOkay.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdOkay.Location = new System.Drawing.Point(949, 729);
            this.btnPdOkay.Name = "btnPdOkay";
            this.tableLayoutPanel1.SetRowSpan(this.btnPdOkay, 2);
            this.btnPdOkay.Size = new System.Drawing.Size(144, 32);
            this.btnPdOkay.TabIndex = 39;
            this.btnPdOkay.Text = "확인";
            this.btnPdOkay.UseVisualStyleBackColor = false;
            // 
            // btnPdCancel
            // 
            this.btnPdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnPdCancel, 3);
            this.btnPdCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPdCancel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdCancel.Location = new System.Drawing.Point(1099, 729);
            this.btnPdCancel.Name = "btnPdCancel";
            this.tableLayoutPanel1.SetRowSpan(this.btnPdCancel, 2);
            this.btnPdCancel.Size = new System.Drawing.Size(153, 32);
            this.btnPdCancel.TabIndex = 40;
            this.btnPdCancel.Text = "취소";
            this.btnPdCancel.UseVisualStyleBackColor = false;
            // 
            // textPdName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textPdName, 6);
            this.textPdName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPdName.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPdName.Location = new System.Drawing.Point(949, 557);
            this.textPdName.Name = "textPdName";
            this.textPdName.Size = new System.Drawing.Size(303, 25);
            this.textPdName.TabIndex = 41;
            // 
            // textPdPrice
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textPdPrice, 6);
            this.textPdPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPdPrice.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPdPrice.Location = new System.Drawing.Point(949, 617);
            this.textPdPrice.Name = "textPdPrice";
            this.textPdPrice.Size = new System.Drawing.Size(303, 25);
            this.textPdPrice.TabIndex = 41;
            // 
            // textPdQuantity
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textPdQuantity, 6);
            this.textPdQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPdQuantity.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPdQuantity.Location = new System.Drawing.Point(949, 673);
            this.textPdQuantity.Name = "textPdQuantity";
            this.textPdQuantity.Size = new System.Drawing.Size(303, 25);
            this.textPdQuantity.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label10, 2);
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(1024, 799);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 29);
            this.label10.TabIndex = 42;
            this.label10.Text = "admin 님";
            // 
            // NowDate
            // 
            this.NowDate.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.NowDate, 4);
            this.NowDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NowDate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NowDate.Location = new System.Drawing.Point(1024, 769);
            this.NowDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.NowDate.Name = "NowDate";
            this.NowDate.Size = new System.Drawing.Size(228, 25);
            this.NowDate.TabIndex = 43;
            this.NowDate.Text = "2020년 03월 23일 월요일 16:12";
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel1.SetColumnSpan(this.button17, 4);
            this.button17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button17.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button17.ForeColor = System.Drawing.SystemColors.Window;
            this.button17.Location = new System.Drawing.Point(382, 87);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(624, 55);
            this.button17.TabIndex = 45;
            this.button17.Text = "회원 관리";
            this.button17.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 8);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(3, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(373, 55);
            this.button1.TabIndex = 46;
            this.button1.Text = "카트 실시간 현황";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnMemDelete
            // 
            this.btnMemDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel1.SetColumnSpan(this.btnMemDelete, 5);
            this.btnMemDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMemDelete.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMemDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMemDelete.Location = new System.Drawing.Point(1012, 87);
            this.btnMemDelete.Name = "btnMemDelete";
            this.btnMemDelete.Size = new System.Drawing.Size(240, 55);
            this.btnMemDelete.TabIndex = 47;
            this.btnMemDelete.Text = "회원 삭제";
            this.btnMemDelete.UseVisualStyleBackColor = false;
            // 
            // ChartSale
            // 
            this.ChartSale.BorderlineColor = System.Drawing.Color.Black;
            this.ChartSale.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            this.ChartSale.ChartAreas.Add(chartArea4);
            this.tableLayoutPanel1.SetColumnSpan(this.ChartSale, 8);
            this.ChartSale.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.ChartSale.Legends.Add(legend4);
            this.ChartSale.Location = new System.Drawing.Point(3, 388);
            this.ChartSale.Name = "ChartSale";
            this.tableLayoutPanel1.SetRowSpan(this.ChartSale, 14);
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.ChartSale.Series.Add(series4);
            this.ChartSale.Size = new System.Drawing.Size(373, 403);
            this.ChartSale.TabIndex = 48;
            this.ChartSale.Text = "chart1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 17);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1249, 78);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1255, 828);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewMem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView GridViewCart;
        private System.Windows.Forms.DataGridView GridViewMem;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnChartSales;
        private System.Windows.Forms.Button btnChartPdSales;
        private System.Windows.Forms.Button btnChartOkay;
        private System.Windows.Forms.DateTimePicker DTPFirstDate;
        private System.Windows.Forms.DateTimePicker DTPLastDate;
        private System.Windows.Forms.Label LblBetween;
        private System.Windows.Forms.DataGridView GridViewProd;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnInbound;
        private System.Windows.Forms.Button btnOutbound;
        private System.Windows.Forms.Button btnPdOrder;
        private System.Windows.Forms.Button btnPdMdfy;
        private System.Windows.Forms.Button btnPdRegister;
        private System.Windows.Forms.Button btnPdDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboMemID;
        private System.Windows.Forms.TextBox textMemPass;
        private System.Windows.Forms.TextBox textMemName;
        private System.Windows.Forms.TextBox textMemPhone;
        private System.Windows.Forms.TextBox textMemMail;
        private System.Windows.Forms.Button btnMemOkay;
        private System.Windows.Forms.Button btnMemCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPdOkay;
        private System.Windows.Forms.Button btnPdCancel;
        private System.Windows.Forms.TextBox textPdName;
        private System.Windows.Forms.TextBox textPdPrice;
        private System.Windows.Forms.TextBox textPdQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label NowDate;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMemDelete;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartSale;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

