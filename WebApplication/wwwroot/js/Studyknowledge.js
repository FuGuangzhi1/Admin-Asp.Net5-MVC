const VM = new Vue(
    {
        el: '#app',
        data: {
            SearchStudyknowledgeName: "", //模糊查询，模糊筛选
            tableData: [],  //数据绑定
            currentPage: 1, //初始页
            pagesize: 5,//每页的数据
            total: 0,   //总记录数
            StudyTypeId: "",
            //模态框
            dialogFormVisible: false,
            StudyType: [{ studyTypeId: null, studyTypeName: null }],
            handleClose: false,
            form: {
                studyknowledgeName: '求Star',
                studyknowledgeContent: '求Star',
                createDateTime: '',
                StudyknowledgeViewId: '',
                sktudyTypeId: ""
            }/*,formLabelWidth:'120px'*/
            , rules: {
                studyknowledgeName: [
                    { required: true, message: '请输入知识姓名', trigger: 'blur' },
                    { min: 2, max: 20, message: '名字不能太长或者太短', trigger: 'blur' }
                ], studyknowledgeContent: [
                    { required: true, message: '请输入内容', trigger: 'change' },
                    { min: 2, max: 500, message: '内容不能太长或者太短', trigger: 'blur' }
                ], studyTypeId: [
                    { required: true, message: '请选择类型', trigger: 'change' }
                ]
            }
        }, mounted() {
            this.load();  //列表加载
            this.GetStudyType(); //下拉数据绑定 类型
        }, methods: {
            async load() {
                //axios.post(url, this.form).then(result => { }).catch(error => { })
                const { data: res } = await axios.get
                    (`/Study/StudyknowledgeData?Name=${this.SearchStudyknowledgeName} &StydyTypeId=${this.StudyTypeId} &PageSize=${this.pagesize} &PageIndex=${this.currentPage}`);
                console.log(res);
                this.tableData = res.rows;
                this.total = res.total;
            }, async Search(event) {
                await this.load();
            },
            async GetStudyType() {
                const { data: res } = await axios.get("/Study/StudyTypeData");
                console.log(res);
                this.StudyType = res;
            },
            Confirm: function (formValid) {
                this.$refs[formValid].validate(async (valid) => {
                    if (valid) {
                        console.log("格式正确");
                        var f = new FormData();
                        for (let key in this.form) {
                            f.append(key, this.form[key]);
                        }
                        try {
                            const { data: res } = await axios.post
                                ("/Study/UpdateOrInsertStudyTypeData", f);
                            console.log(res);
                            this.result(res);
                        } catch {
                            this.$message.error('请求地址错误，或者没有网络，或者服务器爆炸！！！');
                        }
                        this.load();
                    } else {
                        console.log('error submit!!');
                        return false;
                    }
                });
            },//模态框开关提示
            Close() {
                this.$confirm('确认关闭？')
                    .then(_ => {
                        this.dialogFormVisible = false;
                        this.form = {
                            StudyknowledgeName: '求Star',
                            StudyknowledgeNameType: '求Star',
                            StudyknowledgeContent: '求Star',
                            CreateDateTime: '',
                            StudyknowledgeNameId: '',
                            StudyTypeId: ''
                        };
                    })
                    .catch(_ => {
                        this.$message.error('教我做事？');
                    });
            },//请求结果处理
            result(res) {
                if (res.success) {
                    this.$message({
                        showClose: true,
                        message: res.message,
                        type: 'success'
                    });
                    this.Close();
                } else {
                    this.$message({
                        showClose: true,
                        message: res.message,
                        type: 'warning'
                    });
                }

            }, handleSizeChange(val) {
                this.StudyTypeId = "";
                this.SearchStudyknowledgeName = "";
                this.pagesize = val;
                this.load();
            }, handleCurrentChange(val) {
                this.StudyTypeId = "";
                this.SearchStudyknowledgeName = "";
                this.currentPage = val;
                this.load();
            }, Edit(data) {
                this.dialogFormVisible = true;
                console.log(data);
                this.form = data
            }, Delete(data) {
                this.$confirm('真的要删除吗？')
                    .then(_ => {
                        //删除事件
                        axios.post("/Student/Delete", data)
                            .then(response => {
                                debugger
                                this.$message(response.data);
                                this.load();
                            }).cath(_error => {
                                this.$message('！！！！问题很大');
                            })
                    })
                    .catch(_ => {
                        //this.$message('不删点什么点');
                    });
            }
        }

    }
);