namespace smartcart
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCart = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnInbound = new System.Windows.Forms.Button();
            this.btnOutbound = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.LblMain = new System.Windows.Forms.Label();
            this.LblCart = new System.Windows.Forms.Label();
            this.LblUsingUser = new System.Windows.Forms.Label();
            this.LblCartInfo = new System.Windows.Forms.Label();
            this.LblMember = new System.Windows.Forms.Label();
            this.LblProduct = new System.Windows.Forms.Label();
            this.LblInbound = new System.Windows.Forms.Label();
            this.LblOutbound = new System.Windows.Forms.Label();
            this.LblChart = new System.Windows.Forms.Label();
            this.LblMemDel = new System.Windows.Forms.Label();
            this.LblPdOrder = new System.Windows.Forms.Label();
            this.LblPriceMdfy = new System.Windows.Forms.Label();
            this.LblPdRegi = new System.Windows.Forms.Label();
            this.LblPdDel = new System.Windows.Forms.Label();
            this.LblPdInbound = new System.Windows.Forms.Label();
            this.LblPdOutbound = new System.Windows.Forms.Label();
            this.LblSaleChart = new System.Windows.Forms.Label();
            this.LblProdChart = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LblLiveInfo = new System.Windows.Forms.Label();
            this.LblNowDate = new System.Windows.Forms.Label();
            this.LblAdmin = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(-5, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1083, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Location = new System.Drawing.Point(4, 80);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(75, 61);
            this.btnCart.TabIndex = 1;
            this.btnCart.Text = "실시간\r\n정보";
            this.btnCart.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox2.Location = new System.Drawing.Point(-5, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 499);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkBlue;
            this.pictureBox3.Location = new System.Drawing.Point(81, 43);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(133, 499);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // btnMember
            // 
            this.btnMember.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnMember.FlatAppearance.BorderSize = 0;
            this.btnMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMember.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMember.ForeColor = System.Drawing.Color.White;
            this.btnMember.Location = new System.Drawing.Point(4, 147);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(75, 61);
            this.btnMember.TabIndex = 1;
            this.btnMember.Text = "회원\r\n관리";
            this.btnMember.UseVisualStyleBackColor = false;
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Location = new System.Drawing.Point(4, 214);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(75, 61);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "상품\r\n관리";
            this.btnProduct.UseVisualStyleBackColor = false;
            // 
            // btnInbound
            // 
            this.btnInbound.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnInbound.FlatAppearance.BorderSize = 0;
            this.btnInbound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInbound.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInbound.ForeColor = System.Drawing.Color.White;
            this.btnInbound.Location = new System.Drawing.Point(4, 281);
            this.btnInbound.Name = "btnInbound";
            this.btnInbound.Size = new System.Drawing.Size(75, 61);
            this.btnInbound.TabIndex = 1;
            this.btnInbound.Text = "입고\r\n내역";
            this.btnInbound.UseVisualStyleBackColor = false;
            // 
            // btnOutbound
            // 
            this.btnOutbound.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOutbound.FlatAppearance.BorderSize = 0;
            this.btnOutbound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutbound.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOutbound.ForeColor = System.Drawing.Color.White;
            this.btnOutbound.Location = new System.Drawing.Point(4, 348);
            this.btnOutbound.Name = "btnOutbound";
            this.btnOutbound.Size = new System.Drawing.Size(75, 61);
            this.btnOutbound.TabIndex = 1;
            this.btnOutbound.Text = "출고\r\n내역";
            this.btnOutbound.UseVisualStyleBackColor = false;
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnChart.FlatAppearance.BorderSize = 0;
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChart.ForeColor = System.Drawing.Color.White;
            this.btnChart.Location = new System.Drawing.Point(4, 415);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(75, 61);
            this.btnChart.TabIndex = 1;
            this.btnChart.Text = "통 계";
            this.btnChart.UseVisualStyleBackColor = false;
            // 
            // LblMain
            // 
            this.LblMain.AutoSize = true;
            this.LblMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblMain.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblMain.ForeColor = System.Drawing.SystemColors.Window;
            this.LblMain.Location = new System.Drawing.Point(56, 13);
            this.LblMain.Name = "LblMain";
            this.LblMain.Size = new System.Drawing.Size(339, 21);
            this.LblMain.TabIndex = 4;
            this.LblMain.Text = "ICD SMARTCART ADMINISTRATOR";
            // 
            // LblCart
            // 
            this.LblCart.AutoSize = true;
            this.LblCart.BackColor = System.Drawing.Color.DarkBlue;
            this.LblCart.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblCart.ForeColor = System.Drawing.SystemColors.Window;
            this.LblCart.Location = new System.Drawing.Point(89, 80);
            this.LblCart.Name = "LblCart";
            this.LblCart.Size = new System.Drawing.Size(116, 19);
            this.LblCart.TabIndex = 6;
            this.LblCart.Text = "실시간 정보";
            // 
            // LblUsingUser
            // 
            this.LblUsingUser.AutoSize = true;
            this.LblUsingUser.BackColor = System.Drawing.Color.DarkBlue;
            this.LblUsingUser.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblUsingUser.ForeColor = System.Drawing.SystemColors.Window;
            this.LblUsingUser.Location = new System.Drawing.Point(97, 147);
            this.LblUsingUser.Name = "LblUsingUser";
            this.LblUsingUser.Size = new System.Drawing.Size(89, 13);
            this.LblUsingUser.TabIndex = 6;
            this.LblUsingUser.Text = "실시간 사용자";
            // 
            // LblCartInfo
            // 
            this.LblCartInfo.AutoSize = true;
            this.LblCartInfo.BackColor = System.Drawing.Color.DarkBlue;
            this.LblCartInfo.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblCartInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.LblCartInfo.Location = new System.Drawing.Point(97, 125);
            this.LblCartInfo.Name = "LblCartInfo";
            this.LblCartInfo.Size = new System.Drawing.Size(63, 13);
            this.LblCartInfo.TabIndex = 6;
            this.LblCartInfo.Text = "카트 정보";
            // 
            // LblMember
            // 
            this.LblMember.AutoSize = true;
            this.LblMember.BackColor = System.Drawing.Color.DarkBlue;
            this.LblMember.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblMember.ForeColor = System.Drawing.SystemColors.Window;
            this.LblMember.Location = new System.Drawing.Point(89, 161);
            this.LblMember.Name = "LblMember";
            this.LblMember.Size = new System.Drawing.Size(96, 19);
            this.LblMember.TabIndex = 6;
            this.LblMember.Text = "회원 관리";
            this.LblMember.Visible = false;
            // 
            // LblProduct
            // 
            this.LblProduct.AutoSize = true;
            this.LblProduct.BackColor = System.Drawing.Color.DarkBlue;
            this.LblProduct.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblProduct.ForeColor = System.Drawing.SystemColors.Window;
            this.LblProduct.Location = new System.Drawing.Point(89, 219);
            this.LblProduct.Name = "LblProduct";
            this.LblProduct.Size = new System.Drawing.Size(96, 19);
            this.LblProduct.TabIndex = 6;
            this.LblProduct.Text = "상품 관리";
            this.LblProduct.Visible = false;
            // 
            // LblInbound
            // 
            this.LblInbound.AutoSize = true;
            this.LblInbound.BackColor = System.Drawing.Color.DarkBlue;
            this.LblInbound.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblInbound.ForeColor = System.Drawing.SystemColors.Window;
            this.LblInbound.Location = new System.Drawing.Point(299, 286);
            this.LblInbound.Name = "LblInbound";
            this.LblInbound.Size = new System.Drawing.Size(96, 19);
            this.LblInbound.TabIndex = 6;
            this.LblInbound.Text = "입고 내역";
            this.LblInbound.Visible = false;
            // 
            // LblOutbound
            // 
            this.LblOutbound.AutoSize = true;
            this.LblOutbound.BackColor = System.Drawing.Color.DarkBlue;
            this.LblOutbound.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblOutbound.ForeColor = System.Drawing.SystemColors.Window;
            this.LblOutbound.Location = new System.Drawing.Point(91, 363);
            this.LblOutbound.Name = "LblOutbound";
            this.LblOutbound.Size = new System.Drawing.Size(96, 19);
            this.LblOutbound.TabIndex = 6;
            this.LblOutbound.Text = "출고 내역";
            this.LblOutbound.Visible = false;
            // 
            // LblChart
            // 
            this.LblChart.AutoSize = true;
            this.LblChart.BackColor = System.Drawing.Color.DarkBlue;
            this.LblChart.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblChart.ForeColor = System.Drawing.SystemColors.Window;
            this.LblChart.Location = new System.Drawing.Point(220, 435);
            this.LblChart.Name = "LblChart";
            this.LblChart.Size = new System.Drawing.Size(56, 19);
            this.LblChart.TabIndex = 6;
            this.LblChart.Text = "통 계";
            this.LblChart.Visible = false;
            // 
            // LblMemDel
            // 
            this.LblMemDel.AutoSize = true;
            this.LblMemDel.BackColor = System.Drawing.Color.DarkBlue;
            this.LblMemDel.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblMemDel.ForeColor = System.Drawing.SystemColors.Window;
            this.LblMemDel.Location = new System.Drawing.Point(100, 206);
            this.LblMemDel.Name = "LblMemDel";
            this.LblMemDel.Size = new System.Drawing.Size(63, 13);
            this.LblMemDel.TabIndex = 6;
            this.LblMemDel.Text = "회원 삭제";
            this.LblMemDel.Visible = false;
            // 
            // LblPdOrder
            // 
            this.LblPdOrder.AutoSize = true;
            this.LblPdOrder.BackColor = System.Drawing.Color.DarkBlue;
            this.LblPdOrder.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblPdOrder.ForeColor = System.Drawing.SystemColors.Window;
            this.LblPdOrder.Location = new System.Drawing.Point(100, 264);
            this.LblPdOrder.Name = "LblPdOrder";
            this.LblPdOrder.Size = new System.Drawing.Size(63, 13);
            this.LblPdOrder.TabIndex = 6;
            this.LblPdOrder.Text = "상품 주문";
            this.LblPdOrder.Visible = false;
            // 
            // LblPriceMdfy
            // 
            this.LblPriceMdfy.AutoSize = true;
            this.LblPriceMdfy.BackColor = System.Drawing.Color.DarkBlue;
            this.LblPriceMdfy.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblPriceMdfy.ForeColor = System.Drawing.SystemColors.Window;
            this.LblPriceMdfy.Location = new System.Drawing.Point(100, 286);
            this.LblPriceMdfy.Name = "LblPriceMdfy";
            this.LblPriceMdfy.Size = new System.Drawing.Size(63, 13);
            this.LblPriceMdfy.TabIndex = 6;
            this.LblPriceMdfy.Text = "가격 수정";
            this.LblPriceMdfy.Visible = false;
            // 
            // LblPdRegi
            // 
            this.LblPdRegi.AutoSize = true;
            this.LblPdRegi.BackColor = System.Drawing.Color.DarkBlue;
            this.LblPdRegi.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblPdRegi.ForeColor = System.Drawing.SystemColors.Window;
            this.LblPdRegi.Location = new System.Drawing.Point(100, 309);
            this.LblPdRegi.Name = "LblPdRegi";
            this.LblPdRegi.Size = new System.Drawing.Size(63, 13);
            this.LblPdRegi.TabIndex = 6;
            this.LblPdRegi.Text = "상품 등록";
            this.LblPdRegi.Visible = false;
            // 
            // LblPdDel
            // 
            this.LblPdDel.AutoSize = true;
            this.LblPdDel.BackColor = System.Drawing.Color.DarkBlue;
            this.LblPdDel.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblPdDel.ForeColor = System.Drawing.SystemColors.Window;
            this.LblPdDel.Location = new System.Drawing.Point(100, 334);
            this.LblPdDel.Name = "LblPdDel";
            this.LblPdDel.Size = new System.Drawing.Size(63, 13);
            this.LblPdDel.TabIndex = 6;
            this.LblPdDel.Text = "상품 삭제";
            this.LblPdDel.Visible = false;
            // 
            // LblPdInbound
            // 
            this.LblPdInbound.AutoSize = true;
            this.LblPdInbound.BackColor = System.Drawing.Color.DarkBlue;
            this.LblPdInbound.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblPdInbound.ForeColor = System.Drawing.SystemColors.Window;
            this.LblPdInbound.Location = new System.Drawing.Point(309, 331);
            this.LblPdInbound.Name = "LblPdInbound";
            this.LblPdInbound.Size = new System.Drawing.Size(93, 13);
            this.LblPdInbound.TabIndex = 6;
            this.LblPdInbound.Text = "상품 입고 내역";
            this.LblPdInbound.Visible = false;
            // 
            // LblPdOutbound
            // 
            this.LblPdOutbound.AutoSize = true;
            this.LblPdOutbound.BackColor = System.Drawing.Color.DarkBlue;
            this.LblPdOutbound.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblPdOutbound.ForeColor = System.Drawing.SystemColors.Window;
            this.LblPdOutbound.Location = new System.Drawing.Point(105, 408);
            this.LblPdOutbound.Name = "LblPdOutbound";
            this.LblPdOutbound.Size = new System.Drawing.Size(93, 13);
            this.LblPdOutbound.TabIndex = 6;
            this.LblPdOutbound.Text = "상품 출고 내역";
            this.LblPdOutbound.Visible = false;
            // 
            // LblSaleChart
            // 
            this.LblSaleChart.AutoSize = true;
            this.LblSaleChart.BackColor = System.Drawing.Color.DarkBlue;
            this.LblSaleChart.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblSaleChart.ForeColor = System.Drawing.SystemColors.Window;
            this.LblSaleChart.Location = new System.Drawing.Point(231, 480);
            this.LblSaleChart.Name = "LblSaleChart";
            this.LblSaleChart.Size = new System.Drawing.Size(102, 13);
            this.LblSaleChart.TabIndex = 6;
            this.LblSaleChart.Text = "총매출액 그래프";
            this.LblSaleChart.Visible = false;
            // 
            // LblProdChart
            // 
            this.LblProdChart.AutoSize = true;
            this.LblProdChart.BackColor = System.Drawing.Color.DarkBlue;
            this.LblProdChart.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblProdChart.ForeColor = System.Drawing.SystemColors.Window;
            this.LblProdChart.Location = new System.Drawing.Point(231, 502);
            this.LblProdChart.Name = "LblProdChart";
            this.LblProdChart.Size = new System.Drawing.Size(119, 13);
            this.LblProdChart.TabIndex = 6;
            this.LblProdChart.Text = "상품별 판매 그래프";
            this.LblProdChart.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(234, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(554, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // LblLiveInfo
            // 
            this.LblLiveInfo.AutoSize = true;
            this.LblLiveInfo.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblLiveInfo.Location = new System.Drawing.Point(230, 80);
            this.LblLiveInfo.Name = "LblLiveInfo";
            this.LblLiveInfo.Size = new System.Drawing.Size(358, 21);
            this.LblLiveInfo.TabIndex = 8;
            this.LblLiveInfo.Text = "실시간 카트 정보 및 실시간 사용자";
            // 
            // LblNowDate
            // 
            this.LblNowDate.AutoSize = true;
            this.LblNowDate.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblNowDate.Location = new System.Drawing.Point(515, 474);
            this.LblNowDate.Name = "LblNowDate";
            this.LblNowDate.Size = new System.Drawing.Size(273, 19);
            this.LblNowDate.TabIndex = 9;
            this.LblNowDate.Text = "2020년 03월 24일 화요일 12:11";
            // 
            // LblAdmin
            // 
            this.LblAdmin.AutoSize = true;
            this.LblAdmin.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblAdmin.Location = new System.Drawing.Point(516, 503);
            this.LblAdmin.Name = "LblAdmin";
            this.LblAdmin.Size = new System.Drawing.Size(146, 15);
            this.LblAdmin.TabIndex = 10;
            this.LblAdmin.Text = "Admin 님 안녕하세요";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(713, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "LOGOUT";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(814, 536);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LblAdmin);
            this.Controls.Add(this.LblNowDate);
            this.Controls.Add(this.LblLiveInfo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LblPdDel);
            this.Controls.Add(this.LblPdRegi);
            this.Controls.Add(this.LblPriceMdfy);
            this.Controls.Add(this.LblPdOutbound);
            this.Controls.Add(this.LblPdInbound);
            this.Controls.Add(this.LblProdChart);
            this.Controls.Add(this.LblSaleChart);
            this.Controls.Add(this.LblPdOrder);
            this.Controls.Add(this.LblMemDel);
            this.Controls.Add(this.LblCartInfo);
            this.Controls.Add(this.LblUsingUser);
            this.Controls.Add(this.LblChart);
            this.Controls.Add(this.LblOutbound);
            this.Controls.Add(this.LblInbound);
            this.Controls.Add(this.LblProduct);
            this.Controls.Add(this.LblMember);
            this.Controls.Add(this.LblCart);
            this.Controls.Add(this.LblMain);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnOutbound);
            this.Controls.Add(this.btnInbound);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnMember);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMINISTRATOR";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnInbound;
        private System.Windows.Forms.Button btnOutbound;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Label LblMain;
        private System.Windows.Forms.Label LblCart;
        private System.Windows.Forms.Label LblUsingUser;
        private System.Windows.Forms.Label LblCartInfo;
        private System.Windows.Forms.Label LblMember;
        private System.Windows.Forms.Label LblProduct;
        private System.Windows.Forms.Label LblInbound;
        private System.Windows.Forms.Label LblOutbound;
        private System.Windows.Forms.Label LblChart;
        private System.Windows.Forms.Label LblMemDel;
        private System.Windows.Forms.Label LblPdOrder;
        private System.Windows.Forms.Label LblPriceMdfy;
        private System.Windows.Forms.Label LblPdRegi;
        private System.Windows.Forms.Label LblPdDel;
        private System.Windows.Forms.Label LblPdInbound;
        private System.Windows.Forms.Label LblPdOutbound;
        private System.Windows.Forms.Label LblSaleChart;
        private System.Windows.Forms.Label LblProdChart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label LblLiveInfo;
        private System.Windows.Forms.Label LblNowDate;
        private System.Windows.Forms.Label LblAdmin;
        private System.Windows.Forms.Button button1;
    }
}

