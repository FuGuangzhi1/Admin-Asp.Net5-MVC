const VM = new Vue(
    {
        el: '#app',
        data: {
            SearchStudyknowledgeName: this.SearchStudyknowledgeName, //模糊查询，模糊筛选
            tableData: [],  //数据绑定
            currentPage: 1, //初始页
            pagesize: 2,//每页的数据
            total: 0,   //总记录数
            //模态框
            dialogFormVisible: false,
            StudyType: [{ studyTypeId: null, studyTypeName: null}],
            handleClose: false,
            form: {
                StudyknowledgeName: '求Star',
                StudyknowledgeContent: '求Star',
                CreateDateTime: '',
                StudyknowledgeId: '',
                StudyTypeId:""
            }/*,formLabelWidth:'120px'*/
            , rules: {
                StudyknowledgeName: [
                    { required: true, message: '请输入知识姓名', trigger: 'blur' },
                    { min: 2, max: 10, message: '名字不能太长或者太短', trigger: 'blur' }
                ], StudyknowledgeContent: [
                    { required: true, message: '请输入内容', trigger: 'change' },
                    { min: 2, max: 200, message: '内容不能太长或者太短', trigger: 'blur' }
                ], StudyknowledgeContent: [
                    { required: true, message: '请选择类型', trigger: 'change' }
                ]
            }
        }, mounted() {
            this.load();  //列表加载
            this.GetStudyType(); //下拉数据绑定 类型
        }, methods: {
            async load() {
                //axios.post(url, this.form).then(result => { }).catch(error => { })
                const { data: res } = await axios.get("/Study/StudyknowledgeData");
                console.log(res);
                this.tableData = res.rows;
            }, async GetStudyType() {
                const { data: res } = await axios.get("/Study/StudyTypeData");
                console.log(res);
                this.StudyType = res;
            }, Confirm: function (formValid) {
                this.$refs[formValid].validate(async (valid) => {
                    if (valid) {
                        console.log("格式正确");
                        var f = new FormData();
                        //f.append('StudyknowledgeName', this.form.StudyknowledgeName);
                        for (let key in this.form) {
                            f.append(key, this.form[key]);
                        }
                        const { data: res } = await axios.post
                            ("/Study/UpdateOrInsertStudyTypeData",f);
                        console.log(res);
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
                        //this.$message('教我做事？');
                    });
            }
        }

    }
);