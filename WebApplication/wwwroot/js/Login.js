const VM = new Vue({
    el: "#app",
    data: {
        loading: false,
        login: {
            name: '小杰',
            password: '123456',
            checkCode: ''
        },
        value1: true,
        rules: {
            name: [
                { required: true, message: '请输入账号', trigger: 'blur' },
                { min: 2, max: 18, message: '长度在 2 到 18 个字符', trigger: 'blur' }
            ],
            password: [
                { required: true, message: '请输入密码', trigger: 'blur' },
                { min: 6, max: 18, message: '长度在 6 到 18 个字符', trigger: 'blur' }
            ],
            checkCode: [
                { required: true, message: '请输入验证码', trigger: 'blur' },
                { min: 4, max: 4, message: '长度在  4 个字符', trigger: 'blur' }
            ]
        }
    },
    mounted() {
        if (localStorage.getItem("name") != null && localStorage.getItem("password") != null &&
            localStorage.getItem("name") != undefined && localStorage.getItem("password") != undefined
        ) {
            this.login.name = localStorage.getItem("name");
            this.login.password = localStorage.getItem("password");
        }
    },
    methods: {
        remember() { //记住密码
            if (this.value1 == false) {
                this.login.name = "";
                this.login.password = "";
                this.login.checkCode = "";
                localStorage.removeItem("name");
                localStorage.removeItem("password");

            } else {
                localStorage.setItem('name', this.login.name);
                localStorage.setItem('password', this.login.password);
                this.login.checkCode = "";
            }
        },
        colorRemoval() { //背景颜色变白
            let mainDiv = document.getElementById("app");
            mainDiv.style.background = "white";
        },
        colorChange() { //背景颜色随机颜色
            let mainDiv = document.getElementById("app");
            mainDiv.style.background = this.randomHexColor();
        },
        captchaChange() { //验证码改变
            this.captcha();
        },
        captcha: function () { 
            var captcha = document.getElementById("img-captcha");
            d = new Date();
            captcha.src = "/AccountControllers/GetCaptchaImage?" + d.getTime();
        },
        randomHexColor: function () {
            //随机生成十六进制颜色
            var hex = Math.floor(Math.random() * 16777216).toString(16); //生成ffffff以内16进制数
            while (hex.length < 6) { //while循环判断hex位数，少于6位前面加0凑够6位
                hex = '0' + hex;
            }
            return '#' + hex; //返回‘#'开头16进制颜色
        },
        //登录按钮
        loginForm: function (url) {
            this.loading = true; //加载动画
            axios.post(url, this.login).then(result => {
                let data = result.data; //成功数据
                if (result.status >= 200 && result.status <= 299) {
                    console.log(data);
                    this.timeOut();
                    if (data.success) {
                        this.remember();  
                        this.captcha();
                        window.open("/HomePage/index");
                    } else {
                        this.$message({
                            showClose: true,
                            message: data.message,
                            type: 'warning'
                        });
                        this.captcha();
                    }
                } else {
                    this.timeOut();
                    this.$message.error('数据请求失败！！！');
                    this.captcha();
                }
            }).catch(error => {       
                console.log(error);
                this.timeOut();
                this.$message.error('请求地址错误，或者没有网络，或者服务器爆炸！！！');
                this.captcha();
            })
        },
        submitForm(formname) {
            this.$refs[formname].validate((valid) => {
                if (valid) {
                    console.log("格式正确");
                    let url = "/AccountControllers/Login";
                    this.loginForm(url);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },
        async resetForm(formname) {
            console.log(formname);
            await this.$refs[formname].resetFields();
        },
        timeOut() {
            setTimeout(() => this.loading = false, 1000);
        },
        Create() {
            window.open("/AccountControllers/CreateUser");
        }
    }
});