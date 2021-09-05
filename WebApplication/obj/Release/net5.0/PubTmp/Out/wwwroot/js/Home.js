const VM = new Vue({
    el: '#app',
    data: {
        isCollapse: true,
        url: '../images/小新.jpg',
        srcList: [
            '../images/小新.jpg'
        ], menuList: []
        , role:["统治者","大将"]
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
        }, message(enve)
        {
            this.$notify({
                title: '您的身份是',
                message: this.role.join('-'),
                position: 'bottom-right'
            });
        }, skip(text)
        {
            document.getElementById('ifPage').src = text;
          /*  console.log(text);*/
        }
    }
});