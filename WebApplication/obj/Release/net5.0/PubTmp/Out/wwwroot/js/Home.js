const VM = new Vue({
    el: '#app',
    data: {
        isCollapse: false,
        url: '../images/小新.jpg',
        srcList: [
            '../images/小新.jpg'
        ], menuList: []
        , role: ["统治者", "大将"]
    }
    , mounted() {
        this.$message({
            showClose: true,
            message: "欢迎",
            type: 'success'
        });
        this.getmenuList();
    }, methods: {
        handleOpen(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClose(key, keyPath) {
            console.log(key, keyPath);
        }, async getmenuList() {
            const { data: res } = await axios.get("/HomePage/GetmenuList");
            console.log(res);
            this.menuList = res.data;
        }, message(enve) {
            this.$notify({
                title: '您的身份是',
                message: this.role.join('-'),
                position: 'bottom-right'
            });
        }, skip(text) {
            document.getElementById('ifPage').src = text;
            /*  console.log(text);*/
        }, openOrClose() {
            console.log("aa");

            if (this.isCollapse) {
                this.isCollapse = false;
                document.getElementsByClassName('el-aside')[0].style.width = "200px";
            } else {
                this.isCollapse = true;
                document.getElementsByClassName('el-aside')[0].style.width = "64px";
                
            }
        }
    }
});