const VM = new Vue({
    el: '#app',
    data: {
        form: {
            name: '',
            moblie: '',
            sex: '',
            hobby: '',
            email: '',
            qq: '',
            birthday: '',
            password: '',
            password1: ''
        }, rules: {
            name: [
                { required: true, message: '请输入姓名', trigger: 'blur' },
                { min: 2, max: 5, message: '长度在 3 到 5 个字符', trigger: 'blur' }
            ], password: [
                { required: true, message: '请输入密码', trigger: 'blur' },
                { min: 6, max: 18, message: '长度在6到 18 个字符', trigger: 'blur' },
            ], password1: [
                { required: true, message: '请确定密码', trigger: 'blur' },
                { min: 6, max: 18, message: '长度在 6 到 18 个字符', trigger: 'blur' },
            ], email: [
                { required: true, message: '请输入邮箱', trigger: 'blur' },
                { type: 'email', message: '请输入正确的邮箱地址', trigger: 'change' }
            ], sex: { required: true, message: '请选择性别', trigger: 'blur' },
        }
    }, Create() {

    }, methods: {
        async register(url) {
            var formData = new FormData();
            for (let key in this.form) {
                formData.append(key, this.form[key]);
            }
            const { data: res } = await axios.post(url, formData);
            console.log(res);
            if (res.success) {
                this.$message({
                    showClose: true,
                    message: res.message,
                    type: 'success'
                });
                this.resetForm(this.form);
                this.$confirm( res.data+'是否回到登录？')
                    .then(_ => {
                        window.location="/Account/Login";
                    }).catch(_ => {
                        this.$message.error('教我做事？');
                    });

            } else {
                this.$message({
                    showClose: true,
                    message: res.message,
                    type: 'info'
                });
            }
        },
        onSubmit(form) {
            if (this.form.password != this.form.password1) {
                this.$message({
                    showClose: true,
                    message: '两次密码不一样',
                    type: 'warning'
                });
            } else {
                this.$refs[form].validate((valid) => {
                    if (valid) {
                        console.log("格式正确");
                        let url = "/Account/Create";
                        this.$confirm('确认创建？')
                            .then(_ => {
                                this.register(url);
                            }).catch(_ => {
                                this.$message.error('教我做事？');
                            });
                    } else {
                        console.log('error submit!!');
                        return false;
                    }
                });
            }
            console.log(this.form);
        }, async resetForm(formname) {
            await this.$refs[formname].resetFields();
        }
    }

})