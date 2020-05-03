namespace smartcart_1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPdOrder = new System.Windows.Forms.Button();
            this.btnPdDel = new System.Windows.Forms.Button();
            this.btnPdMdfy = new System.Windows.Forms.Button();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnPdChart = new System.Windows.Forms.Button();
            this.btnSalesChart = new System.Windows.Forms.Button();
            this.chartSales2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLogout = new System.Windows.Forms.Button();
            this.LblLogname = new System.Windows.Forms.Label();
            this.btnMemDel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIB = new System.Windows.Forms.Button();
            this.btnOB = new System.Windows.Forms.Button();
            this.btnPdRegi = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.LbBetween = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btnChartDate = new System.Windows.Forms.Button();
            this.firstDTP = new System.Windows.Forms.DateTimePicker();
            this.lastDTP = new System.Windows.Forms.DateTimePicker();
            this.firstDTP2 = new System.Windows.Forms.DateTimePicker();
            this.lastDTP2 = new System.Windows.Forms.DateTimePicker();
            this.btnChartDate2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(174, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(923, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "ICD SMART CART MANAGEMENT PROGRAM             \r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCart.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCart.Location = new System.Drawing.Point(25, 76);
            this.btnCart.Margin = new System.Windows.Forms.Padding(4);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(324, 68);
            this.btnCart.TabIndex = 1;
            this.btnCart.Text = "카트 실시간 현황";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnMember
            // 
            this.btnMember.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMember.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnMember.FlatAppearance.BorderSize = 0;
            this.btnMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMember.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMember.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMember.Location = new System.Drawing.Point(356, 76);
            this.btnMember.Margin = new System.Windows.Forms.Padding(4);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(181, 68);
            this.btnMember.TabIndex = 1;
            this.btnMember.Text = "회원관리";
            this.btnMember.UseVisualStyleBackColor = false;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnProduct.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProduct.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProduct.Location = new System.Drawing.Point(545, 76);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(181, 68);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "상품관리";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSales.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnSales.FlatAppearance.BorderSize = 0;
            this.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSales.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSales.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSales.Location = new System.Drawing.Point(1115, 76);
            this.btnSales.Margin = new System.Windows.Forms.Padding(4);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(266, 68);
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "매출 그래프";
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(25, 169);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1356, 523);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnPdOrder
            // 
            this.btnPdOrder.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnPdOrder.FlatAppearance.BorderSize = 0;
            this.btnPdOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdOrder.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdOrder.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdOrder.Location = new System.Drawing.Point(29, 746);
            this.btnPdOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnPdOrder.Name = "btnPdOrder";
            this.btnPdOrder.Size = new System.Drawing.Size(169, 52);
            this.btnPdOrder.TabIndex = 3;
            this.btnPdOrder.Text = "상품 주문";
            this.btnPdOrder.UseVisualStyleBackColor = false;
            this.btnPdOrder.Visible = false;
            this.btnPdOrder.Click += new System.EventHandler(this.btnPdOrder_Click);
            // 
            // btnPdDel
            // 
            this.btnPdDel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdDel.FlatAppearance.BorderSize = 0;
            this.btnPdDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdDel.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdDel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdDel.Location = new System.Drawing.Point(384, 734);
            this.btnPdDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnPdDel.Name = "btnPdDel";
            this.btnPdDel.Size = new System.Drawing.Size(172, 52);
            this.btnPdDel.TabIndex = 3;
            this.btnPdDel.Text = "상품 삭제";
            this.btnPdDel.UseVisualStyleBackColor = false;
            this.btnPdDel.Visible = false;
            this.btnPdDel.Click += new System.EventHandler(this.btnPdDel_Click);
            // 
            // btnPdMdfy
            // 
            this.btnPdMdfy.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdMdfy.FlatAppearance.BorderSize = 0;
            this.btnPdMdfy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdMdfy.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdMdfy.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdMdfy.Location = new System.Drawing.Point(205, 746);
            this.btnPdMdfy.Margin = new System.Windows.Forms.Padding(4);
            this.btnPdMdfy.Name = "btnPdMdfy";
            this.btnPdMdfy.Size = new System.Drawing.Size(172, 52);
            this.btnPdMdfy.TabIndex = 3;
            this.btnPdMdfy.Text = "가격 수정";
            this.btnPdMdfy.UseVisualStyleBackColor = false;
            this.btnPdMdfy.Visible = false;
            this.btnPdMdfy.Click += new System.EventHandler(this.btnPdMdfy_Click);
            // 
            // chartSales
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSales.Legends.Add(legend1);
            this.chartSales.Location = new System.Drawing.Point(25, 446);
            this.chartSales.Margin = new System.Windows.Forms.Padding(4);
            this.chartSales.Name = "chartSales";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "price";
            this.chartSales.Series.Add(series1);
            this.chartSales.Size = new System.Drawing.Size(664, 246);
            this.chartSales.TabIndex = 4;
            this.chartSales.Text = "매출 그래프";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "salesame";
            title1.Text = "총 매출액";
            this.chartSales.Titles.Add(title1);
            this.chartSales.Visible = false;
            this.chartSales.Click += new System.EventHandler(this.chartSales_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(1099, 766);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(267, 28);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // btnPdChart
            // 
            this.btnPdChart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdChart.FlatAppearance.BorderSize = 0;
            this.btnPdChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdChart.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdChart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdChart.Location = new System.Drawing.Point(649, 766);
            this.btnPdChart.Margin = new System.Windows.Forms.Padding(4);
            this.btnPdChart.Name = "btnPdChart";
            this.btnPdChart.Size = new System.Drawing.Size(310, 52);
            this.btnPdChart.TabIndex = 3;
            this.btnPdChart.Text = "상품별 판매 그래프";
            this.btnPdChart.UseVisualStyleBackColor = false;
            this.btnPdChart.Visible = false;
            this.btnPdChart.Click += new System.EventHandler(this.btnPdChart_Click);
            // 
            // btnSalesChart
            // 
            this.btnSalesChart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSalesChart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalesChart.FlatAppearance.BorderSize = 0;
            this.btnSalesChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesChart.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSalesChart.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSalesChart.Location = new System.Drawing.Point(966, 746);
            this.btnSalesChart.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalesChart.Name = "btnSalesChart";
            this.btnSalesChart.Size = new System.Drawing.Size(274, 52);
            this.btnSalesChart.TabIndex = 3;
            this.btnSalesChart.Text = "총매출 그래프";
            this.btnSalesChart.UseVisualStyleBackColor = false;
            this.btnSalesChart.Visible = false;
            this.btnSalesChart.Click += new System.EventHandler(this.btnSalesChart_Click);
            // 
            // chartSales2
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSales2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSales2.Legends.Add(legend2);
            this.chartSales2.Location = new System.Drawing.Point(665, 320);
            this.chartSales2.Margin = new System.Windows.Forms.Padding(4);
            this.chartSales2.Name = "chartSales2";
            this.chartSales2.Size = new System.Drawing.Size(605, 391);
            this.chartSales2.TabIndex = 6;
            this.chartSales2.Text = "chart1";
            title2.BackColor = System.Drawing.Color.White;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "productname";
            title2.Text = "상품별 판매 그래프";
            this.chartSales2.Titles.Add(title2);
            this.chartSales2.Visible = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLogout.Location = new System.Drawing.Point(1247, 719);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout\r\n";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // LblLogname
            // 
            this.LblLogname.AutoSize = true;
            this.LblLogname.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblLogname.Location = new System.Drawing.Point(1094, 730);
            this.LblLogname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblLogname.Name = "LblLogname";
            this.LblLogname.Size = new System.Drawing.Size(120, 28);
            this.LblLogname.TabIndex = 8;
            this.LblLogname.Text = "admin님";
            this.LblLogname.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblLogname.Click += new System.EventHandler(this.LblLogname_Click);
            // 
            // btnMemDel
            // 
            this.btnMemDel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMemDel.FlatAppearance.BorderSize = 0;
            this.btnMemDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemDel.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMemDel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMemDel.Location = new System.Drawing.Point(29, 787);
            this.btnMemDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnMemDel.Name = "btnMemDel";
            this.btnMemDel.Size = new System.Drawing.Size(172, 52);
            this.btnMemDel.TabIndex = 3;
            this.btnMemDel.Text = "회원 삭제";
            this.btnMemDel.UseVisualStyleBackColor = false;
            this.btnMemDel.Visible = false;
            this.btnMemDel.Click += new System.EventHandler(this.btnMemDel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1412, 154);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnIB
            // 
            this.btnIB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnIB.FlatAppearance.BorderSize = 0;
            this.btnIB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIB.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnIB.ForeColor = System.Drawing.SystemColors.Window;
            this.btnIB.Location = new System.Drawing.Point(924, 76);
            this.btnIB.Margin = new System.Windows.Forms.Padding(4);
            this.btnIB.Name = "btnIB";
            this.btnIB.Size = new System.Drawing.Size(181, 68);
            this.btnIB.TabIndex = 10;
            this.btnIB.Text = "입고내역";
            this.btnIB.UseVisualStyleBackColor = false;
            this.btnIB.Click += new System.EventHandler(this.btnIB_Click);
            // 
            // btnOB
            // 
            this.btnOB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnOB.FlatAppearance.BorderSize = 0;
            this.btnOB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOB.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOB.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOB.Location = new System.Drawing.Point(734, 76);
            this.btnOB.Margin = new System.Windows.Forms.Padding(4);
            this.btnOB.Name = "btnOB";
            this.btnOB.Size = new System.Drawing.Size(181, 68);
            this.btnOB.TabIndex = 10;
            this.btnOB.Text = "출고내역";
            this.btnOB.UseVisualStyleBackColor = false;
            this.btnOB.Click += new System.EventHandler(this.btnOB_Click);
            // 
            // btnPdRegi
            // 
            this.btnPdRegi.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPdRegi.FlatAppearance.BorderSize = 0;
            this.btnPdRegi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdRegi.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPdRegi.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPdRegi.Location = new System.Drawing.Point(563, 744);
            this.btnPdRegi.Margin = new System.Windows.Forms.Padding(4);
            this.btnPdRegi.Name = "btnPdRegi";
            this.btnPdRegi.Size = new System.Drawing.Size(172, 52);
            this.btnPdRegi.TabIndex = 11;
            this.btnPdRegi.Text = "상품 등록";
            this.btnPdRegi.UseVisualStyleBackColor = false;
            this.btnPdRegi.Visible = false;
            this.btnPdRegi.Click += new System.EventHandler(this.btnPdRegi_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.Location = new System.Drawing.Point(713, 181);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(654, 503);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.Visible = false;
            // 
            // LbBetween
            // 
            this.LbBetween.AutoSize = true;
            this.LbBetween.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LbBetween.Location = new System.Drawing.Point(208, 703);
            this.LbBetween.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbBetween.Name = "LbBetween";
            this.LbBetween.Size = new System.Drawing.Size(30, 24);
            this.LbBetween.TabIndex = 14;
            this.LbBetween.Text = "~";
            this.LbBetween.Visible = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(713, 181);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 27;
            this.dataGridView3.Size = new System.Drawing.Size(654, 503);
            this.dataGridView3.TabIndex = 15;
            this.dataGridView3.Visible = false;
            // 
            // btnChartDate
            // 
            this.btnChartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChartDate.FlatAppearance.BorderSize = 0;
            this.btnChartDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartDate.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChartDate.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChartDate.Location = new System.Drawing.Point(448, 697);
            this.btnChartDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnChartDate.Name = "btnChartDate";
            this.btnChartDate.Size = new System.Drawing.Size(90, 30);
            this.btnChartDate.TabIndex = 16;
            this.btnChartDate.Text = "확인";
            this.btnChartDate.UseVisualStyleBackColor = false;
            this.btnChartDate.Visible = false;
            this.btnChartDate.Click += new System.EventHandler(this.btnChartDate_Click);
            // 
            // firstDTP
            // 
            this.firstDTP.CustomFormat = "yyyy/MM/dd";
            this.firstDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.firstDTP.Location = new System.Drawing.Point(29, 697);
            this.firstDTP.Margin = new System.Windows.Forms.Padding(4);
            this.firstDTP.Name = "firstDTP";
            this.firstDTP.Size = new System.Drawing.Size(162, 28);
            this.firstDTP.TabIndex = 17;
            this.firstDTP.Value = new System.DateTime(2020, 3, 19, 11, 3, 24, 0);
            this.firstDTP.Visible = false;
            // 
            // lastDTP
            // 
            this.lastDTP.CustomFormat = "yyyy/MM/dd";
            this.lastDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lastDTP.Location = new System.Drawing.Point(258, 697);
            this.lastDTP.Margin = new System.Windows.Forms.Padding(4);
            this.lastDTP.Name = "lastDTP";
            this.lastDTP.Size = new System.Drawing.Size(162, 28);
            this.lastDTP.TabIndex = 18;
            this.lastDTP.Visible = false;
            // 
            // firstDTP2
            // 
            this.firstDTP2.CustomFormat = "yyyy/MM/dd";
            this.firstDTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.firstDTP2.Location = new System.Drawing.Point(29, 697);
            this.firstDTP2.Margin = new System.Windows.Forms.Padding(4);
            this.firstDTP2.Name = "firstDTP2";
            this.firstDTP2.Size = new System.Drawing.Size(162, 28);
            this.firstDTP2.TabIndex = 19;
            this.firstDTP2.Visible = false;
            // 
            // lastDTP2
            // 
            this.lastDTP2.CustomFormat = "yyyy/MM/dd";
            this.lastDTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lastDTP2.Location = new System.Drawing.Point(258, 697);
            this.lastDTP2.Margin = new System.Windows.Forms.Padding(4);
            this.lastDTP2.Name = "lastDTP2";
            this.lastDTP2.Size = new System.Drawing.Size(162, 28);
            this.lastDTP2.TabIndex = 20;
            this.lastDTP2.Visible = false;
            // 
            // btnChartDate2
            // 
            this.btnChartDate2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChartDate2.FlatAppearance.BorderSize = 0;
            this.btnChartDate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartDate2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChartDate2.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChartDate2.Location = new System.Drawing.Point(448, 698);
            this.btnChartDate2.Margin = new System.Windows.Forms.Padding(4);
            this.btnChartDate2.Name = "btnChartDate2";
            this.btnChartDate2.Size = new System.Drawing.Size(90, 28);
            this.btnChartDate2.TabIndex = 21;
            this.btnChartDate2.Text = "확인";
            this.btnChartDate2.UseVisualStyleBackColor = false;
            this.btnChartDate2.Visible = false;
            this.btnChartDate2.Click += new System.EventHandler(this.btnChartDate2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1409, 833);
            this.Controls.Add(this.btnChartDate2);
            this.Controls.Add(this.lastDTP2);
            this.Controls.Add(this.firstDTP2);
            this.Controls.Add(this.lastDTP);
            this.Controls.Add(this.firstDTP);
            this.Controls.Add(this.btnChartDate);
            this.Controls.Add(this.LbBetween);
            this.Controls.Add(this.btnPdRegi);
            this.Controls.Add(this.btnOB);
            this.Controls.Add(this.btnIB);
            this.Controls.Add(this.LblLogname);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSalesChart);
            this.Controls.Add(this.chartSales2);
            this.Controls.Add(this.btnPdChart);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.chartSales);
            this.Controls.Add(this.btnMemDel);
            this.Controls.Add(this.btnPdMdfy);
            this.Controls.Add(this.btnPdDel);
            this.Controls.Add(this.btnPdOrder);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnMember);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "관리자";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPdOrder;
        private System.Windows.Forms.Button btnPdDel;
        private System.Windows.Forms.Button btnPdMdfy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnPdChart;
        private System.Windows.Forms.Button btnSalesChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label LblLogname;
        private System.Windows.Forms.Button btnMemDel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIB;
        private System.Windows.Forms.Button btnOB;
        private System.Windows.Forms.Button btnPdRegi;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label LbBetween;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btnChartDate;
        private System.Windows.Forms.DateTimePicker lastDTP;
        private System.Windows.Forms.DateTimePicker lastDTP2;
        private System.Windows.Forms.Button btnChartDate2;
        private System.Windows.Forms.DateTimePicker firstDTP;
        private System.Windows.Forms.DateTimePicker firstDTP2;
    }
}

